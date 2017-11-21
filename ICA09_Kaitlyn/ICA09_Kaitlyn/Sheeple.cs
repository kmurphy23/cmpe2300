using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA09_Kaitlyn
{
    class Sheeple
    {
        static Random rand = new Random();
        public int TotalItems { get; private set; }
        public int Current { get; private set; }
        public Color SheepColor { get; private set; }

        public bool Done
        {
            get
            {
                return Current == 0;
            }
        }

        public void Process()
        {
            Current--;
        }

        public Sheeple()
        {
            TotalItems = rand.Next(2, 8);
            Current = TotalItems;
            SheepColor = RandColor.GetColor();
        }

        public void ShowSheeple(CDrawer canvas, Sheeple sheep, int x, int y)
        {
               canvas.AddRectangle(x, y, sheep.TotalItems, 1, SheepColor);
            if(x==0)
               canvas.AddText(Current.ToString(), 10, x, y, sheep.TotalItems, 1, Color.Black);
        }

    }
}
