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
    public partial class MapBox : UserControl
    {
        #region Fields
        private Bitmap mapImage;
        private Size baseMapSize;
        private Rectangle mapRect;
        private double widthHeightRatio;
        private int buttonSize;
        private bool dragging;
        private Point previousMouseLoc;
        private double pixelSize;
        #endregion

        #region Properties
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks the map")]
        public event MapClickEventHandler MapClick;
        public delegate void MapClickEventHandler(object sender, MapClickEventArgs e);

        public bool ResetViewOnNewImage { get; set; } = true;
        public int MapScale { get; private set; } = 1;
        public int MaxZoom { get; private set; } = 8;
        public Bitmap MapImage
        {
            get
            {
                return mapImage;
            }
            set
            {
                if (value != null)
                {
                    mapImage = value;
                    ResetRatio();
                    if (ResetViewOnNewImage)
                    {
                        ResetView();
                    }
                    else
                    {
                        Invalidate();
                    }
                }
            }
        }
        #endregion

        public MapBox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            MouseWheel += OnScroll;
        }

        private void MapBox_Load(object sender, EventArgs e)
        {
            ResetRatio();
            ResetView();
            SetBtnSize();
            Invalidate();
        }

        public void ResetView()
        {
            if (widthHeightRatio > (double)mapImage.Width / (double)mapImage.Height)
            {
                int width = (int)(double)(mapImage.Width * ((double)Height / (double)mapImage.Height));
                mapRect = new Rectangle((Width - width) / 2, 0, width, Height);
            }
            else
            {
                int height = (int)((double)mapImage.Height * ((double)Width / (double)mapImage.Width));
                mapRect = new Rectangle(0, (Height - height) / 2, Width, height);
            }
            baseMapSize = new Size(mapRect.Width, mapRect.Height);
            SetPixelSize();
            MapScale = 1;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.Clear(BackColor);
            {
                if (mapImage == null)
                {
                    resetViewBtn.Visible = false;
                    return;
                }
                else
                    resetViewBtn.Visible = true;

                e.Graphics.DrawImage(mapImage, mapRect);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        { }

        private void MapBox_Resize(object sender, EventArgs e)
        {
            ResetRatio();
            if (mapImage != null)
            {
                ResetView();
                SetBtnSize();
            }
        }

        private void SetBtnSize()
        {
            buttonSize = Math.Min(Width, Height) / 20;
            resetViewBtn.Width = buttonSize;
            resetViewBtn.Height = buttonSize;
            resetViewBtn.Location = new Point(Width - buttonSize - 3, Height - buttonSize - 3);
        }

        private void ResetRatio()
        {
            widthHeightRatio = (double)Width / (double)Height;
        }

        private void SetPixelSize()
        {
            pixelSize = (double)mapRect.Width / mapImage.Width;
        }

        private void MapBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    OnMapClick(sender, e);
                    break;
                case MouseButtons.Right:
                    OnMapClick(sender, e);
                    break;
                case MouseButtons.Middle:
                    dragging = true;
                    previousMouseLoc = e.Location;
                    break;
                default:
                    break;
            }
        }

        private void OnMapClick(object sender, MouseEventArgs e)
        {
            var loc = MouseToMapLocation(e);
            if (MapClick != null && MouseOverMap(e))
                MapClick(sender, new MapClickEventArgs(e.Button, (int)loc.X, (int)loc.Y));
        }

        private void MapBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {

                        break;
                    }
                case MouseButtons.Right:
                    {

                        break;
                    }
                case MouseButtons.Middle:
                    {
                        dragging = false;
                        break;
                    }
                default:
                    break;
            }
        }

        private void MapBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                mapRect.X += e.X-previousMouseLoc.X;
                mapRect.Y += e.Y-previousMouseLoc.Y;
                previousMouseLoc = e.Location;
                Invalidate();
            }
        }

        private void resetViewBtn_Click(object sender, EventArgs e)
        {
            ResetView();
        }

        private void OnScroll(object sender, MouseEventArgs e)
        {
            if (MouseOverMap(e))
            {
                if(e.Delta > 0)
                    Zoom(1, e);
                else
                    Zoom(-1, e);
            }
        }

        public void Zoom(int amount, MouseEventArgs e)
        {
            for (int i = 0; i < Math.Abs(amount); i++)
            {
                //Zoom in
                if (amount > 0 && MapScale * 2 <= MaxZoom)
                {
                    MapScale *= 2;

                    mapRect.Width = baseMapSize.Width * MapScale;
                    mapRect.Height = baseMapSize.Height * MapScale;

                    mapRect.X -= e.X - mapRect.X;
                    mapRect.Y -= e.Y - mapRect.Y;
                }
                //Zoom out
                else if (amount < 0 && 1 <= MapScale / 2)
                {
                    MapScale /= 2;

                    mapRect.Width = baseMapSize.Width * MapScale;
                    mapRect.Height = baseMapSize.Height * MapScale;

                    mapRect.X += (int)((e.X - mapRect.X) / 2);
                    mapRect.Y += (int)((e.Y - mapRect.Y) / 2);
                }
                else
                    break;
            }
            
            if (MapScale == 1)
            {
                ResetView();
            }
            else
            {
                SetPixelSize();
                Invalidate();
            }
        }

        private (double X, double Y) MouseToMapLocation(MouseEventArgs e)
        {
            return new ((e.X - mapRect.X)/pixelSize,
                        (e.Y - mapRect.Y)/pixelSize);
        }

        private bool MouseOverMap (MouseEventArgs e)
        {
            var loc = MouseToMapLocation(e);
            return loc.X >= 0
                && loc.Y >= 0
                && loc.X < mapImage.Width
                && loc.Y < mapImage.Height;
        }
    }
}