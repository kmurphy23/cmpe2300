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
        public static Random rand { get; set; }

        //these are the 4 readonly collections for up/down/left/right
        protected static readonly int[] Up = { 270, 590 };      //x starting location 
        protected static readonly int[] Down = { 170, 490 };    //x starting location
        protected static readonly int[] Left = { 164 };         //y starting location 
        protected static readonly int[] Right = { 260 };        //y starting location 

        //these are the protected int members for the x,y, coordinates width height and speed
        //all variables are named accordingly to what they represent 
        protected int XCoor;
        protected int YCoor;
        protected int Width;
        protected int Height;
        protected int Speed;

        //two protected bools for the max speed and half speed 
        //if true then we go full speed 
        //otherwise if false it goes half speed
        protected bool MaxSpeed;


        //Next after our initializtion of variables we have our CTORS
        //this will accept a width a speed, and a height for the car 
        public Car(int _width, int _height, int _speed)
        {
            //initialize the above speed to the one passed into the CTOR
            Speed = _speed;
            //same with the width 
            Width = _width;
            //and finally the height
            Height = _height;
            //we want the cars to start at full speed
            MaxSpeed = true;
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
    }
}
