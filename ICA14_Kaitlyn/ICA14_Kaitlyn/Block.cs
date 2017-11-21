using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaitlyn_Drawers;
using System.Drawing;
using GDIDrawer;

namespace ICA14_Kaitlyn
{
    class Block
    {
        //this will hold location and size info 
        protected RectangleF retang;

        //protected random object
        protected Random rand = new Random();


        //all of this is used to remove blocks
        public bool Outside
        {
            get;
            private set;
        }


        //ctor accepting a pointf that we will use to set
        //the x and y for our retang
        public Block(PointF point)
        {
            //setting x and y of the retang from out passed pointf
            retang.X = point.X;
            retang.Y = point.Y;
        }

        //override for if the two blocks intersect it returns true
        public override bool Equals(object obj)
        {
            //not a block return 
            if (!(obj is Block))
                return false;
            //cast as a block
            Block arg = obj as Block;
            //if the block IS the block return false
            //so you dont compare to yourseld
            if (ReferenceEquals(this, arg))
                return false;
            //return true if they intersect 
            //and youre not the block youre looking at
            return (retang.IntersectsWith(arg.retang));

        }

        public override int GetHashCode()
        {
            return 1;
        }

        //want the function empty simly so we can override it later
        //it needs to be virtual so we can override it
        virtual public void Move(List<Block> blList)
        {

        }

        //virtual so we can override it later
        virtual public void ShowBlock(CDrawer canvas)
        {
            //take the rectangle and copy it
            RectangleF copy = this.retang;
            //then inflate it by 3 each side
            copy.Inflate(3, 3);
            //add it to the canvas with all the demensions of the copied rectangle 
            //make sure its black
            canvas.AddRectangle((int)copy.X,(int)copy.Y,(int)copy.Width,(int)copy.Height, Color.Black);
            //if the rectangle is out of bounds on the y turn outside to true
            if (copy.X+copy.Width > canvas.ScaledWidth)
                Outside = true;
            //if the rectangle is out of bounds on the x turn outside true
            if (copy.Y +copy.Height > canvas.ScaledHeight)
                Outside = true;
        }
    }

    //this derived class will just have the block fall down 
    class FallingBlock : Block
    {
        const float Vel = 6;

        //ctor that will accept a point and using that point we call upon 
        //our base class with THAT SPECIFIC CTOR (aka the only CTOR we have for this)
        public FallingBlock(PointF point): base(point)
        {
            retang.Width = 50;
            retang.Height = 50;
        }

        //override for our empty move method
        public override void Move(List<Block> blList)
        {
            //if were outside we return and do nothing
            if (!Outside)
            {
                //else using a lambda we go throug each element and
                //if we dont intersect with anything then we increase our y position
                //by our velocity
                if (blList.TrueForAll(bl => !bl.Equals(this)))
                {
                    this.retang.Y += Vel;
                }
            }   
            
        }

        //override for show block
        public override void ShowBlock(CDrawer canvas)
        {
            //using the base canvas we created...
            base.ShowBlock(canvas);
            //we add a rectangle thats white and uses our protected values
            canvas.AddRectangle((int)retang.X, (int)retang.Y, (int)retang.Width, (int)retang.Height, Color.White);
        }

    } 


    //drunnk block
    class DrunkBlock: Block
    {
        //constant velocity
        const float Vel = 3;
        //lateral velocity
        float Lat = 0;
        //ctor that will accept a point and using that point we call upon 
        //our base class with THAT SPECIFIC CTOR (aka the only CTOR we have for this)
        public DrunkBlock(PointF point): base(point)
        {
            retang.Width = 30;
            retang.Height = 60;
        }

        //override for our empty move method
        public override void Move(List<Block> blList)
        {
            //if were outside we return and do nothing
            if (!Outside)
            {
                //else using a lambda we go throug each element and
                //if we dont intersect with anything then we increase our y position
                //by our velocity
                if (blList.TrueForAll(bl => !bl.Equals(this)))
                {
                    this.retang.Y += Vel;
                    //create the lat velocitry using a transfer func
                    Lat = (float)rand.NextDouble() * 2 - 1;
                    this.retang.X += Lat;

                }
            }

        }

        //override for show block
        public override void ShowBlock(CDrawer canvas)
        {
            //using the base canvas we created...
            base.ShowBlock(canvas);
            //we add a rectangle thats white and uses our protected values
            canvas.AddRectangle((int)retang.X, (int)retang.Y, (int)retang.Width, (int)retang.Height, Color.LightPink);
        }
    }


    class ColourBlock: Block
    {
        //initialize the velocity and random color
        const float Vel = 3;
        private Color col = RandColor.GetColor();

        //ctor that will accept a point and using that point we call upon 
        //our base class with THAT SPECIFIC CTOR (aka the only CTOR we have for this)
        public ColourBlock(PointF point): base(point)
        {
            retang.Width = 60;
            retang.Height = 30;
        }

        //override for our empty move method
        public override void Move(List<Block> blList)
        {
            //if were outside we return and do nothing
            if (!Outside)
            {
                //else using a lambda we go throug each element and
                //if we dont intersect with anything then we increase our y position
                //by our velocity
                if (blList.TrueForAll(bl => !bl.Equals(this)))
                {
                    this.retang.Y += Vel;
                }
            }

        }

        //override for show block
        public override void ShowBlock(CDrawer canvas)
        {
            //using the base canvas we created...
            base.ShowBlock(canvas);
            //we add a rectangle thats white and uses our protected values
            canvas.AddRectangle((int)retang.X, (int)retang.Y, (int)retang.Width, (int)retang.Height, col);
        }
    }
}
