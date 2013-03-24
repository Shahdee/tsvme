namespace vme
{
    partial class Main
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
            this.Reset = new System.Windows.Forms.Button();
            this.AssignCA = new System.Windows.Forms.Button();
            this.image_label = new System.Windows.Forms.Label();
            this.backward = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.inkDialog = new System.Windows.Forms.ColorDialog();
            this.inkButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openDicom = new System.Windows.Forms.ToolStripMenuItem();
            this.openChest = new System.Windows.Forms.ToolStripMenuItem();
            this.openKid = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeReconstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.ColoredTFobj = new vme.ColoredTF();
            this.Windowing = new vme.Windowing();
            this.ImagePlane = new vme.Canvas();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(416, 39);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(95, 35);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "Default ROI";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // AssignCA
            // 
            this.AssignCA.Location = new System.Drawing.Point(1073, 21);
            this.AssignCA.Name = "AssignCA";
            this.AssignCA.Size = new System.Drawing.Size(118, 35);
            this.AssignCA.TabIndex = 13;
            this.AssignCA.Text = "Присвоить ц/п";
            this.AssignCA.UseVisualStyleBackColor = true;
            // 
            // image_label
            // 
            this.image_label.AutoSize = true;
            this.image_label.Location = new System.Drawing.Point(659, 30);
            this.image_label.Name = "image_label";
            this.image_label.Size = new System.Drawing.Size(63, 13);
            this.image_label.TabIndex = 8;
            this.image_label.Text = "Image path:";
            // 
            // backward
            // 
            this.backward.Location = new System.Drawing.Point(581, 110);
            this.backward.Name = "backward";
            this.backward.Size = new System.Drawing.Size(75, 36);
            this.backward.TabIndex = 10;
            this.backward.Text = "Backward";
            this.backward.UseVisualStyleBackColor = true;
            this.backward.Click += new System.EventHandler(this.backward_Click);
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(581, 162);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(75, 36);
            this.forward.TabIndex = 11;
            this.forward.Text = "Forward";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // inkDialog
            // 
            this.inkDialog.Color = System.Drawing.Color.OrangeRed;
            // 
            // inkButton
            // 
            this.inkButton.Location = new System.Drawing.Point(1126, 30);
            this.inkButton.Name = "inkButton";
            this.inkButton.Size = new System.Drawing.Size(75, 30);
            this.inkButton.TabIndex = 13;
            this.inkButton.Text = "Ink ";
            this.inkButton.UseVisualStyleBackColor = true;
            this.inkButton.Click += new System.EventHandler(this.inkButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.volumeReconstruction});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1213, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDicom,
            this.openChest,
            this.openKid});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openDicom
            // 
            this.openDicom.Name = "openDicom";
            this.openDicom.Size = new System.Drawing.Size(164, 22);
            this.openDicom.Text = "Open DICOM file";
            this.openDicom.Click += new System.EventHandler(this.openDicom_Click);
            // 
            // openChest
            // 
            this.openChest.Name = "openChest";
            this.openChest.Size = new System.Drawing.Size(164, 22);
            this.openChest.Text = "Open my chest";
            this.openChest.Click += new System.EventHandler(this.openChest_Click);
            // 
            // openKid
            // 
            this.openKid.Name = "openKid";
            this.openKid.Size = new System.Drawing.Size(164, 22);
            this.openKid.Text = "Open kid\'s head ";
            this.openKid.Click += new System.EventHandler(this.openKid_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // volumeReconstruction
            // 
            this.volumeReconstruction.Name = "volumeReconstruction";
            this.volumeReconstruction.Size = new System.Drawing.Size(33, 20);
            this.volumeReconstruction.Text = "3D";
            this.volumeReconstruction.Click += new System.EventHandler(this.volumeReconstruction_Click);
            // 
            // ColoredTFobj
            // 
            this.ColoredTFobj.BackColor = System.Drawing.SystemColors.Control;
            this.ColoredTFobj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColoredTFobj.Location = new System.Drawing.Point(27, 266);
            this.ColoredTFobj.Name = "ColoredTFobj";
            this.ColoredTFobj.Size = new System.Drawing.Size(620, 350);
            this.ColoredTFobj.TabIndex = 6;
            // 
            // Windowing
            // 
            this.Windowing.BackColor = System.Drawing.SystemColors.Control;
            this.Windowing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Windowing.Location = new System.Drawing.Point(27, 80);
            this.Windowing.Name = "Windowing";
            this.Windowing.Size = new System.Drawing.Size(484, 180);
            this.Windowing.TabIndex = 5;
            // 
            // ImagePlane
            // 
            this.ImagePlane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePlane.Location = new System.Drawing.Point(662, 64);
            this.ImagePlane.Name = "ImagePlane";
            this.ImagePlane.Size = new System.Drawing.Size(539, 539);
            this.ImagePlane.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 640);
            this.Controls.Add(this.inkButton);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.backward);
            this.Controls.Add(this.image_label);
            this.Controls.Add(this.ColoredTFobj);
            this.Controls.Add(this.Windowing);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.ImagePlane);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vme";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Canvas ImagePlane;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button AssignCA;
        private Windowing Windowing;
        private ColoredTF ColoredTFobj;
        private System.Windows.Forms.Label image_label;
        private System.Windows.Forms.Button backward;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.ColorDialog inkDialog;
        private System.Windows.Forms.Button inkDialogButton;
        private System.Windows.Forms.Button inkButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openDicom;
        private System.Windows.Forms.ToolStripMenuItem openChest;
        private System.Windows.Forms.ToolStripMenuItem openKid;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeReconstruction;
        
    }
}

 