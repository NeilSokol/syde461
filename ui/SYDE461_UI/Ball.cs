using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Shapes;
using Microsoft.VisualBasic.PowerPacks;
using System.Windows.Media;

namespace WindowsFormsApplication1
{
    public class Ball
    {
        //ball standard radius
        private int ballsize;
        private Bitmap scene = null;
        public Graphics g;
        public int posx = 0;
        public int posy = 0;
        public double width = 2;
        public double height = 2;
        public Ellipse theBall;
        public double ballArea = 200;
        private System.Drawing.Pen bluePen = new System.Drawing.Pen(System.Drawing.Color.Blue, 8);
        public double redx = 1;
        public double redy = 1;
        public double yellowx = 1;
        public double yellowy = 1;
        public double fingerdistance = 1;

        public Ball(Bitmap background,double area)
        {
            scene = background;
            ballArea = area;
            //initialize ball as elipse with size scaled to scene resolution
            ballsize = (int) Math.Min(scene.Height, scene.Width);
            posx = (int) (scene.Width / 4);
            posy = (int) (scene.Height / 4);
            theBall = new Ellipse();
        }


        public void UpdateBall(int newheight)
        {
            fingerdistance = Math.Sqrt(Math.Pow(Math.Abs(redx - yellowx), 2) + Math.Pow(Math.Abs(redy - yellowy), 2));
            height = Math.Max((int)fingerdistance,1);
            width = (ballArea / (Math.PI * (0.25 * height)));
            g = Graphics.FromImage(scene);
            g.Clear(System.Drawing.Color.Black);
            g.DrawEllipse(bluePen, posx, posy, (int)width, (int)height);
        }

        public void deformBall()
        {
            

        }



    }
}
