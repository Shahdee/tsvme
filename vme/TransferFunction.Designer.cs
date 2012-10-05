namespace vme
{
    partial class TransferFunction
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "TransferFunction";
            //-----
            this.Paint += new System.Windows.Forms.PaintEventHandler(TF_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TF_MouseClick);
            this.Size = new System.Drawing.Size(620, 350);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}