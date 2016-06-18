using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Focasa
{
    public partial class ucFolderRepresentation : UserControl
    {
        private string FolderName;
        private frmMain main;

        public FlowLayoutPanel Images
        {
            get { return flpPictures; }
        }

        public ucFolderRepresentation(frmMain f, string name)
        {
            main = f;

            InitializeComponent();
            FolderName = name;

            lblFolderName.Text = FolderName;
        }
    }
}
