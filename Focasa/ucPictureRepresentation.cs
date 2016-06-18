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
    public partial class ucPictureRepresentation : UserControl
    {
        private string p1;
        private string p2;
        private Image image;
        private string p3;
        private frmMain main;

        public string Properties
        {
            get { return p3; }
        }

        public ucPictureRepresentation(frmMain f, string path, string name, Image image, string properties) 
        {
            main = f;

            InitializeComponent();

            // TODO: Complete member initialization
            this.p1 = path;
            this.p2 = name;
            this.image = image;
            this.p3 = properties;

            pictureBox.Image = this.image;

            txtPictureCaption.Text = this.Name;
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            main.SwitchToItem(p1, p2, p3);
        }
    }
}
