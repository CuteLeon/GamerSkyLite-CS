using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamerSkyLite_CS.Controls
{
    class PanelEx:Panel
    {
        public PanelEx()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint, true);
            UpdateStyles();
        }
    }
}
