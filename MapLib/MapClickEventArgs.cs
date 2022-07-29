using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapLib
{
    public partial class MapClickEventArgs : EventArgs
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public MouseButtons Button { get; private set; }

        public MapClickEventArgs(MouseButtons button, int x, int y)
        {
            X = x;
            Y = y;
            Button = button;
        }
    }
}
