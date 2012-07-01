namespace vme
{
    partial class Canvas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.surface = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Location = new System.Drawing.Point(781, 3);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 576);
            this.vScrollBar.TabIndex = 3;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Location = new System.Drawing.Point(4, 582);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(775, 17);
            this.hScrollBar.TabIndex = 4;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // surface
            // 
            this.surface.Location = new System.Drawing.Point(3, 3);
            this.surface.Name = "surface";
            this.surface.Size = new System.Drawing.Size(776, 576);
            this.surface.TabIndex = 5;
            this.surface.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Surface_MouseDown);
            this.surface.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Surface_MouseMove);
            this.surface.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Surface_MouseUp);
            this.surface.MouseClick +=new System.Windows.Forms.MouseEventHandler(surface_MouseClick);
            // 
            // Canvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.surface);
            this.Controls.Add(this.vScrollBar);
            this.Name = "Canvas";
            this.Size = new System.Drawing.Size(800, 600);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Resize += new System.EventHandler(this.Canvas_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Panel surface;

    }
}
