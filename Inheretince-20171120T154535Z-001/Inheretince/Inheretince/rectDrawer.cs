using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Inheretince
{
    class rectDrawer: CDrawer
    {
        //an instance of our derived random class
        derivedFromRand rand;

        public rectDrawer():base(800,400)
        {
            //set both cdrawers close together 
            Position = new Point((Position.X - 700), Position.Y);
            //initialize it with the base scales
            rand = new derivedFromRand(this.ScaledWidth / 5);
            //background colour to white 
            this.BBColour = Color.White;

            //go through and add 100 rectangles
            for(int i =0; i<100; i++)
            {
                //add retangles using our derived from rand and a random color
              AddRectangle(rand.NextDrwerRect(this),RandColor.GetColor());
            }
        }
    }
}
