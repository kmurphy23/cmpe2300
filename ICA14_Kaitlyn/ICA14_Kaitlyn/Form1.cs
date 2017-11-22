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
using System.Threading;

namespace ICA14_Kaitlyn
{
    public partial class Form1 : Form
    {
        picClass drawer;
        Keys input = Keys.None;
        List<Block> BlockList = new List<Block>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //create a new instance of our drawer with the backgroud set to
            //the resource picture 
            drawer = new picClass(Properties.Resources.cats);
            //this is how we acces the DRAWER key down events
            drawer.KeyboardEvent += Drawer_KeyboardEvent;

            //prepare the three thread methods

            //Move thread
            Thread Mthread = new Thread(MoveThread);
            Mthread.IsBackground = true;
            Mthread.Start();

            //Show thread
            Thread Sthread = new Thread(ShowThread);
            Sthread.IsBackground = true;
            Sthread.Start();

            //Inout Thread
            Thread Ithread = new Thread(InputThread);
            Ithread.IsBackground = true;
            Ithread.Start();



        }



        //WE NEED THREE THREADS 
        //ALL OF THEM ARE BELOW

        //first lets start with the move thread
        private void MoveThread()
        {
            //always looping forever and ever
            while (true)
            {
                //Lock the thread so no interupts
                lock (BlockList)
                {
                    //invoke move for each block in the list
                    BlockList.ForEach(b => b.Move(BlockList));
                }
                //make the thread sleep for 100ms
                Thread.Sleep(100);
            }
        }


        //second the show/render thread
        private void ShowThread()
        {
            //looping forever and ever
            while (true)
            {
                drawer.Clear();
                //lock using the list
                lock (BlockList)
                {
                    //show for each block 
                    BlockList.ForEach(b => b.ShowBlock(drawer));
                }
                //render the canvas 
                drawer.Render();
                //sleep for 50ms
                Thread.Sleep(50);
            }
        }

        //Lastly the Input thread
        private void InputThread()
        {
            //looping forever and ever
            while (true)
            {
                //as long as the key is not nothing 
                if(input != Keys.None)
                {
                    //we retrieve the last mouse position and create that point
                    Point p;
                    drawer.GetLastMousePosition(out p);

                    //if the key code is f
                    if(input == Keys.F)
                    {
                        lock (BlockList)
                        {
                            //then we add the block to the list using the falling block one
                            BlockList.Add(new FallingBlock(p));
                        }
                        
                    }

                    //if the key code is d call drunk blocks
                    if(input == Keys.D)
                    {
                        lock (BlockList)
                        {
                            //then we add the block to the list using the falling block one
                            BlockList.Add(new DrunkBlock(p));
                        }
                    }

                    //if key code is c 
                    if (input == Keys.C)
                    {
                        lock (BlockList)
                        {
                            //then we add the block to the list using the falling block one
                            BlockList.Add(new ColourBlock(p));
                        }
                    }

                    //if the key is escape
                    if(input == Keys.Escape)
                    {
                        lock (BlockList)
                        {
                            //if outside bool is true then we remove it 
                            BlockList.RemoveAll(B => B.Outside);
                        }
                    }

                    //if f1 is pressed
                    if(input == Keys.F1)
                    {
                        //lock it so we cant use it
                        lock (BlockList)
                        {
                            BlockList.Clear();
                        }
                    }
                    //clear the input key 
                    input = Keys.None;
                }
                //sleep for 50 ms
                Thread.Sleep(50);
            }
        }
        
        //this is what we get from OUR DRAWER 
        //everything is passed into us that we need like the keycode the bool and the drawer
        private void Drawer_KeyboardEvent(bool bIsDown, Keys keyCode, GDIDrawer.CDrawer dr)
        {
            //if the keypressed DOWN them we set the input key to the keycode 
            if (bIsDown)
                input = keyCode;
        }

        //this is our key down event for the form1 
        //if we press down a key in there we set it to the key code 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            input = e.KeyCode;
        }
    }
}
