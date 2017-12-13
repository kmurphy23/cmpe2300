using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using Kaitlyn_Drawers;

namespace Lab03_Kaitlyn
{
    /// <summary>
    /// intrface to determine whether we can animate the car
    /// </summary>
    interface IAnimateable
    {
        /// <summary>
        /// Changes data to animae our car
        /// </summary>
        void Animate();
    }
    abstract class Car
    {
        //create a private static member for the get set property
        private static picClass _canvas;
        //static refernce with get property close pic drawer and oprn a new one
        public static picClass canvas
        {
            //the property method wants a normal get...
            get
            {
                //which will return the canvas
                return _canvas;
            }
            //..but the set will close the picDrawer if there is one 
            set
            {
                //if the canvas exsist close it 
                _canvas?.Close();
                //then set the canvas to the passed value
                _canvas = value;
            }
        }
        // public random static member to be used througout the class
        //this is anautomatci get set property
        public static Random rand { get; set; } = new Random();

        //these are the 4 readonly collections for up/down/left/right
        protected static readonly int[] Up = { 270, 590 };      //x starting location 
        protected static readonly int[] Down = { 170, 490 };    //x starting location
        protected static readonly int[] Left = { 164 };         //y starting location 
        protected static readonly int[] Right = { 260 };        //y starting location 

        //these are the protected int members for the x,y, coordinates width height and speed
        //all variables are named accordingly to what they represent 
        protected float XCoor;
        protected float YCoor;
        protected int Width;
        protected int Height;
        protected float Speed;
        protected Color CarCol;

        //two protected bools for the max speed and half speed 
        //if true then we go full speed 
        //otherwise if false it goes half speed
        protected bool MaxSpeed;


        //Next after our initializtion of variables we have our CTORS
        //this will accept a width a speed, and a height for the car 
        public Car(float _speed, int _width, int _height, Color col)
        {
            //initialize the above speed to the one passed into the CTOR
            Speed = _speed;
            //same with the width 
            Width = _width;
            //and finally the height
            Height = _height;
            //we want the cars to start at full speed
            MaxSpeed = true;
            //we want the color of the car to be what we passed it
            CarCol = col;
        }

        ///we will derive this at another time 
        ///
        /// <returns> a rectangle that will be the car </returns>
        public abstract Rectangle GetRect();

        /// the virtual method to show the car which will be overriden later
        /// by the regular show method
        /// </summary>
        protected abstract void VShowCar();

        /// <summary>
        /// ShowCar simply calls the virtual method for show car 
        /// </summary>
        public void ShowCar()
        {
            VShowCar();
        }


        /// the virtual method to move the car which will be overriden later
        /// by the regular move method
        /// </summary>
        protected abstract void VMoveCar();

        /// <summary>
        /// ShowCar simply calls the virtual method for show car 
        /// </summary>
        public void MoveCar()
        {
            VMoveCar();
        }


        public override bool Equals(object obj)
        {
            //if the obj passed into the override is not a car or it is itself we will set it to false
            if (!(obj is Car) || this == obj)
                return false;
            //cast the obj as a car 
            Car arg = obj as Car;
            //compare the 2 cars using intersects with
            return GetRect().IntersectsWith(arg.GetRect());

        }

        //we need the override hashcode to use the equals override
        public override int GetHashCode()
        {
            return 0;
        }

        ///this method will return true if the point is whithin the cars rectangle
        /// <param name="p"> point p is the point we are looking to see if it is in the rectangle</param>
        /// <returns> true if he point IS in the rectangle</returns>
        public bool PointOnCar(Point p)
        {
            //returns true if the rectangle has this point
            return GetRect().Contains(p);
        }

