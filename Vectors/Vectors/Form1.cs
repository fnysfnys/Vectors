using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vectors
{
    public partial class Form1 : Form
    {
        public class Mover
        {
            static Random rnd = new Random();
            PVector location;
            PVector velocity;
            PVector acceleration;
            double topspeed;
            public Mover()
            {
                location = new PVector(rnd.Next(10,2500), rnd.Next(10, 1000));
                velocity = new PVector(0, 0);
                topspeed = 4;
            }
            public void update()
            {
                PVector mouse = new PVector(Control.MousePosition.X, Control.MousePosition.Y);
                PVector dir = PVector.sub(mouse, location);
                dir.mult(0.5);
                acceleration = dir;

                velocity.add(acceleration);
                velocity.limit(topspeed);
                location.add(velocity);
            }
            public void display(PaintEventArgs e)
            {
                Graphics g = e.Graphics;
                SolidBrush brush1 = new SolidBrush(System.Drawing.Color.LimeGreen);

                brush1.Color = Color.AliceBlue;

                Rectangle snakeRectangle = new System.Drawing.Rectangle((int)location.x, (int)location.y, 32, 32);

                g.FillEllipse(brush1, snakeRectangle);

            }

            //public void checkEdges()
            //{
            //    if (location.x > 360)
            //    {
            //        location.x = 0;
            //    }
            //    else if (location.x < 0)
            //    {
            //        location.x = 360;
            //    }

            //    if (location.y > 290)
            //    {
            //        location.y = 0;
            //    }
            //    else if (location.y < 0)
            //    {
            //        location.y = 290;
            //    }


            //}
            
        }
        public class PVector
        {
            public double x;
            public double y;
            public PVector(double x_, double y_)
            {
                x = x_;
                y = y_;
            }
            public void add(PVector v)
            {
                y = y + v.y;
                x = x + v.x;
            }
            public void sub(PVector v)
            {
                y = y - v.y;
                x = x - v.x;
            }
            public void mult(double n)
            {
                x = x * n;
                y = y * n;

            }
            public void div(double n)
            {
                x = x / n;
                y = y / n;

            }
            public double mag()
            {
                return Math.Sqrt(x * x + y * y);
            }
            public void normalize()
            {
                double m = mag();
                if (m != 0)
                {
                    div(m);
                }
                
            }
            public void limit(double max)
            {
                double m = mag();
                if (m > max*max)
                {
                    normalize();
                    mult(max);
                }
            }
            public static PVector add(PVector v1, PVector v2)
            {
                PVector v3 = new PVector(v1.x + v2.x, v1.y + v2.y);
                return v3;
            }
            public static PVector sub(PVector v1, PVector v2)
            {
                PVector v3 = new PVector(v1.x - v2.x, v1.y - v2.y);
                return v3;
            }
            public static PVector mult(PVector v1, double n)
            {
                PVector v3 = new PVector(v1.x*n, v1.y*n);
                return v3;
            }
            public static PVector div(PVector v1, double n)
            {
                PVector v3 = new PVector(v1.x / n, v1.y / n);
                return v3;
            }



        }
       
        Mover[] movers = new Mover[200];
       




        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);


            for (int i = 0; i < movers.Length; i++)
            {
                movers[i] = new Mover();
            }
        }


        private void TmrUpdate_Tick(object sender, EventArgs e)
        {
            //Refresh();
            //for (int i = 0; i < movers.Length; i++)
            //{
            //    movers[i].update();
            //    movers[i].checkEdges();
            //    movers[i].display();

            //}
            Invalidate();

        }

        private void CheckForBounce()
        {
            
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

           
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < movers.Length; i++)
            {
                movers[i].update();
                //movers[i].checkEdges();
                movers[i].display(e);

            }
        }
    }
}
