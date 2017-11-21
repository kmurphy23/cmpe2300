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

namespace ICA10_Kaitlyn
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();
        List<Point> PointList = new List<Point>();
        LinkedList<Point> LinkList = new LinkedList<Point>();
        CDrawer canvas = new CDrawer();


        public Form1()
        {
            InitializeComponent();
            this.Location = new Point(0,0);
        }

        private void MakeBtn_Click(object sender, EventArgs e)
        {
            PointList.Clear();
            int divisor = (int)numericUpDown1.Value;
            for(int y =0; y<canvas.ScaledHeight; y+=divisor)
            {
                for(int x =0; x < canvas.ScaledWidth; x+=divisor)
                {
                    PointList.Add(new Point(x,y));
                }
            }
            canvas.Clear();
            for(int i =0; i <PointList.Count-1; i++)
            {
                canvas.AddLine(PointList[i].X, PointList[i].Y, PointList[i + 1].X, PointList[i + 1].Y, Color.Fuchsia, 2);
                MakeBtn.Text = String.Format("Made {0} Points", PointList.Count);
            }
        }

        private void ShuffleBtn_Click(object sender, EventArgs e)
        {
            List<Point> ShuffledList = new List<Point>(MyLibrary.Shuffle(PointList));
            canvas.Clear();
            for (int i = 0; i < ShuffledList.Count - 1; i++)
            {
                canvas.AddLine(ShuffledList[i].X, ShuffledList[i].Y, ShuffledList[i + 1].X, ShuffledList[i + 1].Y, Color.Green, 2);
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PopBtn_Click(object sender, EventArgs e)
        {

            if (PointList.Count == 0)
                return;
            LinkList.Clear();
            foreach(Point p in PointList)
            {
                LinkedListNode<Point> node;
                for(node=LinkList.First; node != null; node = node.Next)
                {
                    if ((p.X*canvas.ScaledHeight+p.Y) < (node.Value.X*canvas.ScaledHeight+node.Value.Y))
                        break;
                }
                if (node == null)
                {
                    LinkList.AddLast(p);
                }
                else
                {
                    LinkList.AddBefore(node, p);
                }
            }
            canvas.Clear();
            LinkedListNode<Point> Newnode;
            for (Newnode = LinkList.First; Newnode.Next != null; Newnode = Newnode.Next)
            {
                canvas.AddLine(Newnode.Value.X, Newnode.Value.Y, Newnode.Next.Value.X, Newnode.Next.Value.Y, Color.Yellow);
            }
        }
    }
}
