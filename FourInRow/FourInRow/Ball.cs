using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FourInRow
{
    public class Ball
    {

        private Ellipse el;
        private SolidColorBrush color;
        private double x;
        private double y;
        private double xspeed;
        private double yspeed;



        public SolidColorBrush BallColor
        {
            get { return color; }
            set { color = value; }
        }

        public double Xspeed
        {
            get { return xspeed; }
            set { xspeed = value; }
        }
        public double Yspeed
        {
            get { return yspeed; }
            set { yspeed = value; }
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public Ellipse EL
        {
            get { return el; }
            set { el = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public Ball()
        {
        }
        public Ball(Point p)
        {
            EL = new Ellipse();
            el.Width = 68;
            el.Height = 47;
            Xspeed = 20;
            Yspeed = 20;
            X = p.X - EL.Width / 2;
            Y = p.Y - EL.Height / 2;
        }


    }
}
