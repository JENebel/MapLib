namespace MapLib
{
    partial class ResetBtn
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
            this.SuspendLayout();
            // 
            // ResetBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Name = "ResetBtn";
            this.Size = new System.Drawing.Size(40, 40);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResetBtn_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ResetBtn_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ResetBtn_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResetBtn_MouseUp);
            this.Resize += new System.EventHandler(this.ResetBtn_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
