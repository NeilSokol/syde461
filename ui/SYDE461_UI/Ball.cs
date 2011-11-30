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
        public double ballArea = 40;
        private System.Drawing.Pen bluePen = new System.Drawing.Pen(System.Drawing.Color.Blue, 8);

        public Ball(Bitmap background,double area)
        {
            scene = background;
            ballArea = area;
            //initialize ball as elipse with size scaled to scene resolution
            ballsize = (int) Math.Min(scene.VerticalResolution, scene.HorizontalResolution);
            posx = (int) (scene.HorizontalResolution / 2);
            posy = (int) (scene.VerticalResolution / 2);

            theBall = new Ellipse();
        }


        public void UpdateBall(int newheight)
        {
            height = newheight;
            width = (ballArea - (0.5 * height)) / Math.PI;
            g = Graphics.FromImage(scene);
            g.Clear(System.Drawing.Color.Black);
            g.DrawEllipse(bluePen, posx, posy, (int)width, (int)height);
        }

        public void deformBall()
        {
            

        }



    }
}
