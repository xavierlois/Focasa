using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Focasa
{
    public partial class frmMain : frmParent
    {
        private ucMain mainDialog;

        public frmMain()
        {
            InitializeComponent();

            System.AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            mainDialog = new ucMain(this);
            flpMain.Controls.Add(mainDialog);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception).ToString());
        }

        public void SwitchToItem(string path, string name, string exif)
        {
            ucPictureEdit pe = new ucPictureEdit(this, path, name, exif);
            flpMain.Controls.Clear();
            flpMain.Controls.Add(pe);
        }

        public void SwitchToFolder()
        {
            flpMain.Controls.Clear();
            flpMain.Controls.Add(mainDialog);
        }

        private void optionsFolderManagement_Click(object sender, EventArgs e)
        {
            frmFolderManagement f = new frmFolderManagement();
            DialogResult drs = f.ShowDialog();
            if (drs == System.Windows.Forms.DialogResult.OK)
            {
                bool needSync = false;
                DataTable dtChanges = FocasaMonitoredFolders.GetChanges();
                if (dtChanges == null)
                    return;
                DataTable dt = dtChanges.Copy();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        using (Data.SQLiteDatabase db = new Data.SQLiteDatabase(System.AppDomain.CurrentDomain.BaseDirectory, "Focasa.db"))
                        {
                            Dictionary<string, string> dic = new Dictionary<string, string>();

                            foreach (DataColumn dc in dt.Columns)
                            {
                                dic.Add(dc.ColumnName, dr[dc.ColumnName].ToString());
                            }
                            db.Insert("focasaMonitoredFolders", dic);
                            needSync = true;
                        }
                    }
                }

                if (needSync)
                {
                    Synchronizer = new FileSynchronization(ref FocasaMonitoredFolders, new string[]{".jpg",".jpeg",".tif",".tiff",".bmp",".png"});
                    FileSynchronization.OnSyncStateUpdate+=FileSynchronization_OnSyncStateUpdate;
                    Task<int> t = FileSynchronization.Sync(dt);
                    int i = t.Result;

                    mainDialog = new ucMain(this);
                    flpMain.Controls.Clear();
                    flpMain.Controls.Add(mainDialog);
                }
            }
        }

        void FileSynchronization_OnSyncStateUpdate(object sender, SyncStateUpdateArgs e)
        {
            //lblDetectFile.Text = e.FileName;
            //lblDetectFolder.Text = e.FolderName;
            //pbThumb.Image = e.Thumbnail;
        }

        
    }
}
