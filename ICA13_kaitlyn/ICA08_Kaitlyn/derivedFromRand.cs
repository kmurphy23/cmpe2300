using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace ICA08_Kaitlyn
{
    class derivedFromRand : Random
    {

        private readonly int _max;
        public derivedFromRand(int max)
        {
            _max = max;
        }

        public Rectangle NextDrwerRect(CDrawer canvas)
        {
            //temp max size
            int temp;
            //if canvas is null throw an acception 
            if (canvas == null)
                throw new ArgumentException("Invalid canvas");
            //if the max is too big we set it to the temp one
            temp = _max;
            //if max is too big we set it to the temp modified
            if (_max > canvas.m_ciWidth)
                temp = canvas.m_ciWidth;
            if (_max > canvas.m_ciHeight)
                temp = canvas.m_ciHeight;
            //set the x and y using the MODIFIED max(temp)
            int x = this.Next(10, temp + 1);
            int y = this.Next(10, temp + 1);
            //create the size based on the two ponts from above
            Size s = new Size(x, y);
            //create a point based on the scaled height and width
            int xPos = this.Next(canvas.m_ciWidth - x);
            int yPos = this.Next(canvas.m_ciHeight - y);
            Point p = new Point(xPos, yPos);
            //create and return the retangle
            Rectangle retang = new Rectangle(p, s);
            return retang;

        }
    }
}
