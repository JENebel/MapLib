namespace MapLib
{
    partial class MapBox
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
            this.resetViewBtn = new MapLib.ResetBtn();
            this.SuspendLayout();
            // 
            // resetViewBtn
            // 
            this.resetViewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetViewBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetViewBtn.Location = new System.Drawing.Point(285, 154);
            this.resetViewBtn.Margin = new System.Windows.Forms.Padding(1);
            this.resetViewBtn.Name = "resetViewBtn";
            this.resetViewBtn.Size = new System.Drawing.Size(28, 24);
            this.resetViewBtn.TabIndex = 0;
            this.resetViewBtn.Click += new System.EventHandler(this.resetViewBtn_Click);
            // 
            // MapBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.resetViewBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MapBox";
            this.Size = new System.Drawing.Size(315, 180);
            this.Load += new System.EventHandler(this.MapBox_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapBox_MouseUp);
            this.Resize += new System.EventHandler(this.MapBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ResetBtn resetViewBtn;
    }
}
