using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace ICA10_Kaitlyn
{
    public static class MyLibrary
    {

        public static List<Point> Shuffle(this List<Point> ArgList)
        {
            Random rand = new Random();
            List<Point> newList = new List<Point>(ArgList);

            int r = newList.Count;
            for(int i=0; i<r; i++)
            {
                int swap = i+rand.Next(r-i);
                Point temp = newList[swap];
                newList[swap] = newList[i];
                newList[i] = temp;
            }

            return newList;
        }
    }
}
