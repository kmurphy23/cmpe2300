using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace Inheretince
{
    class picClass: CDrawer
    {
        
        

        //default constructor that makes the base canvas size based on the image sent in
        public picClass() : base(Properties.Resources.persian_cats_and_kittens_1.Width,Properties.Resources.persian_cats_and_kittens_1.Height)
        {
            //initialize a bitmap with the same properties as the resource image
            Bitmap map = new Bitmap(Properties.Resources.persian_cats_and_kittens_1);
            //goes through each pixel on the width
            for (int x=0; x < ScaledWidth; x++)
            {
                //go through each pixel in the height
                for(int y=0; y<ScaledHeight; y++)
                {
                    //get the old colour of each pics
                    Color c = map.GetPixel(x, y);
                    //find the average colour(this will give us the gray colour)
                    int avg = (c.R + c.B + c.G)/3;
                    //set that image to the new colour version of it
                    SetBBPixel(x, y,Color.FromArgb(avg,avg,avg));
                }
            }
        }
    }
}
