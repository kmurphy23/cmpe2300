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
using System.Threading;


namespace ICA09_Kaitlyn
{
    public partial class Form1 : Form
    {
        Stack<Sheeple> sheepS = new Stack<Sheeple>();
        List<Queue<Sheeple>> SheepleList = new List<Queue<Sheeple>>();
        CDrawer canvas = null;
        int iScale = 20;
        int TotalCount = 0;
        bool _running;
        object key = new object();


        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void Thready(Object obj)
        {
            if (!(obj is Queue<Sheeple>)) return;

            Random Rand = new Random();
            Queue<Sheeple> arg = obj as Queue<Sheeple>;
            int time = Rand.Next(20, 41) * 10;

            while (!_running)
            {
                Thread.Sleep(time);
                lock (key)
                {
                    if (arg.Count > 0)
                    {
                        arg.Peek().Process();
                        if (arg.Peek().Done)
                        {
                            TotalCount+=arg.Dequeue().TotalItems;
                        }
                          
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SimBtn_Click(object sender, EventArgs e)
        {

            _running = false;
            sheepS.Clear();
            SheepleList.Clear();
            if (canvas != null)
                canvas.Close();
            TotalCount = 0;
            canvas = new CDrawer(1200, (int)numericUpDown1.Value * iScale, false);
            canvas.Scale = iScale;

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                SheepleList.Add(new Queue<Sheeple>());
            }
            //for each queue make thread pass queue start
            //make it a background thread 
            Thread SheepThread;
            lock (key)
            {
                foreach (Queue<Sheeple> q in SheepleList)
                {
                    SheepThread = new Thread(new ParameterizedThreadStart(Thready));
                    SheepThread.IsBackground = true;
                    SheepThread.Start(q);
                }
            }
            for (int i = 0; i < 200; i++)
            {
                sheepS.Push(new Sheeple());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (canvas == null)
            {
                return;
            }
            //canvas.Clear();

            if (sheepS.Count > 0)
            {
                lock (key)
                {
                    foreach (Queue<Sheeple> s in SheepleList)
                    {
                        if (s.Count < 10 && sheepS.Count > 0)
                        {
                            s.Enqueue(sheepS.Pop());
                        }
                    }
                }

            }
            canvas.Clear();
            if (sheepS.Count > 0)
            {
                Lbl.Text = sheepS.Peek().TotalItems.ToString();
                Lbl.BackColor = sheepS.Peek().SheepColor;
            }
            lock (key)
            {
                foreach (Queue<Sheeple> q in SheepleList)
                {
                    int x = 0;
                    foreach (Sheeple s in q)
                    {
                        s.ShowSheeple(canvas,s, x, SheepleList.IndexOf(q));
                        x += s.TotalItems;
                    }
                }
            }

            canvas.Render();
            this.Text = TotalCount.ToString();
        }
    }
}
