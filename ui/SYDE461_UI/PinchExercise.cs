﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Media;
using Microsoft.Research.Kinect.Nui;
using Microsoft.Research.Kinect.Audio;
using System.Threading;
using AForge.Imaging;
using AForge.Vision;
using AForge;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Npgsql;

namespace SYDE461_UI
{
    public class PinchExercise: ExerciseData
    {
        Runtime nui = Runtime.Kinects[0];

        //images
        Bitmap back;
        Bitmap depth;
        Bitmap colorbmap;
        Bitmap redbmap;
        Bitmap redbmap2;
        Bitmap yellowbmap;
        Bitmap greenbmap;
        Bitmap greenbmap2;
        //Bitmap bluebmap;

        //colour blobs
        Blob[] blobs;
        Blob[] blobsred;
        Blob[] blobsyellow;

        //position info
        double red_x;
        double red_y;
        double yellow_x;
        double yellow_y;
        double fingerdistance;

        //number of objects
        int objectCount;
        int patientHealth = 0;
        bool gotRed = true;
        bool gotYellow = true;
        Bitmap ballBack = new Bitmap(320, 240);

        //Filters
        AForge.Imaging.Filters.Subtract sub;
        AForge.Imaging.Filters.GrayscaleRMY gray = new AForge.Imaging.Filters.GrayscaleRMY();
        AForge.Imaging.Filters.ThresholdedDifference thresh = new AForge.Imaging.Filters.ThresholdedDifference(20);
        AForge.Imaging.Filters.GaussianBlur gauss = new AForge.Imaging.Filters.GaussianBlur(5, 1);
        AForge.Imaging.Filters.ResizeBilinear shrink = new AForge.Imaging.Filters.ResizeBilinear(320, 240);
        AForge.Imaging.Filters.ResizeBilinear grow = new AForge.Imaging.Filters.ResizeBilinear(640, 480);
        AForge.Imaging.Filters.BlobsFiltering blobfilter = new AForge.Imaging.Filters.BlobsFiltering();
        AForge.Imaging.Filters.ConnectedComponentsLabeling connectedfilter = new AForge.Imaging.Filters.ConnectedComponentsLabeling();
        AForge.Imaging.Filters.ColorFiltering yellowfilter = new AForge.Imaging.Filters.ColorFiltering();
        AForge.Imaging.Filters.ColorFiltering greenfilter = new AForge.Imaging.Filters.ColorFiltering();
        AForge.Imaging.Filters.ColorFiltering redfilter = new AForge.Imaging.Filters.ColorFiltering();
        //AForge.Imaging.Filters.ColorFiltering bluefilter = new AForge.Imaging.Filters.ColorFiltering();
        AForge.Imaging.Filters.Threshold thresholdfilter = new AForge.Imaging.Filters.Threshold(5);
        AForge.Imaging.Filters.Dilatation morphDilate = new AForge.Imaging.Filters.Dilatation();
        AForge.Imaging.Filters.Mean meanfilter = new AForge.Imaging.Filters.Mean();
        AForge.Imaging.BlobCounter blobCounter = new AForge.Imaging.BlobCounter();
        AForge.Imaging.Filters.YCbCrExtractChannel extractFilter = new AForge.Imaging.Filters.YCbCrExtractChannel(YCbCr.YIndex);
        AForge.Vision.Motion.TwoFramesDifferenceDetector detect = new AForge.Vision.Motion.TwoFramesDifferenceDetector(true);
        Ball testBall = null;
        //String fingerDistanceValue;
        //PictureBox ballBox;
        //PictureBox pictureBox1;
        BackgroundWorker bgw;
        BackgroundWorker bgw_red;
        ExerciseScreen output;
        Debug output2;
        //double originalFingerDist;

        //sound clips;
        SoundPlayer goodJob = new SoundPlayer("again.wav");
        SoundPlayer complete = new SoundPlayer("complete.wav");
        SoundPlayer together = new SoundPlayer("together.wav");
        SoundPlayer apart = new SoundPlayer("apart.wav");
        SoundPlayer practice = new SoundPlayer("practice.wav");

        //data table stuff
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        

        //0 = bring fingers to gether, 1 it push fingers apart, 2 starting
        int direction = 2; 


        //Default constructor, pass caller so that can update picture boxes on exercise screen
        public PinchExercise(ExerciseScreen caller)
        {
            exerciseName = "Pinch Exercise";
            exerciseDescription = "This exercise is...";
            instructions = "Pinch the ball shown on the screen";
            //video = new InstructionVideo();
            video = new InstructionVideo("Pinch.wmv");
            output = caller;

        }
        
