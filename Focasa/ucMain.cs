using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Focasa
{
    public partial class ucMain : ucParent
    {
        private frmMain main;
        public ucMain(frmMain f)
        {
            main = f;

            InitializeComponent();

            Synchronizer = new FileSynchronization(ref frmParent.FocasaMonitoredFolders, new string[] { ".jpg", ".jpeg", ".bmp", ".tif", ".tiff", ".png" });

            using (Data.SQLiteDatabase db = new Data.SQLiteDatabase(System.AppDomain.CurrentDomain.BaseDirectory, "Focasa.db"))
            {
                LoadFolders();
                LoadItems();
            }
        }

        



        private void LoadFolders()
        {
            LoadFolders(null);
        }

        private void LoadItems()
        {
            using (Data.SQLiteDatabase db = new Data.SQLiteDatabase(System.AppDomain.CurrentDomain.BaseDirectory, "Focasa.db"))
            {
                frmParent.FocasaItems = db.GetDataTable("SELECT * FROM focasaItems");
            }

            DataView view = new DataView(frmParent.FocasaItems);
            view.Sort = "path asc";
            DataTable distinctValues = view.ToTable(true, "path");
            string currentFolder = null;

            foreach (DataRow drow in distinctValues.Rows)
            {
                if (drow.RowState != DataRowState.Deleted)
                {
                    ucFolderRepresentation ucFolder = null;
                    if (currentFolder == null || currentFolder != drow["path"].ToString())
                    {
                        ucFolder = new ucFolderRepresentation(main, drow["path"].ToString());
                        flpPictures.Controls.Add(ucFolder);
                        currentFolder = drow["path"].ToString();
                    }

                    DataRow[] items = frmParent.FocasaItems.Select("path='" + drow["path"].ToString() + "'");
                    foreach (DataRow item in items)
                    {
                        ucPictureRepresentation ucPicture = new ucPictureRepresentation(main, item["path"].ToString(), item["name"].ToString(), Base64ToImage(item["thumbnail"].ToString()), item["exif"].ToString());
                        ucFolder.Images.Controls.Add(ucPicture);
                    }


                }
            }

            foreach (TreeNode n in tvFolders.Nodes)
            {
                n.Expand();
            }
        }

        public Image Base64ToImage(string base64String)
        {

            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);

            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void LoadFolders(string folder)
        {
            using (Data.SQLiteDatabase db = new Data.SQLiteDatabase(System.AppDomain.CurrentDomain.BaseDirectory, "Focasa.db"))
            {
                frmParent.FocasaMonitoredFolders = db.GetDataTable("SELECT * FROM focasaMonitoredFolders");
            }

            foreach (DataRow drow in frmParent.FocasaMonitoredFolders.Rows)
            {
                if (drow.RowState != DataRowState.Deleted)
                {
                    if (folder != null && folder == drow["path"].ToString()) continue;

                    string[] pathParts = drow["path"].ToString().Split('\\');
                    TreeNode parent = null;
                    foreach (string pathPart in pathParts)
                    {
                        TreeNode[] foundNodes;
                        if (parent == null)
                            foundNodes = tvFolders.Nodes.Find(pathPart, false);
                        else
                            foundNodes = parent.Nodes.Find(pathPart, false);

                        if (foundNodes.Length == 1)
                            parent = foundNodes[0];
                        else if (foundNodes.Length == 0)
                        {
                            TreeNode node = new TreeNode(pathPart);
                            if (parent == null)
                                tvFolders.Nodes.Add(node);
                            else
                                parent.Nodes.Add(node);
                            parent = node;


                        }
                        else
                            throw new Exception("Too many nodes found");
                    }
                    foreach (TreeNode n in tvFolders.Nodes)
                    {
                        n.Expand();
                    }
                    //TreeNode node = new TreeNode(Path.GetFileName(drow["path"].ToString()));


                }
            }
        }
    }
}
