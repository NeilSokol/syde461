﻿using System;
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
        private double min_width = 7;
        private double min_height = 7;
        private int ballsize;
        public Bitmap scene = null;
        private System.Drawing.Pen bluePen = new System.Drawing.Pen(System.Drawing.Color.Blue, 8);

        public Ball(Bitmap background,double area)
        {
            scene = background;
            ballArea = area;
            //initialize ball as elipse with size scaled to scene resolution
            ballsize = (int) Math.Min(scene.Height, scene.Width);
            posx = (int) (scene.Width / 4);
            posy = (int) (scene.Height / 4);
            max_width = max_height = 22.5676;//Math.Sqrt(ballArea / (2 * 3.1515926));

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
             //g = Graphics.FromImage(scene);
             //g.Clear(System.Drawing.Color.Black);
             //g.DrawEllipse(bluePen, posx, posy, (int)width, (int)height);
             g = Graphics.FromImage(scene);
             //g.Clear(System.Drawing.Color.Black);
             //g.DrawImage(scene, theBall, 0, 0, scene.Width, scene.Height, GraphicsUnit.Pixel);
             g.DrawEllipse(bluePen, posx, posy, (int)width, (int)height);
             
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



    }
}