        public PinchExercise(Debug caller)
        {
            exerciseName = "Pinch Exercise";
            exerciseDescription = "This exercise is...";
            instructions = "Pinch the ball shown on the screen";
            //video = new InstructionVideo();
            video = new InstructionVideo("Pinch.wmv");
            output2 = caller;

        }
        
        
        
        public void changedir(Label instruction)
        {
            if (direction == 0 && testBall.balldistance == testBall.min_height)
            {
                instruction.Text = "Release the ball!";
                //apart.Play();
                direction = 1;
            }
            if (output.inprog.checkComplete() == true)
            {
                direction = 3;
                output.Close();
            }
            if (direction == 1 && testBall.balldistance == testBall.max_height)
            {

                //goodJob.Play();
                //together.Play();

                goodJob.Play();
                output.inprog.updateRepCount();
                output.label5.Text = (output.inprog.getRepCount()).ToString();
                output.label7.Text = (output.inprog.getRepsLeft()).ToString();
                direction = 0;
                together.Play();
                instruction.Text = "Squeeze the ball!";
            }
            if (direction == 2 && testBall.balldistance == testBall.max_height)
            {
                together.Play();
                //MessageBox.Show(together.SoundLocation);
                direction = 0;
            }
        }

        public void changedirdebug(Label instruction)
        {
            if (direction == 0 && testBall.balldistance == testBall.min_height)
            {
                instruction.Text = "Release the ball!";
                apart.Play();
                direction = 1;
            }
            if (output2.inprog.checkComplete() == true)
            {
                direction = 3;
                output2.Close();
            }
            if (direction == 1 && testBall.balldistance == testBall.max_height)
            {
                goodJob.Play();
                output2.inprog.updateRepCount();
                output2.label5.Text = (output2.inprog.getRepCount()).ToString();
                output2.label7.Text = (output2.inprog.getRepsLeft()).ToString();
                direction = 0;
                together.Play();
                instruction.Text = "Squeeze the ball!";
            }
            if (direction == 2 && testBall.balldistance == testBall.max_height)
            {
                //together.Play();
                //MessageBox.Show(together.SoundLocation);
                direction = 0;
            }
        }
        //Get data
        //Data analysis
        //Output to bit map
        //

        private void initbgw()
        {
            bgw = new System.ComponentModel.BackgroundWorker();
            bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            bgw_red = new System.ComponentModel.BackgroundWorker();
            bgw_red.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            bgw_red.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
        }