        /// <summary>
        /// This method checks if the car is out of bounds 
        /// returns true if the car is outside of the drawer 
        /// </summary>
        /// <param name="c">the car we are passing into the method to see if it is inside or outside the bounds of teh drawer </param>
        /// <returns>true or false based on whether or not the car is in or out of bounds</returns>
        public static bool OutOfBounds(Car c)
        {
            //create a temporary car that we will see if it intersects with 
            Rectangle inBounds = new Rectangle(0, 0, canvas.ScaledWidth, canvas.ScaledHeight);
            //check to see if the car drives out of the screen
            return !c.GetRect().IntersectsWith(inBounds);
        }

        /// <summary>
        /// uses the maxSpeed bool to toggle between max and half speed
        /// </summary>
        public void ToggleSpeed()
        {
            //new maxSpeed is the opposite of the old maxSpeed this will make it toggle
            MaxSpeed = !MaxSpeed;
        }

        /// <summary>
        /// GetSafeScore - Get the score of the car when it exits the screen
        /// </summary>
        /// <returns>The score of the car</returns>
        public abstract int GetSafeScore();

        
        /// <summary>
        /// GetHitScore - Get the score of the car when it hits another car
        /// </summary>
        /// <returns>The negative score of the car</returns>
        public abstract int GetHitScore();
    }


    //now we need to derive an abstract class for directional cars
    //HorizontalCar is derived from our car class which we will use to drive cars horizontally
    abstract class HorizontalCar: Car
    {
        //now we add a CTOR that will take the arguements of speed width and height
        /// <summary>
        /// Creates a horizontal moving car
        /// </summary>
        /// <param name="Speed">The horizontal speed of the car</param>
        /// <param name="Width">The width of the car</param>
        /// <param name="Height">the height of the car </param>
        /// <param name="Col">and the colour of the car</param>
        public HorizontalCar(float Speed, int Width, int Height, Color Col): base(Speed,Width,Height,Col)
        {
            //if the speed is negative then were going left
            if(Speed < 0)
            {
                //we need to start outside of the right side of the screen
                XCoor = canvas.ScaledWidth;
                //we set the y coordinates to a random selection of the left array 
                YCoor = Right[rand.Next(Left.Length)];
            }
            //else if the speed is positive we are going right
            else if(Speed > 0)
            {
                //set the xcoor too just outside the left side of the canvas
                XCoor = 0 - Width;
                //set the y to a random left right position form the array
                YCoor = Right[rand.Next(Right.Length)];
            }
        }


        /// <summary>
        /// we are moving horizontally so we increment x by our speed
        /// </summary>
        protected override void VMoveCar()
        {
            //if the maxspeed is true we increment by our full speed
            if(MaxSpeed)
                XCoor += Speed;
            //else we increment by half our speed
            else
                XCoor += Speed/2;

        }
    }

    /// <summary>
    /// A derived vertical moving class derived from car
    /// </summary>
    abstract class VerticalCar: Car
    {
        /// <summary>
        /// Creates a horizontal moving car
        /// </summary>
        /// <param name="Speed">The horizontal speed of the car</param>
        /// <param name="Width">The width of the car</param>
        /// <param name="Height">the height of the car </param>
        /// <param name="Col">and the colour of the car</param>
        public VerticalCar(float Speed, int Width, int Height, Color Col): base(Speed,Width,Height,Col)
        {
            //if the speed is negative then were going up
            if (Speed < 0)
            {
                //we want the car to move up usig a random value from the array
                XCoor = Up[rand.Next(Up.Length)];
                //we set the y coordinates to the scaled height
                YCoor = canvas.ScaledHeight;
            }
            //else if the speed is positive we are going down
            else if (Speed > 0)
            {
                //set the car to be moving down
                XCoor = Down[rand.Next(Down.Length)];
                //set the car out of the screen
                YCoor = 0 - Height;
            }
        }

        /// <summary>
        /// since we are going vertically we increment our y by our speed
        /// </summary>
        protected override void VMoveCar()
        {
            //if the maxspeed is true we increment by our full speed
            if (MaxSpeed)
                YCoor += Speed;
            //else we increment by half our speed
            else
                YCoor += Speed / 2;
        }
    }

