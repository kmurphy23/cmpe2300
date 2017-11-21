using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace ICA08_Kaitlyn
{
    class rectDrawer : CDrawer
    {
        //an instance of our derived random class
        derivedFromRand rand;
        //make a list tothold the rectangles
        List<Rectangle> rectList = new List<Rectangle>();
        public rectDrawer(int width=800, int height=400) : base(width,height)
        {
            //set both cdrawers close together 
            Position = new Point((Position.X - 700), Position.Y);
            //initialize it with the base scales
            rand = new derivedFromRand(this.ScaledWidth / 5);
            //background colour to white 
            this.BBColour = Color.White;
            //go through and add 100 rectangles
            for (int i = 0; i < 100; i++)
            {
                //add retangles to list
                rectList.Add(rand.NextDrwerRect(this));
            }

            for(int i =0; i<100; i++)
            {
                this.AddRectangle(rectList[i], Color.Transparent, 1, Color.LightBlue);
            }
        }

        //clears the base and adds the new rectangles
        public new void Clear()
        {
            base.Clear();
            for (int i = 0; i < 100; i++)
            {
                this.AddRectangle(rectList[i], Color.Transparent, 1, Color.LightBlue);
            }
        }

        //render adds the text in the corner
        public new void Render()
        {
            this.AddText($"{this.ScaledWidth} x {this.ScaledHeight}: {this.GetType()}",10,0,0,300,50,Color.Red);
            base.Render();
        }
    }
}
