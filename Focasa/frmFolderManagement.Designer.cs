namespace Focasa
{
    partial class frmFolderManagement
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
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAlways = new System.Windows.Forms.RadioButton();
            this.rbNever = new System.Windows.Forms.RadioButton();
            this.rbOnce = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMonitoredFolders = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFaceRecognition = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvFolders
            // 
            this.tvFolders.HideSelection = false;
            this.tvFolders.Location = new System.Drawing.Point(12, 12);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(289, 406);
            this.tvFolders.TabIndex = 0;
            this.tvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Monitor folder activity:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAlways);
            this.groupBox1.Controls.Add(this.rbNever);
            this.groupBox1.Controls.Add(this.rbOnce);
            this.groupBox1.Location = new System.Drawing.Point(341, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 142);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rbAlways
            // 
            this.rbAlways.AutoSize = true;
            this.rbAlways.Location = new System.Drawing.Point(11, 103);
            this.rbAlways.Name = "rbAlways";
            this.rbAlways.Size = new System.Drawing.Size(58, 17);
            this.rbAlways.TabIndex = 2;
            this.rbAlways.TabStop = true;
            this.rbAlways.Text = "Always";
            this.rbAlways.UseVisualStyleBackColor = true;
            this.rbAlways.CheckedChanged += new System.EventHandler(this.rbAlways_CheckedChanged);
            // 
            // rbNever
            // 
            this.rbNever.AutoSize = true;
            this.rbNever.Location = new System.Drawing.Point(11, 67);
            this.rbNever.Name = "rbNever";
            this.rbNever.Size = new System.Drawing.Size(54, 17);
            this.rbNever.TabIndex = 1;
            this.rbNever.TabStop = true;
            this.rbNever.Text = "Never";
            this.rbNever.UseVisualStyleBackColor = true;
            this.rbNever.CheckedChanged += new System.EventHandler(this.rbNever_CheckedChanged);
            // 
            // rbOnce
            // 
            this.rbOnce.AutoSize = true;
            this.rbOnce.Location = new System.Drawing.Point(11, 31);
            this.rbOnce.Name = "rbOnce";
            this.rbOnce.Size = new System.Drawing.Size(51, 17);
            this.rbOnce.TabIndex = 0;
            this.rbOnce.TabStop = true;
            this.rbOnce.Text = "Once";
            this.rbOnce.UseVisualStyleBackColor = true;
            this.rbOnce.CheckedChanged += new System.EventHandler(this.rbOnce_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Monitored folders:";
            // 
            // lbMonitoredFolders
            // 
            this.lbMonitoredFolders.FormattingEnabled = true;
            this.lbMonitoredFolders.Location = new System.Drawing.Point(341, 336);
            this.lbMonitoredFolders.Name = "lbMonitoredFolders";
            this.lbMonitoredFolders.Size = new System.Drawing.Size(254, 82);
            this.lbMonitoredFolders.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFaceRecognition);
            this.groupBox2.Location = new System.Drawing.Point(341, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 54);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // chkFaceRecognition
            // 
            this.chkFaceRecognition.AutoSize = true;
            this.chkFaceRecognition.Enabled = false;
            this.chkFaceRecognition.Location = new System.Drawing.Point(11, 24);
            this.chkFaceRecognition.Name = "chkFaceRecognition";
            this.chkFaceRecognition.Size = new System.Drawing.Size(105, 17);
            this.chkFaceRecognition.TabIndex = 0;
            this.chkFaceRecognition.Text = "Face recognition";
            this.chkFaceRecognition.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(520, 448);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmFolderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 495);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbMonitoredFolders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvFolders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFolderManagement";
            this.Text = "Folder Management";
            this.Load += new System.EventHandler(this.frmFolderManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAlways;
        private System.Windows.Forms.RadioButton rbNever;
        private System.Windows.Forms.RadioButton rbOnce;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbMonitoredFolders;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkFaceRecognition;
        private System.Windows.Forms.Button btnOK;
    }
}