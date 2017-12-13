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
        //this is where all of the initializatons here
        public Form1()
        {
            InitializeComponent();
            //create the canvas with our image as the background
            canvas = new picClass(Properties.Resources.Crash, false, true);
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
            switch (Car.rand.Next(8))
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
                case 4:
                    temp = new FireTruck(9);
                    break;
                case 5:
                    temp = new FireTruck(-9);
                    break;
                case 6:
                    temp = new SmartCar(8);
                    break;
                case 7:
                    temp = new SmartCar(-8);
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
            //if the canvas or the car list is null we cant do anything
            if (canvas == null || CarList == null)
            {
                //just return we cant do anything
                return;
            }
            //create a point that we will put the ouse click into
            Point mouseClick;
            //if we click on the canvas then we check to see if we clicked on the car 
            if (canvas.GetLastMouseLeftClick(out mouseClick))
            {
                //now that we have a mouseclick check if its on a car
                CarList.ForEach(car => { if (car.PointOnCar(mouseClick)) car.ToggleSpeed(); });
            }

            //move each car
            CarList.ForEach(car => car.MoveCar());

            //create a temporary car to compare too
            Car temp;
            //go through each car in the list 
            foreach (Car Vech in CarList.ToList())
            {

                if (CarList.Contains(Vech))
                {
                    //get the car you hit
                    temp = CarList[CarList.IndexOf(Vech)];
                    //decrease score 
                    score += (Vech.GetHitScore() + temp.GetHitScore());
                    //remove the cars from the list
                    CarList.RemoveAll(carin => object.ReferenceEquals(carin, Vech));
                    CarList.RemoveAll(input => object.ReferenceEquals(input, temp));
                }

                if (Car.OutOfBounds(Vech))
                {
                    //if the car made it safely then increase the score
                    score += Vech.GetSafeScore();
                    //remove the car 
                    CarList.RemoveAll(input => object.ReferenceEquals(input, Vech));
                }
            }
            //write the score the form text 
            Text = $"Score = {score} points";

            //Animate all the cars that support IAnimatable
            CarList.ForEach(car => (car as IAnimateable)?.Animate());

            //Clear and render all the cars
            canvas.Clear();
            CarList.ForEach(car => car.ShowCar());
            canvas.Render();

            //End the game if score is too low
            if (score < 0)
            {
                //clear the canvas 
                canvas.Clear();
                //add text to the canvas
                canvas.AddText("Game Over", 35, Color.Red);
                //render just the text
                canvas.Render();
                //disable both timers
                CarSpawn.Enabled = false;
                GameTime.Enabled = false;
         

            }
        }
    }
}
