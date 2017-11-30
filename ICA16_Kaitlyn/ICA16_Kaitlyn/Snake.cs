using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ICA16_Kaitlyn
{
    class Snake : BaseShape, IMortal
    {
        //creates a new linked list of points
        LinkedList<Point> PointList = new LinkedList<Point>();
        //new length memeber and arguement in CTOR
        int Length;
        int life;
        public Snake(Point location, int len) : base(location, Color.Red)
        {
            Length = len;
            //add the number for the life of the snake
            life = (10 * Length);
            PointList.AddFirst(location);
        }

        //override for the virtual move
        protected override Point VirtualMove()
        {
            //take the returned value for the virtual point and add it to 
            //the first of our linked list
            Point temp = base.VirtualMove();
            PointList.AddFirst(temp);
            //if our list is longer than our length
            if(PointList.Count > Length)
            {
                //take off the last point
                PointList.RemoveLast();
            }
            return temp;
        }

        //override of the paint method
        protected override void VirtualPaint()
        {
            //add the first value of our list to the cnavas with a size of 3
            //and color of red
            _canvas.AddCenteredEllipse(PointList.First.Value, 3, 3, Color.Red);
            //go through each point 
            LinkedListNode<Point> node;
            float CountDown =Length;
            for (node = PointList.First; node.Next!=null; node=node.Next)
            {
                //add the tail of the snek
                //which goes from the first node to the next node 
                //then we add the color and an a value which counts down 
                _canvas.AddLine(node.Value.X, node.Value.Y, node.Next.Value.X, node.Next.Value.Y, Color.FromArgb((int)(255 * CountDown / Length), _color));
                CountDown--;
            }
        }
        public bool Step()
        {
            //returns true if it is greater than 0 it will decrement and return 
            return life-- > 0;
        }
    }
    //second one is the mortal 
    interface IMortal
    {
        //this is the method for the interface that will return a bool
        //but accepts no arguements
        bool Step();
    }

}
