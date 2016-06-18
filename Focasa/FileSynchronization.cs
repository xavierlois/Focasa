using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Focasa
{
    public class FileSynchronization
    {
        private static System.Data.DataTable dataTable;
        private static string[] allowedFileExtensions;

        public FileSynchronization(ref System.Data.DataTable monitoredFolders, string[] extensions)
        {
            // TODO: Complete member initialization
            dataTable = monitoredFolders;
            allowedFileExtensions = extensions;
        }

        public static event EventHandler<SyncStateUpdateArgs> OnSyncStateUpdate;

        public static async Task<int> Sync(DataTable dt)
        {
            int i = 0;
            foreach (DataRow drow in dt.Rows)
            {
                if (drow.RowState != DataRowState.Deleted)
                {
                    string folderToAnalyse = drow["path"].ToString();
                    i += await Task.FromResult<int>(AnalyseFolder(folderToAnalyse));
                }
            }
            return i;
        }

        private static int AnalyseFolder(string folder)
        {
            int i = 0;
            string[] files = Directory.GetFiles(folder);
            using (Data.SQLiteDatabase db = new Data.SQLiteDatabase(System.AppDomain.CurrentDomain.BaseDirectory, "Focasa.db"))
            {
                foreach (string file in files)
                {
                    i += AnalyseFile(file, db);
                }
            }
            string[] dirs = Directory.GetDirectories(folder);
            foreach (String dir in dirs)
                i += AnalyseFolder(dir);
            return i;
        }

        private static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private static int AnalyseFile(string file, Data.SQLiteDatabase db)
        {
            if (allowedFileExtensions.Contains<string>(Path.GetExtension(file)))
            {
                Image image = Image.FromFile(file);
                Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                Bitmap bmp = new Bitmap(thumb);

                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] byteImage = ms.ToArray();
                //string SigBase64= Convert.ToBase64String(byteImage); //Get Base64

                string SigBase64 = ImageToBase64(bmp, System.Drawing.Imaging.ImageFormat.Jpeg);

                if (db.GetDataTable("SELECT * FROM focasaItems WHERE path='" + Path.GetDirectoryName(file) + "' AND name='" + Path.GetFileName(file) + "'").Rows.Count == 0)
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("guid", Guid.NewGuid().ToString());
                    dic.Add("path", Path.GetDirectoryName(file));
                    dic.Add("name", Path.GetFileName(file));
                    dic.Add("thumbnail", SigBase64);
                    dic.Add("exif", "");
                    dic.Add("importedon", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    dic.Add("lastmodified", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    bool result = db.Insert("focasaItems", dic);
                    if (!result)
                        throw new Exception("Could not insert analyzed file " + file + " in db " + db.ConnectionString);
                }


                RaiseSyncStateUpdate(Path.GetFileName(file), Path.GetFileName(Path.GetDirectoryName(file)), bmp);
                return 1;
            }
            else
            {
                //ignore
                return 0;
            }
        }

        private static void RaiseSyncStateUpdate(string file, string folder, Bitmap image)
        {
            SyncStateUpdateArgs arg = new SyncStateUpdateArgs();
            arg.FileName = file;
            arg.FolderName = folder;
            arg.Thumbnail = image;

            if (OnSyncStateUpdate != null)
                OnSyncStateUpdate(null, arg);
        }
    }

    public class SyncStateUpdateArgs : EventArgs
    {
        public string FolderName;
        public string FileName;
        public Bitmap Thumbnail;
    }


}
