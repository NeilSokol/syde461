using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Shapes;
using Microsoft.VisualBasic.PowerPacks;
using System.Windows.Media;
using System.Windows.Forms;

namespace SYDE461_UI
{
    public class Ball
    {
        //ball standard radius

        public Graphics g;
        public int posx = 0;
        public int posy = 0;
        public double width = 2;
        public double height = 2;
        public Ellipse theBall;
        public double ballArea = 200;
        public double redx = 1;
        public double redy = 1;
        public double yellowx = 1;
        public double yellowy = 1;
        public double fingerdistance = 1;
        public double originalFingerDist = 0;
        private double max_width = 1;
        private double max_height = 1;
        private double min_width = 25;
        private double min_height = 25;
        private double balldistance = 1;
        private double oldballdistance = 1;
        private int ballsize;
        public int health = 0;
        public Bitmap scene = null;
        private System.Drawing.Pen bluePen = new System.Drawing.Pen(System.Drawing.Color.Blue, 8);
        private System.Drawing.Pen redPen = new System.Drawing.Pen(System.Drawing.Color.Red, 5);

        public Ball(Bitmap background,double area)
        {
            scene = background;
            ballArea = area;
            //initialize ball as elipse with size scaled to scene resolution
            ballsize = (int) Math.Min(scene.Height, scene.Width);
            posx = (int) (scene.Width / 4);
            posy = (int) (scene.Height / 4);
            max_width = max_height = 45;//Math.Sqrt(ballArea / (2 * 3.1515926));

            theBall = new Ellipse();
        }


         public void UpdateBall(double newheight)
        {
            
             
            fingerdistance = Math.Sqrt(Math.Pow(Math.Abs(redx - yellowx), 2) + Math.Pow(Math.Abs(redy - yellowy), 2));

            //if (originalFingerDist <= 10)
            //{
            //    originalFingerDist = fingerdistance;
            //    MessageBox.Show( "Baseline distance =" + originalFingerDist);
            //}


             //if (fingerdistance < 320)
             //{
             //    fingerdistance++;
             //}
             //else
             //{
             //    fingerdistance = 1;
             //}

            //if ((fingerdistance / 20) > max_height)
            //{
            //    height = max_height;
            //}

            //else if ((fingerdistance / 20) < min_height)
            //{
            //    height = min_height;
            //}

            //else
            //{
                height = Math.Max((int)fingerdistance, 1);
            //}
            width = (ballArea / (Math.PI * (0.25 * height)));
            g = Graphics.FromImage(scene);
            g.Clear(System.Drawing.Color.Black);
            g.DrawEllipse(bluePen, posx, posy, (int)width, (int)height);
        }

        //Trying to draw ellipse on a different background
         public void UpdateBall(double newheight, Bitmap newbackground)
         {

             System.Drawing.Rectangle rec = new System.Drawing.Rectangle(0, 0, newbackground.Width - 1, newbackground.Height - 1);
             scene = newbackground.Clone(rec, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
             oldballdistance = balldistance;
             balldistance = fingerdistance = Math.Sqrt(Math.Pow(Math.Abs(redx - yellowx), 2) + Math.Pow(Math.Abs(redy - yellowy), 2));

             balldistance = fingerdistance * this.calculateHealthModifier(this.health);
             if (fingerdistance > max_height || fingerdistance == 0 || balldistance > max_height)
             {
                 balldistance = max_height;
             }

             else if (fingerdistance < min_height || balldistance < min_height)
             {
                 balldistance = min_height;
             }

             else 
             {
                // balldistance -= (oldballdistance-balldistance) * this.calculateHealthModifier(this.health);

             }

             //System.Drawing.Rectangle blobcenters = new System.Drawing.Rectangle((int)yellowx, (int)yellowy, (int)redx, (int)redy);

             //if (originalFingerDist <= 10)
             //{
             //    originalFingerDist = fingerdistance;
             //    MessageBox.Show( "Baseline distance =" + originalFingerDist);
             //}


             //if (fingerdistance < 320)
             //{
             //    fingerdistance++;
             //}
             //else
             //{
             //    fingerdistance = 1;
             //}

             //if ((fingerdistance / 20) > max_height)
             //{
             //    height = max_height;
             //}

             //else if ((fingerdistance / 20) < min_height)
             //{
             //    height = min_height;
             //}

             //else
             //{
             height = Math.Max((int)balldistance, 1);
             //}
             width = (ballArea / (Math.PI * (0.25 * height)));
             //g = Graphics.FromImage(scene);
             //g.Clear(System.Drawing.Color.Black);
             //g.DrawEllipse(bluePen, posx, posy, (int)width, (int)height);
             g = Graphics.FromImage(scene);
             //g.Clear(System.Drawing.Color.Black);
             //g.DrawImage(scene, theBall, 0, 0, scene.Width, scene.Height, GraphicsUnit.Pixel);
             g.DrawEllipse(bluePen, posx, posy, (int)width, (int)height);
             //g.DrawRectangle(redPen, (int)redx, (int)redy, (int)(redx - yellowx), (int)(redy - yellowy));
             
         }

         private double calculateHealthModifier(int health)
         {
             switch (health)
             {
                 case 0:
                     return 1;
                 case 1:
                     return 1.80;
                 case 2:
                     return 2.50;
                 case 3:
                     return 4;
                 default:
                     Console.WriteLine("Invalid selection of Health Modifier detected");
                     break;
             };
             return 1;
         }

         public void resetBall()
         {
             UpdateBall(max_height / 2);
         }



    }
}
