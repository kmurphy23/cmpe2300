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

namespace ICA08_Kaitlyn
{
    public partial class Form1 : Form
    {
        //initialize canvas to the derived classes
        picClass GBDraw;
        rectDrawer RedDraw;

        List<Ball> GreenList = new List<Ball>();
        List<Ball> BlueList = new List<Ball>();
        List<Ball> CollideList = new List<Ball>();
        public Form1()
        {
            InitializeComponent();
            //initialize both as the adjusted canvas 
            GBDraw = new picClass(Properties.Resources.persian_cats_and_kittens_1);
            RedDraw = new rectDrawer(GBDraw.m_ciWidth,GBDraw.m_ciHeight);
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(GBDraw.GetLastMouseLeftClickScaled(out Point GreenClick))
            {
                Ball tempBall = new Ball(GreenClick, Color.Green);

                if (GreenList.Contains(tempBall) != true)
                    GreenList.Add(tempBall);
            }

            if(GBDraw.GetLastMouseRightClickScaled(out Point BlueClick))
            {
                Ball BlueTemp = new Ball(BlueClick, Color.Blue);

                if (BlueList.IndexOf(BlueTemp) < 0)
                    BlueList.Insert(0, BlueTemp);
            }

            GreenList.ForEach(mov => mov.Move(GBDraw));
            BlueList.ForEach(mov => mov.Move(GBDraw));
            CollideList.ForEach(mov => mov.Move(RedDraw));

            List<Ball> temp = new List<Ball>();
            temp = BlueList.Intersect(GreenList).ToList();

            temp.ForEach(mov => { mov.BallColour = Color.Red; while (BlueList.Remove(mov)) ; while (GreenList.Remove(mov)) ; });

            CollideList = new List<Ball>(CollideList.Union(temp));

            GBDraw.Clear();
            RedDraw.Clear();

            GBDraw.AddText($"Blue: {BlueList.Count} Green: {GreenList.Count}", 40, Color.Aquamarine);
            RedDraw.AddText($"{CollideList.Count}", 40, Color.PaleVioletRed);

            for (int i = 0; i < GreenList.Count; i++)
                GreenList[i].Show(GBDraw, i);
            for (int i = 0; i < BlueList.Count; i++)
                BlueList[i].Show(GBDraw, i);
            for (int i = 0; i < CollideList.Count; i++)
                CollideList[i].Show(RedDraw, i);

            RedDraw.Render();
            GBDraw.Render();

        }
    }
}
