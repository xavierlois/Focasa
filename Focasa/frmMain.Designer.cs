namespace Focasa
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsFolderManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDetection = new System.Windows.Forms.Panel();
            this.lblDetectFolder = new System.Windows.Forms.Label();
            this.pbThumb = new System.Windows.Forms.PictureBox();
            this.lblDetectFile = new System.Windows.Forms.Label();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.pnlDetection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1029, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsFolderManagement});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsFolderManagement
            // 
            this.optionsFolderManagement.Name = "optionsFolderManagement";
            this.optionsFolderManagement.Size = new System.Drawing.Size(181, 22);
            this.optionsFolderManagement.Text = "Folder Management";
            this.optionsFolderManagement.Click += new System.EventHandler(this.optionsFolderManagement_Click);
            // 
            // pnlDetection
            // 
            this.pnlDetection.Controls.Add(this.lblDetectFolder);
            this.pnlDetection.Controls.Add(this.pbThumb);
            this.pnlDetection.Controls.Add(this.lblDetectFile);
            this.pnlDetection.Location = new System.Drawing.Point(829, 27);
            this.pnlDetection.Name = "pnlDetection";
            this.pnlDetection.Size = new System.Drawing.Size(200, 43);
            this.pnlDetection.TabIndex = 1;
            this.pnlDetection.Visible = false;
            // 
            // lblDetectFolder
            // 
            this.lblDetectFolder.AutoSize = true;
            this.lblDetectFolder.Location = new System.Drawing.Point(3, 0);
            this.lblDetectFolder.Name = "lblDetectFolder";
            this.lblDetectFolder.Size = new System.Drawing.Size(35, 13);
            this.lblDetectFolder.TabIndex = 0;
            this.lblDetectFolder.Text = "label1";
            // 
            // pbThumb
            // 
            this.pbThumb.Location = new System.Drawing.Point(138, 0);
            this.pbThumb.Name = "pbThumb";
            this.pbThumb.Size = new System.Drawing.Size(62, 43);
            this.pbThumb.TabIndex = 2;
            this.pbThumb.TabStop = false;
            // 
            // lblDetectFile
            // 
            this.lblDetectFile.AutoSize = true;
            this.lblDetectFile.Location = new System.Drawing.Point(3, 27);
            this.lblDetectFile.Name = "lblDetectFile";
            this.lblDetectFile.Size = new System.Drawing.Size(35, 13);
            this.lblDetectFile.TabIndex = 1;
            this.lblDetectFile.Text = "label2";
            // 
            // flpMain
            // 
            this.flpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpMain.Location = new System.Drawing.Point(0, 27);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(1029, 861);
            this.flpMain.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 888);
            this.Controls.Add(this.pnlDetection);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.flpMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Focasa";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlDetection.ResumeLayout(false);
            this.pnlDetection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsFolderManagement;
        private System.Windows.Forms.Panel pnlDetection;
        private System.Windows.Forms.Label lblDetectFolder;
        private System.Windows.Forms.PictureBox pbThumb;
        private System.Windows.Forms.Label lblDetectFile;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
    }
}

