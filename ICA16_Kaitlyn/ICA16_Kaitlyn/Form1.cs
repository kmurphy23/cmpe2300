using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kaitlyn_Drawers;
using GDIDrawer;



namespace ICA16_Kaitlyn
{
    //our two interfaces used for the class
 

   
    public partial class Form1 : Form
    {
        //create the list as well as the canvas 
        List<BaseShape> ShapeList = new List<BaseShape>();
        Kaitlyn_Drawers.picClass canvas = null;
        public Form1()
        {
            InitializeComponent();
            //Initialize the canvas
            canvas = new Kaitlyn_Drawers.picClass(Properties.Resources.persian_cats_and_kittens_1,true,false);
            BaseShape._canvas = canvas;
            canvas.Render();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //this is the position of the mouse 
            Point position;
            canvas.GetLastMousePositionScaled(out position);
            //them we create our random object 
            Random rand = new Random();
            //we clear the collection if the user clicks c
            if (e.KeyCode == Keys.C)
            {
                ShapeList.Clear();
            }
            //if the user presses s we add a snake
            if(e.KeyCode == Keys.S)
            {
                ShapeList.Add(new Snake(position, rand.Next(20,61)));
            }
            //if the user presses b we add a blob
            if(e.KeyCode == Keys.B)
            {
                ShapeList.Add(new Blob(position, rand.Next(30,50)));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //clear the canvas 
            canvas.Clear();
            //move
            ShapeList.ForEach(arg => arg.Move());
            //animate
            ShapeList.ForEach(arg => (arg as IAnimatable)?.Animate(canvas));
            //remove 
            ShapeList.RemoveAll(arg => (arg as IMortal)?.Step() == false);
            //paint
            ShapeList.ForEach(arg => arg.Paint());
            //then render the canvas
            canvas.Render();
        }
    }
}
