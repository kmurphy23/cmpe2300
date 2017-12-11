using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;
using Kaitlyn_Drawers;

namespace Lab03_Kaitlyn
{
    public partial class Form1 : Form
    {
        
        //create an instance of our canvas
        picClass canvas;
        //Create a list to hold all of our cars
        List<Car> CarList;
        //Game score
        int score;
        public Form1()
        {
            InitializeComponent();
            //create the canvas with our image as the background
            canvas = new picClass(Properties.Resources.Crash,false,true);
            //set the canvas from the car class to the canvas from here
            Car.canvas = canvas;
            //initialize the score to 0
            score = 0;
            //initialize our list of cars
            CarList = new List<Car>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void CarSpawn_Tick(object sender, EventArgs e)
        {
            //just create a dummy car 
            Car temp = null;

            //Pick a random car with a random speed
            switch (Car.rand.Next(4))
            {
                case 0:
                    temp = new VSedan(4);
                    break;
                case 1:
                    temp = new VSedan(-4);
                    break;
                case 2:
                    temp = new HAmbulance(7);
                    break;
                case 3:
                    temp = new HAmbulance(-7);
                    break;
            }

            //if the list is not null we add the car
            CarList?.Add(temp);
            //then we decrease the timer 
            if (CarSpawn.Interval > 1000)
                CarSpawn.Interval -= 10;
        }

        private void GameTime_Tick(object sender, EventArgs e)
        {
            if(canvas == null || CarList == null)
            {
                return;
            }

            Point mouseClick;
            if (canvas.GetLastMouseLeftClick(out mouseClick)) ;
        }
    }
}
