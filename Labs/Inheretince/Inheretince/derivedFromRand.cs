using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDIDrawer;
using System.Drawing;
using System.Threading.Tasks;

namespace Inheretince
{
    class derivedFromRand : Random 
    {
        private int _max;
        public derivedFromRand(int max)
        {
            _max = max;
        }

        public Rectangle NextDrwerRect(CDrawer canvas)
        {
            if (canvas == null)
                throw new ArgumentException("Invalid canvas");
            canvas.AddRectangle()

        }
    }
}
