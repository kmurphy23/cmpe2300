using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace New_lab_1
{
    //Program Lab01-Decoder
    //Author: Kaitlyn Murphy
    //Class: CMPE2300
    public partial class Form1 : Form
    {
        // Declare the variable for the original Bit map
        //This one will never be modified
        Bitmap original;

        //Declare and initializes the enum variable
        //this is used to determine which bit colour we are looking for in the image
        public enum PickedColour {Red,Green,Blue,RGB};
        PickedColour pc;


      
        //delegates used for the thread
        //speeds up the process of decoding the image
        //as well as increments the progress bar 
        private delegate void delVoidInt(int Inc);
        private delegate PickedColour delIntVoid();
        private delegate void delBitVoid(Bitmap map);
    


        //struct used to determine what choice the user will make
        //my code only allows for the choice of colour and NOT text vs. Colour decode
        public struct Choice
        {
            public PickedColour pc;

            //initilizes the struct
            public Choice(PickedColour p)
            {
                pc = p;
            }

        }

        


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Disabes the go button until a picture is loaded 
            Gobtn.Enabled = false;
        }


        // Function name : decode
        // Description : Recursively check and replace the colours of the pixels for the bitmap image
        // Return type : does not return anything
        // Argument : accept an object - The choice the user has made about the colour
        private void Decode(object MyChoice)
        {

            Choice choice = (Choice)MyChoice;

            //creates a NEW bitmap with the same dimensions as the original one
            //this ensures we don't play with the original just a copy of the same width and height
            Bitmap pic = new Bitmap(original.Width, original.Height);

            //filtes through each pixel in the width
            for (int x = 0; x < original.Width; x++)
            {
                //filters through each pixel in the height
                for (int y = 0; y < original.Height; y++)
                {
                    //sets each pixel to black
                    //this will be changed later depending on if a value was fund in the LSB
                    pic.SetPixel(x, y, Color.Black);

                    //unsigned int that is used to determine which colour each pixel needs to be changed to
                    uint pixel = 0xff000000;

                    //determines whether the red colour has been choosen in any instances...
                    if (choice.pc == PickedColour.Red || choice.pc == PickedColour.RGB)
                    {
                        //...if it is chosen then we set that pixel to red 
                        if((original.GetPixel(x, y).R & 1) == 1)
                        {
                            pixel |= 0x00ff0000;
                        }
                    }


                    //Next is green. If we have green chosen we dive into this loop
                    if (choice.pc == PickedColour.Green || choice.pc == PickedColour.RGB)
                    {
                        //if the colour chosen is correct then we add green into the new colour we are currently making
                        if ((original.GetPixel(x, y).G & 1) == 1)
                        {
                            pixel |= 0x0000ff00;
                        }
                    }


                    //Lastly is Blue, if we have picked blue from the UI or RGB we jump into this loop
                    if (choice.pc == PickedColour.Blue || choice.pc == PickedColour.RGB)
                    {
                        //again if the chosen colour is correct we will add blue colour to this pixel as well
                        if ((original.GetPixel(x, y).B & 1) == 1)
                        {
                            pixel |= 0x000000ff;
                        }

                    }

                    //we set the pixel using our newly created colour from the process above
                    pic.SetPixel(x, y, Color.FromArgb((int)pixel));

                }

                //Invoked the increent method if the picture is still loading
                try
                {
                    //this will call the method to increment the progress bar 
                    //also passes it the value to increment by
                   
                    Invoke(new delVoidInt(Increment),1);
                }
                catch
                {
                    //this will only happen if an exceptin is thrown
                    //shows an error message box
                    MessageBox.Show("Dead Thread");
                }

            }

            //invokes the delegate to call the set map method
            Invoke(new delBitVoid(SetMap),pic);
           
        }

        //method that receives the value in which to increment the progress bar
        //this is recieved from the delegate above
        private void Increment(int i)
        {
             
            progressBar1.Increment((int)i);
        }


        // Function name : SetMap
        // Description : sets the decoded method to the picture box and enable the go button 
        // Return type : does not return anything
        // Argument : accept a bitmap- this is the image we have decoded from the decode mesage
        private void SetMap(Bitmap map)
        {
            //load the new picture into the image box in the UI
            pictureBox1.Image = map;
            Gobtn.Enabled = true;

        }


        //button 1 is the load image button
        //file open method loads the image into the picture box
        private void button1_Click_1(object sender, EventArgs e)
        {
            //file open dialog if everything goes ok with pening the picture
            //image will be sent to the image box which
            //then imag is cast into a bitmap and the go button is enabled
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                original = new Bitmap(pictureBox1.Image);
                Gobtn.Enabled = true;
            }
        }

 
        
        //this method begins the program(go button)
        //calls the threadprep method does not accept or return anything
        private void button2_Click(object sender, EventArgs e)
        {
            ThreadPrep();
        }


        // Function name : ThreadPrep
        // Description : Prepares the instance of the thread and resets the progress bar back to 0
        // Return type : does not return anything
        // Argument : accepts nothing
        private void ThreadPrep()
        {
            //if the go button is pressed we will begin the thread
            Choice newchoice = new Choice(pc);
            Gobtn.Enabled = false;
            progressBar1.Value = 0;
            if (Decoderchoice.SelectedIndex == 0)
            {
                //these are the threads we are using each initialized and begining here
                //this one calls the decode methond
                ParameterizedThreadStart pts = new ParameterizedThreadStart((Decode));

                //this starts the thread to the decoder
                Thread start = new Thread(pts);
                start.IsBackground = true;
                start.Start(newchoice);
                
            }

        }


        


        //if the user changes the selection on the colour tool bar then
        //the enumertion will change the selection 
        //this method does not return or accept anything
        //it does howeever SET the choice variable
        private void ColourChose_SelectedIndexChanged(object sender, EventArgs e)
        {
            //based on the enumeration declared at the top of this program we will pass this colour choice off to the decode method
            //each if statement does the same thing: find out which item in the combo box was chosen
            if (ColourChose.SelectedIndex == 0)
                pc = PickedColour.Red;
            if (ColourChose.SelectedIndex == 1)
                pc = PickedColour.Green;
            if (ColourChose.SelectedIndex == 2)
                pc = PickedColour.Blue;
            if (ColourChose.SelectedIndex == 3)
                pc = PickedColour.RGB;

        }
    }
}