        public void FrameReady(object sender, ImageFrameReadyEventArgs e)
        {

            //these values are always zero, we might not even need them anymore
            //red_x = 0;
            //red_y = 0;
            //yellow_x = 0;
            //yellow_y = 0;
            //MessageBox.Show( "Red:" + red_x + "," + red_y + "Yellow:" + yellow_x + "," + yellow_y );

            PlanarImage Image = e.ImageFrame.Image;
            Bitmap bmap = PImageToBitmap(Image);
            //shrink bitmap
            bmap = shrink.Apply(bmap);
            
            ////added for testing
            Bitmap bmap2 = (Bitmap)bmap.Clone();
            
            //make copy
            colorbmap = (Bitmap)bmap.Clone();
            //bmap = FilterTest(bmap);
            
            
            //make grayscale
            bmap = gray.Apply(bmap);

            ////added for testing
            //Bitmap bmap2 = (Bitmap)bmap.Clone();

            //if no background bitmap, copy bitmap, filter, 
            if (back == null)
            {
                back = (Bitmap)bmap.Clone();
                gauss.ApplyInPlace(back);
                thresh.OverlayImage = back;
            }

            //filter.ApplyInPlace(bmap);
            gauss.ApplyInPlace(bmap);
            bmap = thresh.Apply(bmap);

            ////added for testing
            //Bitmap bmap2 = (Bitmap)bmap.Clone();

            //       sub.ApplyInPlace(depth);
            AForge.Imaging.Filters.ApplyMask amask = new AForge.Imaging.Filters.ApplyMask(bmap);
            amask.ApplyInPlace(colorbmap);



           // yellowbmap = yellowfilter.Apply(colorbmap);
          //  yellowbmap.Tag = "Yellow";


            redbmap = redfilter.Apply(colorbmap);
            redbmap.Tag = "Red";
            //redbmap2 = (Bitmap)redbmap.Clone();
            greenbmap = greenfilter.Apply(colorbmap);
            greenbmap.Tag = "Green";
            //greenbmap2 = (Bitmap)greenbmap.Clone();
            //bluebmap = bluefilter.Apply(colorbmap);
            colorbmap = extractFilter.Apply(colorbmap);
            //bmap = connectedfilter.Apply(colorbmap);
            // check objects count
            //objectCount = connectedfilter.ObjectCount;
            //colorbmap = grow.Apply(colorbmap);

            //process yellow (index finger)         

            //If new yellow blobs processed
            if (gotYellow & gotRed)
            {
                gotYellow = false;
                gotRed = false;
                
                //ball calculations
                bgw.RunWorkerAsync(redbmap);
            }

            //if (gotYellow)
            //{
            //    gotYellow = false;

            //    //ball calculations
            //    bgw.RunWorkerAsync(yellowbmap);
            //}

            //if (gotRed)
            //{
            //    gotRed = false;

            //    //ball calculations
            //    bgw_red.RunWorkerAsync(redbmap);
            //}

            //if (gotRed)
            //{
            //    gotRed = false;
            //    bgw_red.RunWorkerAsync(redbmap);
            //}

            //process red (thumb)

            //if (originalFingerDist <= 10)
            //{
            //    originalFingerDist = testBall.fingerdistance;
            //    MessageBox.Show( "Baseline distance =" + originalFingerDist );
            //}


            //fingerdistance = fingerdistance + 1;
            //MessageBox.Show( ""+ fingerdistance);

            //  fingerdistance = Math.Sqrt(Math.Pow(Math.Abs(red_x - yellow_x), 2) + Math.Pow(Math.Abs(red_y - yellow_y), 2));
            // fingerdistance = red_x;
            

            //for debug
            //output2.fingerDistanceValue.Text = testBall.fingerdistance.ToString();
            //output2.correctedDistanceValue.Text = testBall.balldistance.ToString();

            //MessageBox.Show(testBall.fingerdistance.ToString());
            testBall.UpdateBall(fingerdistance, bmap2);

            //sloppy, fix later
            testBall.health = patientHealth;


            //testBall.UpdateBall(fingerdistance);

            try
            {

                if (output != null)
                {
                    
                    output.fingerDistanceValue.Text = testBall.fingerdistance.ToString();
                    output.correctedDistanceValue.Text = testBall.balldistance.ToString();
                    output.ballBox.Image = testBall.scene;

                    //output.pictureBox1.Image = redbmap2;
                    //output.pictureBox2.Image = greenbmap2;
                    //output.pictureBox3.Image = bluebmap;

                    changedir(output.label2);
                    

                }
                //for debug
                if (output2 != null)
                {
                    output2.pictureBox1.Image = redbmap2;
                    output2.fingerDistanceValue.Text = testBall.fingerdistance.ToString();
                    output2.correctedDistanceValue.Text = testBall.balldistance.ToString();
                    output2.ballBox.Image = testBall.scene;
                    output2.pictureBox1.Image = redbmap2;
                    output2.pictureBox2.Image = greenbmap2;
                    //output2.pictureBox3.Image = bluebmap;
                    changedirdebug(output2.label2);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //output.ballBox.Image = ballBack;

            
            //for debug
            //output2.ballBox.Image = testBall.scene;
            //output2.pictureBox2.Image = greenbmap2;

            //for testing
            //output.ballBox.Image = bmap2;
            //output.ballBox.Image = colorbmap;
            //output.pictureBox2.Image = redbmap;
            //output.pictureBox2.Image = yellowbmap;
            
            //output.pictureBox2.Image = colorbmap;
        }

        Blob[] findBlobs(Bitmap bmap)
        {
            bmap = gray.Apply(bmap);
            thresholdfilter.ApplyInPlace(bmap);
            morphDilate.ApplyInPlace(bmap);
          //  morphDilate.ApplyInPlace(bmap);
          //  morphDilate.ApplyInPlace(bmap);
            meanfilter.ApplyInPlace(bmap);
            bmap = blobfilter.Apply(bmap);
            blobCounter.ProcessImage(bmap);
            Blob[] blobs = blobCounter.GetObjectsInformation();
            return blobs;
        }

        void DepthFrameReady(object sender, ImageFrameReadyEventArgs e)
        {
            PlanarImage Image = e.ImageFrame.Image;
            depth = DepthToBitmap(Image);
        }

        Bitmap PImageToBitmap(PlanarImage PImage)
        {
            Bitmap bmap = new Bitmap(PImage.Width, PImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0, PImage.Width, PImage.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(PImage.Bits, 0, ptr, PImage.Width * PImage.Height * PImage.BytesPerPixel);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }

        Bitmap DepthToBitmap(PlanarImage PImage)
        {
            Bitmap bmap = new Bitmap(PImage.Width, PImage.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0, PImage.Width, PImage.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(PImage.Bits, 0, ptr, PImage.Width * PImage.BytesPerPixel * PImage.Height);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }

        int getValue(PlanarImage PImage, int x, int y)
        {
            int d = PImage.Bits[x * PImage.BytesPerPixel + y * PImage.Width * PImage.BytesPerPixel + 1];
            d <<= 8;
            d += PImage.Bits[x * PImage.BytesPerPixel + y * PImage.Width * PImage.BytesPerPixel];
            return d;
        }

        Bitmap FilterTest(Bitmap img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < 480; j++)
                {
                    if (img.GetPixel(i, j) == Color.Black)
                    {
                        img.SetPixel(i, j, Color.White);
                    }
                }
            }
            return img;
        }


        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Bitmap bmap = e.Argument as Bitmap;
            //e.Result = (Blob[])findBlobs(bmap);

            blobsyellow = (Blob[])findBlobs(greenbmap);
            blobsred = (Blob[])findBlobs(redbmap);
            int maxBlobgreen = 0;
            int maxBlobred = 0;
            int redblobcount = 0;
            int greenblobcount = 0;

            foreach (Blob blob in blobsyellow)
            {
                if (blob.Area >= 200)
                {
                    if (blob.Area > maxBlobgreen)
                    {
                        maxBlobgreen = blob.Area;
                        this.testBall.yellowx = (double)(blob.Rectangle.X + blob.Rectangle.Width / 2);
                        this.testBall.yellowy = (double)(blob.Rectangle.Y + blob.Rectangle.Height / 2);
                       // this.testBall.yellowx = blob.CenterOfGravity.X;
                       // this.testBall.yellowy = blob.CenterOfGravity.Y;
                        //greenblobcount++;
                    }
                }

            }
          //  MessageBox.Show("Biggest Green blob" + maxBlobgreen);
            
            foreach (Blob blob in blobsred)
            {
                if (blob.Area >= 200)
                {
                    if (blob.Area > maxBlobred)
                    {
                        maxBlobred = blob.Area;
                        this.testBall.redx = (double)(blob.Rectangle.X + blob.Rectangle.Width / 2);
                        this.testBall.redy = (double)(blob.Rectangle.Y + blob.Rectangle.Height / 2);
                       // this.testBall.redx = blob.CenterOfGravity.X;
                       // this.testBall.redy = blob.CenterOfGravity.Y;
                        //redblobcount++;
                    }
                }

            }
            //MessageBox.Show("Biggest red blob" + maxBlobred);
            //MessageBox.Show("Green blobs" + greenblobcount + "Red blobs" +redblobcount);
        }


        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //blobsyellow = e.Result as Blob[];
            //foreach (Blob blob in blobsyellow)
            //{
            //    if (blob.Area >= 10)
            //    {
            //        this.testBall.yellowx = (double)(blob.Rectangle.X + blob.Rectangle.Width / 2);
            //        this.testBall.yellowy = (double)(blob.Rectangle.Y + blob.Rectangle.Height / 2);
            //    }

            //}
            gotYellow = true;
            gotRed = true;
        }

