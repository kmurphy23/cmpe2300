using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICA16_Kaitlyn
{
    class Blob: BaseShape, IAnimatable
    {
        //var for the radius of our blob
        int Radius;
        Point Center;
        double animation;
        //then the CTOR
        public Blob(Point location, int raii): base(location, Color.Blue)
        {
            //set the values for the circle
            Radius = raii;
            Center = location;
            animation = 0;
        }

        //now we override move
        protected override Point VirtualMove()
        {
            //this is the point we will return cause we have too
            Center =  base.VirtualMove();
            return Center;
        }

        //noww we need to override the paint method
        protected override void VirtualPaint()
        {
            //this is setting the size based on the modulating shit
            int size = (int)(Radius * Math.Cos(animation)) / 2 + Radius;
            _canvas.AddCenteredEllipse(Center, size, size, Color.Blue);
        }
        
        //now we need the animate method from the IAnimatable
        public void Animate(CDrawer canvas)
        {
            //this method will make our ball pulse 
            //by adding one eighth of pi everytime
            animation += (Math.PI) / 8;
        }
    }
    //first is the Animation one
    interface IAnimatable
    {
        //this interface holds only one method
        //which returns nothing and accepts a drawer
        void Animate(CDrawer canvas);
    }
}
