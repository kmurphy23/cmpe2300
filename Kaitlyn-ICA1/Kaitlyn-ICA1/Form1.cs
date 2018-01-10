using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Kaitlyn_ICA1
{
    public partial class Form1 : Form
    {
        //original version of the picture DONT MESS WITH THIS ONE
        Bitmap original;
        //now we have the delegate were gonna need to use 
        private delegate void delVoidBit(Bitmap map);

        public struct Choice
        {
            //struct has 2 things our bitmap and our choice of brightness
            public Bitmap BM;
            public float BrightVal;
            public Choice(Bitmap bm, float fVal)
            {
                BM = new Bitmap(bm);
                BrightVal = fVal;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //take the picture from the open file dialog and then plop it in the bitmap
                pictureBox1.Load(openFileDialog1.FileName);
                original = new Bitmap(pictureBox1.Image);
            }
        }

        private void BrightUp_Click(object sender, EventArgs e)
        {
            //assign the value of the brightness
            Choice newC = new Choice(original,1.1f);
            toolStripProgressBar1.Value = 0;
            ParameterizedThreadStart pts = new ParameterizedThreadStart(Adjust);

            //start the thread!
            Thread start = new Thread(pts);
            start.IsBackground = true;
            start.Start(newC);

        }

        private void BrightDown_Click(object sender, EventArgs e)
        {
            //assign the value of the brightness
            Choice newC = new Choice(original, 0.9f);
            toolStripProgressBar1.Value = 0;
            ParameterizedThreadStart pts = new ParameterizedThreadStart(Adjust);

            //start the thread!
            Thread start = new Thread(pts);
            start.IsBackground = true;
            start.Start(newC);
        }

        private void Adjust(object Ad)
        {

            //creates an instance of the choice struct
            Choice choice = (Choice)Ad;

            Bitmap pic = choice.BM;
            //a variable that we will store the value of the pixel color (does that sentecne make sense?)
            Color c;
            float pixelR;
            float pixelG;
            float pixelB;
            //filtes through each pixel in the width
            for (int y = 0; y < original.Height; y++)
            {
                //filters through each pixel in the height
                for (int x = 0; x < original.Width; x++)
                {
                    pixelR = pic.GetPixel(x, y).R;
                    pixelG = pic.GetPixel(x, y).G;
                    pixelB = pic.GetPixel(x, y).B;

                    if (choice.BrightVal == 1.1f)
                    {
                        pixelR = Math.Min(pixelR *= choice.BrightVal, 255);
                        pixelG = Math.Min(pixelG *= choice.BrightVal, 255);
                        pixelB = Math.Min(pixelB *= choice.BrightVal, 255);
                    }

                    else if (choice.BrightVal == 0.9f)
                    {
                        pixelR = Math.Max(pixelR *= choice.BrightVal, 0);
                        pixelG = Math.Max(pixelG *= choice.BrightVal, 0);
                        pixelB = Math.Max(pixelB *= choice.BrightVal, 0);
                    }
                    
                    c = Color.FromArgb((int)(pixelR), (int)(pixelG), (int)(pixelB));
                    pic.SetPixel(x, y, c);
                }
            }
            
            //invokes the delegate to call the set map method
            Invoke(new delVoidBit(SetMap), pic);

        }

        //thread meth
        private void SetMap(Bitmap map)
        {
            pictureBox1.Image = map;
        }

    }
}
