using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace ICA08_Kaitlyn
{
    class Ball
    {
        static private Random rand = new Random();

        private PointF Center;
        private float VelX;
        private float VelY;
        private int ballRad;

        public Color BallColour { get; set; }

        public Ball(PointF newPoint, Color newColour)
        {
            Center = newPoint;
            BallColour = newColour;
            VelX = (float)((rand.NextDouble()) * 10)-5;
            VelY = (float)((rand.NextDouble()) * 10)-5;
            ballRad = rand.Next(20, 51);
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Ball)) return false;
            Ball arg = obj as Ball;

            float distance = this.GetDistance(arg);
            return distance <= this.ballRad + arg.ballRad;
        }

        public override int GetHashCode()
        {
            return 1;
        }
        public float GetDistance(Ball newbl)
        {
            return (float)Math.Sqrt(Math.Pow(Center.X - newbl.Center.X, 2) + Math.Pow(Center.Y - newbl.Center.Y, 2));

            // d = sqrt( a^2 + b^2)
        }

        public void Move(CDrawer canvas)
        {
            if ((Center.X + ballRad + VelX) > canvas.m_ciWidth || (Center.X - ballRad + VelX) < 0)
                VelX *= -1;

            if ((Center.Y + ballRad + VelY) > canvas.m_ciHeight || (Center.Y - ballRad + VelY) < 0)
                VelY *= -1;

            Center.X += VelX;
            Center.Y += VelY;
        }

        public void Show(CDrawer canvas, int num)
        {
            canvas.AddCenteredEllipse((int)Center.X, (int)Center.Y, (ballRad*2), (ballRad*2), BallColour);
            canvas.AddText(num.ToString(),14 , (int)Center.X - ballRad, (int)Center.Y -ballRad, ballRad*2,ballRad*2, Color.FromArgb(BallColour.ToArgb() ^ 0x00FFFFFF));
        }

    }
}