    /// <summary>
    /// car that moves vertically initialized to a random color
    /// </summary>
    class VSedan : VerticalCar
    {
        //protected color memeber which is the colour of the body of the car
        protected Color col = RandColor.GetColor();
        /// <summary>
        /// derived from the base vertical class
        /// </summary>
        /// <param name="speed">initializes the speed of the car</param>
        /// <param name="width">initializes the width of the car </param>
        /// <param name="height">and finally the height of the car</param>
        public VSedan(float speed = 4, int width = 40, int height = 70) : base(speed, width, height,Color.AliceBlue) { }

        /// <summary>
        /// override of the getrect method that will create the x and y of the car
        /// </summary>
        /// <returns> returns the new rectangle</returns>
        public override Rectangle GetRect()
        {
            return new Rectangle((int)XCoor, (int)YCoor, Width, Height);
        }


        /// <summary>
        /// will show our sedan car 
        /// </summary>
        protected override void VShowCar()
        {
            //get a box that will be our 'hitbox'
            Rectangle hitBox = GetRect();
            //add the car wit hte body and the color
            canvas.AddRectangle(hitBox, col);
        }

        /// <summary>
        /// When the car reaches the other side it increases the  
        /// safe score of the game
        /// </summary>
        /// <returns> returns the int that is the score</returns>
        public override int GetSafeScore()
        {
            return Math.Abs((int)Speed);
        }

        /// <summary>
        /// if the car is hit on the way out of the game the we will 
        /// decrease the score of the game
        /// </summary>
        /// <returns>returns the negative of the score</returns>
        public override int GetHitScore()
        {
            return GetSafeScore() * -1;
        }
    }

    class HAmbulance : HorizontalCar, IAnimateable
    {
        //colors on top of the car 
        Color light1 = Color.Blue;
        Color light2 = Color.Red;
        /// <summary>
        /// derived from the base vertical class
        /// </summary>
        /// <param name="speed">initializes the speed of the car</param>
        /// <param name="width">initializes the width of the car </param>
        /// <param name="height">and finally the height of the car</param>
        public HAmbulance(float speed = 7, int width = 90, int height = 40) : base(speed, width, height,Color.White) { }


        /// <summary>
        /// override of the getrect method that will create the x and y of the car
        /// </summary>
        /// <returns> returns the new rectangle</returns>
        public override Rectangle GetRect()
        {
            return new Rectangle((int)XCoor, (int)YCoor, Width, Height); ;
        }

        protected override void VShowCar()
        {
            //get a box that will be our 'hitbox'
            Rectangle hitBox = GetRect();
            //add the car wit hte body and the color
            canvas.AddRectangle(hitBox, Color.White);
            //Add the animated lights
            canvas.AddRectangle(hitBox.X + Width / 2 - 2, hitBox.Y, 4, Height / 2, light1);
            canvas.AddRectangle(hitBox.X + Width / 2 - 2, hitBox.Y + Height / 2, 4, Height / 2, light2);
        }


        //will swap the light colours
        public void Animate()
        {
            //flip flop the colours
            if(light1 == Color.Blue)
            {
                light1 = Color.Red;
                light2 = Color.Blue;
            }
            //flip flop the colours
            else
            {
                light1 = Color.Blue;
                light2 = Color.Red;
            }
        }

        /// <summary>
        /// When the car reaches the other side it increases the  
        /// safe score of the game
        /// </summary>
        /// <returns> returns the int that is the score</returns>
        public override int GetSafeScore()
        {
            return Math.Abs((int)Speed);
        }

        /// <summary>
        /// if the car is hit on the way out of the game the we will 
        /// decrease the score of the game
        /// </summary>
        /// <returns>returns the negative of the score</returns>
        public override int GetHitScore()
        {
            return GetSafeScore() * -1;
        }
    }
}
