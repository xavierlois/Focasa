using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Focasa
{
    public partial class frmFolderManagement : frmParent
    {
        public frmFolderManagement()
        {
            InitializeComponent();
        }

        private void frmFolderManagement_Load(object sender, EventArgs e)
        {
            string[] drives = Environment.GetLogicalDrives();
            foreach (string d in drives)
            {
                TreeNode n = tvFolders.Nodes.Add(d);
                n.Tag = d;
                n.Nodes.Add("dummy");
                //tvFolders.BeforeExpand += tvFolders_BeforeExpand;
                tvFolders.AfterExpand += tvFolders_AfterExpand;
            }

            PopulateMonitoredFolders();



        }

        private void PopulateMonitoredFolders()
        {
            lbMonitoredFolders.Items.Clear();
            foreach (DataRow dr in frmParent.FocasaMonitoredFolders.Rows)
            {
                if ((dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Unchanged || dr.RowState == DataRowState.Detached) && (dr["monitoringType"] == "always"))
                    lbMonitoredFolders.Items.Add(dr["path"].ToString());
            }
        }

        void tvFolders_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "dummy")
                PopulatePath(e.Node); 
        }

        //void tvFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        //{
        //    TreeView tv = sender as TreeView;
        //    PopulatePath(tv.SelectedNode); 
        //}

        private void PopulatePath(TreeNode treeNode)
        {
            string path = treeNode.Tag.ToString();
            treeNode.Nodes.Clear();
            string[] dirs = Directory.GetDirectories(path);
            foreach (string d in dirs)
            {
                TreeNode n = treeNode.Nodes.Add(Path.GetFileName(d));
                n.Tag = d;
                n.Nodes.Add("dummy");
            }
        }

        private void rbOnce_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOnce.Checked)
            {
                if (frmParent.FocasaMonitoredFolders.Select("path = '" + tvFolders.SelectedNode.Tag.ToString() + "' and monitoringType='once'").Length > 0) return;

                DataRow dr = frmParent.FocasaMonitoredFolders.NewRow();
                dr["path"] = tvFolders.SelectedNode.Tag.ToString();
                dr["monitoringType"] = "once";
                frmParent.FocasaMonitoredFolders.Rows.Add(dr);
                PopulateMonitoredFolders();
                tvFolders.SelectedNode.ForeColor = Color.Green;
                tvFolders.Invalidate();
            }
        }

        private void rbNever_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNever.Checked)
            {
                DataRow[] drs = frmParent.FocasaMonitoredFolders.Select("path = '" + tvFolders.SelectedNode.Tag.ToString() + "'");
                if (drs.Length == 1)
                    drs[0].Delete();
                PopulateMonitoredFolders();
                tvFolders.SelectedNode.ForeColor = Color.Black;
            }
        }

        private void rbAlways_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAlways.Checked)
            {
                if (frmParent.FocasaMonitoredFolders.Select("path = '" + tvFolders.SelectedNode.Tag.ToString() + "' and monitoringType='always'").Length > 0) return;

                DataRow dr = frmParent.FocasaMonitoredFolders.NewRow();
                dr["path"] = tvFolders.SelectedNode.Tag.ToString();
                dr["monitoringType"] = "always";
                frmParent.FocasaMonitoredFolders.Rows.Add(dr);
                PopulateMonitoredFolders();
                tvFolders.SelectedNode.ForeColor = Color.Blue;
            }
        }

        private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (frmParent.FocasaMonitoredFolders.Select("path = '" + e.Node.Tag.ToString() + "' and monitoringType='always'").Length > 0)
                rbAlways.Checked = true;
            else if (frmParent.FocasaMonitoredFolders.Select("path = '" + e.Node.Tag.ToString() + "' and monitoringType='once'").Length > 0)
                rbOnce.Checked = true;
            else
                rbNever.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
