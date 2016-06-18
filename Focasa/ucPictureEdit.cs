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
    public partial class ucPictureEdit : UserControl
    {
        private frmMain main;

        public ucPictureEdit(frmMain f, string path, string name, string exif)
        {
            main = f;

            InitializeComponent();

            pictureBox1.Image = Image.FromFile(Path.Combine(path, name));
        }

        private void ucPictureEdit_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            main.SwitchToFolder();
        }
    }
}
