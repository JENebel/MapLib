using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapLib
{
    public partial class ResetBtn : UserControl
    {
        private Graphics graphics;
        private bool hover, clicked;

        public ResetBtn()
        {
            InitializeComponent();
            ResetGraphics();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (clicked)
                graphics.DrawImage(Properties.Resources.ResetBtnTextureClicked, 0, 0, Width, Height);
            else if (hover)
                graphics.DrawImage(Properties.Resources.ResetBtnTextureHover, 0, 0, Width, Height);
            else
                graphics.DrawImage(Properties.Resources.ResetBtnTexture, 0, 0, Width, Height);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        { }

        private void ResetBtn_Resize(object sender, EventArgs e)
        {
            ResetGraphics();
        }

        private void ResetGraphics()
        {
            graphics = CreateGraphics();
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
        }

        private void ResetBtn_MouseEnter(object sender, EventArgs e)
        {
            hover = true;
            Invalidate();
        }
        private void ResetBtn_MouseLeave(object sender, EventArgs e)
        {
            hover = false;
            Invalidate();
        }
        private void ResetBtn_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            Invalidate();
        }
        private void ResetBtn_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
            Invalidate();
        }
    }
}
