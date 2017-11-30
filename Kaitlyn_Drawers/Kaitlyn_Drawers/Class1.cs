using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;


namespace Kaitlyn_Drawers
{
    public class derivedFromRand : Random
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


    public class rectDrawer : CDrawer
    {
        //an instance of our derived random class
        derivedFromRand rand;

        public rectDrawer() : base(800, 400)
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
                //add retangles using our derived from rand and a random color
                AddRectangle(rand.NextDrwerRect(this), RandColor.GetColor());
            }
        }
    }

    public class picClass : CDrawer
    {
        
        //default constructor that makes the base canvas size based on the image sent in
        public picClass(Bitmap image,bool Gray, bool bCountinousUpdate =false) : base(image.Width,image.Height,bCountinousUpdate)
        {
            //goes through each pixel on the width
            for (int x = 0; x < ScaledWidth; x++)
            {
                //go through each pixel in the height
                for (int y = 0; y < ScaledHeight; y++)
                {
                    //get the old colour of each pics
                    Color c = image.GetPixel(x, y);
                    if (Gray)
                    {
                        //find the average colour(this will give us the gray colour)
                        int avg = (c.R + c.B + c.G) / 3;
                        c = Color.FromArgb(avg, avg, avg);
                        //set that image to the new colour version of it
                    }
                    //otherwise the color as the color
                    SetBBPixel(x, y,c);
                }
            }

            Render();
        }

        public new void Render()
        {
            AddText($"{ScaledWidth} x {ScaledHeight} : {this.GetType().ToString()}", 10, 0, 0, 300, 50, Color.Red);
            base.Render();
        }
    }


}
