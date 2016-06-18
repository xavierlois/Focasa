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
    public class frmParent : Form
    {
        public static DataTable FocasaItems;
        public static DataTable FocasaMonitoredFolders;
        public  static FileSynchronization Synchronizer;
    }
}
