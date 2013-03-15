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
            this.AssignCA = new System.Windows.Forms.Button();
            this.inkDialog = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDicom = new System.Windows.Forms.ToolStripMenuItem();
            this.openChest = new System.Windows.Forms.ToolStripMenuItem();
            this.openKid = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rOIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferFunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dICOMTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeReconstruction = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dICOMSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // inkDialog
            // 
            this.inkDialog.Color = System.Drawing.Color.OrangeRed;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.volumeReconstruction,
            this.toolsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openDicom,
            this.openChest,
            this.openKid,
            this.saveWorkspaceToolStripMenuItem,
            this.loadWorkspaceToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openFileToolStripMenuItem.Text = "Open study";
            // 
            // openDicom
            // 
            this.openDicom.Name = "openDicom";
            this.openDicom.Size = new System.Drawing.Size(162, 22);
            this.openDicom.Text = "Open file";
            this.openDicom.Click += new System.EventHandler(this.openDicom_Click);
            // 
            // openChest
            // 
            this.openChest.Name = "openChest";
            this.openChest.Size = new System.Drawing.Size(162, 22);
            this.openChest.Text = "Open my chest";
            this.openChest.Click += new System.EventHandler(this.openChest_Click);
            // 
            // openKid
            // 
            this.openKid.Name = "openKid";
            this.openKid.Size = new System.Drawing.Size(162, 22);
            this.openKid.Text = "Open kid\'s head ";
            this.openKid.Click += new System.EventHandler(this.openKid_Click);
            // 
            // saveWorkspaceToolStripMenuItem
            // 
            this.saveWorkspaceToolStripMenuItem.Name = "saveWorkspaceToolStripMenuItem";
            this.saveWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveWorkspaceToolStripMenuItem.Text = "Save workspace";
            // 
            // loadWorkspaceToolStripMenuItem
            // 
            this.loadWorkspaceToolStripMenuItem.Name = "loadWorkspaceToolStripMenuItem";
            this.loadWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.loadWorkspaceToolStripMenuItem.Text = "Load workspace";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presetsToolStripMenuItem,
            this.rOIToolStripMenuItem,
            this.transferFunctionToolStripMenuItem,
            this.hSVToolStripMenuItem,
            this.dICOMTagsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // presetsToolStripMenuItem
            // 
            this.presetsToolStripMenuItem.Name = "presetsToolStripMenuItem";
            this.presetsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.presetsToolStripMenuItem.Text = "Presets";
            // 
            // rOIToolStripMenuItem
            // 
            this.rOIToolStripMenuItem.Name = "rOIToolStripMenuItem";
            this.rOIToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.rOIToolStripMenuItem.Text = "ROI";
            // 
            // transferFunctionToolStripMenuItem
            // 
            this.transferFunctionToolStripMenuItem.Name = "transferFunctionToolStripMenuItem";
            this.transferFunctionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.transferFunctionToolStripMenuItem.Text = "Transfer Function";
            // 
            // hSVToolStripMenuItem
            // 
            this.hSVToolStripMenuItem.Name = "hSVToolStripMenuItem";
            this.hSVToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.hSVToolStripMenuItem.Text = "HSV palette";
            // 
            // dICOMTagsToolStripMenuItem
            // 
            this.dICOMTagsToolStripMenuItem.Name = "dICOMTagsToolStripMenuItem";
            this.dICOMTagsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.dICOMTagsToolStripMenuItem.Text = "DICOM tags";
            // 
            // volumeReconstruction
            // 
            this.volumeReconstruction.Name = "volumeReconstruction";
            this.volumeReconstruction.Size = new System.Drawing.Size(33, 20);
            this.volumeReconstruction.Text = "3D";
            this.volumeReconstruction.Click += new System.EventHandler(this.volumeReconstruction_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dICOMSettingsToolStripMenuItem,
            this.localSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // dICOMSettingsToolStripMenuItem
            // 
            this.dICOMSettingsToolStripMenuItem.Name = "dICOMSettingsToolStripMenuItem";
            this.dICOMSettingsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.dICOMSettingsToolStripMenuItem.Text = "DICOM settings";
            // 
            // localSettingsToolStripMenuItem
            // 
            this.localSettingsToolStripMenuItem.Name = "localSettingsToolStripMenuItem";
            this.localSettingsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.localSettingsToolStripMenuItem.Text = "Local settings";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vme";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageViewer view;
        private TransferFunction tf;
        private ROI roi;
        private Presets pr;
        private HSVpalette pl;
        private System.Windows.Forms.Button AssignCA;
        //private ColoredTF ColoredTFobj; // I dont need it anymore
        private System.Windows.Forms.ColorDialog inkDialog;
        private System.Windows.Forms.Button inkDialogButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openDicom;
        private System.Windows.Forms.ToolStripMenuItem openChest;
        private System.Windows.Forms.ToolStripMenuItem openKid;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeReconstruction;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rOIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferFunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dICOMTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dICOMSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localSettingsToolStripMenuItem;
        
    }
}

 