        private void bgw_red_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap bmap = e.Argument as Bitmap;
            e.Result = (Blob[])findBlobs(bmap);
        }

        private void bgw_red_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //blobsred = (Blob[])e.Result;
            //foreach (Blob blob in blobsred)
            //{
            //    if (blob.Area >= 10)
            //    {
            //        this.testBall.redx = (double)(blob.Rectangle.X + blob.Rectangle.Width / 2);
            //        this.testBall.redy = (double)(blob.Rectangle.Y + blob.Rectangle.Height / 2);
            //    }

            //}
            gotRed = true;

        }


        //comboBoxHealth  Functions

        public void setHealth(int health)
        {
            patientHealth = health;
        }

        public void start()
        {
            nui.Initialize(RuntimeOptions.UseColor);
            //nui.Initialize(RuntimeOptions.UseColor | RuntimeOptions.UseDepth);
            nui.VideoStream.Open(ImageStreamType.Video, 2, ImageResolution.Resolution640x480, ImageType.Color);
            nui.VideoFrameReady += new EventHandler<ImageFrameReadyEventArgs>(FrameReady);

        //    nui.DepthStream.Open(ImageStreamType.Depth, 2, ImageResolution.Resolution320x240, ImageType.Depth);
          //  nui.DepthFrameReady += new EventHandler<ImageFrameReadyEventArgs>(DepthFrameReady);

            blobfilter.MinWidth = 2;
            blobfilter.MinHeight = 2;
            initbgw();
            ////Set up color parameters for red and yellow color filters
            ////yellowfilter.Red = new IntRange(100, 255);
            ////yellowfilter.Green = new IntRange(100, 255);
            ////yellowfilter.Blue = new IntRange(0, 10);
            ////redfilter.Red = new IntRange(30, 255);
            ////redfilter.Green = new IntRange(0, 20);
            ////redfilter.Blue = new IntRange(0, 20); 
            //yellowfilter.Red = new IntRange(0, 45);
            //yellowfilter.Green = new IntRange(50, 255);
            //yellowfilter.Blue = new IntRange(0, 45);
            //redfilter.Red = new IntRange(153, 255);
            //redfilter.Green = new IntRange(0, 102);
            //redfilter.Blue = new IntRange(0, 102);
            //greenfilter.Red = new IntRange(0, 153);
            //greenfilter.Green = new IntRange(153, 255);
            //greenfilter.Blue = new IntRange(0, 153);
            testBall = new Ball(ballBack, 3000.00);
            yellowfilter.Red = new IntRange(0, 45);
            yellowfilter.Green = new IntRange(50, 255);
            yellowfilter.Blue = new IntRange(0, 45);
            redfilter.Red = new IntRange(30, 255);
            redfilter.Green = new IntRange(0, 20);
            redfilter.Blue = new IntRange(0, 20);
            greenfilter.Red = new IntRange(0, 50);
            greenfilter.Green = new IntRange(50, 255);
            greenfilter.Blue = new IntRange(0, 70);
            //bluefilter.Red = new IntRange(0, 70);
            //bluefilter.Green = new IntRange(0, 70);
            //bluefilter.Blue = new IntRange(185, 255);

            //testBall.resetBall();
        }


        public void end()
        {
            nui.Uninitialize();


            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=useitlab;Database=UserData;");
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("UPDATE exerciseinfo SET repscompleted ="+output.inprog.getRepCount()+ " where exercisenum =" + output.inprog.getExerciseNum(), conn);
            int rowsadded = command.ExecuteNonQuery();

            command = new NpgsqlCommand("UPDATE exerciseinfo SET attempt =" + output.inprog.getRepCount() + " where exercisenum =" + output.inprog.getExerciseNum(), conn);


            //get then update attempts array
            string sql = "SELECT attempt FROM exerciseinfo WHERE exercisenum =" + output.inprog.getExerciseNum();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            //update exercise attempt array
            int[] attempts = new int[dt.Rows[0].ItemArray.Length + 1]; 
            dt.Rows[0].ItemArray.CopyTo(dt.Rows[0].ItemArray,0);

            attempts[dt.Rows[0].ItemArray.Length] = output.inprog.getRepCount();

            //build array string to pass into SQL statement
            string arrstring = "{";

            for (int i = 0; i < attempts.Length; i++)
            {
                arrstring += (attempts[i].ToString());
                arrstring += ",";
            }

            arrstring += output.inprog.getRepCount().ToString();
            arrstring += "}";

            command = new NpgsqlCommand("UPDATE exerciseinfo SET attempt = '" + arrstring + "' where exercisenum =" + output.inprog.getExerciseNum().ToString(), conn);
            rowsadded = command.ExecuteNonQuery();

            if (output.inprog.checkComplete() == true)
            {

                //complete.Play();


                //If exercise completed, update database accordingly
                //Could probably replace with internal database function...
                command = new NpgsqlCommand("UPDATE exerciseinfo SET completed = TRUE where exercisenum =" + output.inprog.getExerciseNum(), conn);
                rowsadded = command.ExecuteNonQuery();
                complete.Play();
                output.popup.show("Good work! \n You completed the exercise.");
                //MessageBox.Show("Good work! You completed the exercise.");
                
            }
            else
            {
                //practice.Play();
                output.popup.show("Good work!");
                //MessageBox.Show("Good work!");
                
            }
            conn.Close();
            // add more stuff here
        }

    }
}
