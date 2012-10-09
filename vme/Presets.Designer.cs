namespace vme
{
    partial class Presets
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
            this.presetDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.presetWatcher = new System.IO.FileSystemWatcher();
            this.presetTree = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.presetWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // presetWatcher
            // 
            this.presetWatcher.EnableRaisingEvents = true;
            this.presetWatcher.SynchronizingObject = this;
            // 
            // presetTree
            // 
            this.presetTree.Location = new System.Drawing.Point(12, 12);
            this.presetTree.Name = "presetTree";
            this.presetTree.Size = new System.Drawing.Size(370, 97);
            this.presetTree.TabIndex = 0;
            // 
            // Presets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 122);
            this.Controls.Add(this.presetTree);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(50, 0);
            this.MaximizeBox = false;
            this.Name = "Presets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Presets";
            ((System.ComponentModel.ISupportInitialize)(this.presetWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog presetDialog;
        private System.IO.FileSystemWatcher presetWatcher;
        private System.Windows.Forms.TreeView presetTree;

    }
}