using System;
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

namespace SYDE461_UI
{
    public partial class ExerciseScreen : Form
    {
        Runtime nui = new Runtime();
        Bitmap back;
        Bitmap depth;
        Bitmap colorbmap;
        Bitmap redbmap;
        Bitmap yellowbmap;
        Blob[] blobs;
        Blob[] blobsred;
        Blob[] blobsyellow;
        double red_x;
        double red_y;
        double yellow_x;
        double yellow_y;
        double fingerdistance;
        int objectCount;
        bool gotRed = true;
        bool gotYellow = true;
        Bitmap ballBack = new Bitmap(320, 240);
        AForge.Imaging.Filters.Subtract sub;
        AForge.Imaging.Filters.GrayscaleRMY gray = new AForge.Imaging.Filters.GrayscaleRMY();
        AForge.Imaging.Filters.ThresholdedDifference thresh = new AForge.Imaging.Filters.ThresholdedDifference(10);
        AForge.Imaging.Filters.GaussianBlur gauss = new AForge.Imaging.Filters.GaussianBlur(5, 1);
        AForge.Imaging.Filters.ResizeBilinear shrink = new AForge.Imaging.Filters.ResizeBilinear(320,240);
        AForge.Imaging.Filters.ResizeBilinear grow = new AForge.Imaging.Filters.ResizeBilinear(640, 480);
        AForge.Imaging.Filters.BlobsFiltering blobfilter = new AForge.Imaging.Filters.BlobsFiltering();
        AForge.Imaging.Filters.ConnectedComponentsLabeling connectedfilter = new AForge.Imaging.Filters.ConnectedComponentsLabeling();
        AForge.Imaging.Filters.ColorFiltering yellowfilter = new AForge.Imaging.Filters.ColorFiltering();
        AForge.Imaging.Filters.ColorFiltering redfilter = new AForge.Imaging.Filters.ColorFiltering();
        AForge.Imaging.Filters.Threshold thresholdfilter = new AForge.Imaging.Filters.Threshold(10);
        AForge.Imaging.Filters.Dilatation morphDilate = new AForge.Imaging.Filters.Dilatation();
        AForge.Imaging.Filters.Mean meanfilter = new AForge.Imaging.Filters.Mean();
        AForge.Imaging.BlobCounter blobCounter = new AForge.Imaging.BlobCounter();
        AForge.Imaging.Filters.YCbCrExtractChannel extractFilter = new AForge.Imaging.Filters.YCbCrExtractChannel(YCbCr.YIndex);
        AForge.Vision.Motion.TwoFramesDifferenceDetector detect = new AForge.Vision.Motion.TwoFramesDifferenceDetector(true);
        WindowsFormsApplication1.Ball testBall = null;
        private Thread redThread;
        private Thread yellowThread;

        public void FrameReady(object sender, ImageFrameReadyEventArgs e)
        {
            red_x = 0;
            red_y = 0;
            yellow_x = 0;
            yellow_y = 0;
            PlanarImage Image = e.ImageFrame.Image;
            Bitmap bmap = PImageToBitmap(Image);
            bmap = shrink.Apply(bmap);
            colorbmap = (Bitmap)bmap.Clone();
            //bmap = FilterTest(bmap);
            bmap = gray.Apply(bmap);
            
            if (back == null)
            {
                back = (Bitmap) bmap.Clone();
                gauss.ApplyInPlace(back);
                thresh.OverlayImage = back;
            }

            //filter.ApplyInPlace(bmap);
            gauss.ApplyInPlace(bmap);
            bmap = thresh.Apply(bmap);
     //       sub.ApplyInPlace(depth);
            AForge.Imaging.Filters.ApplyMask amask = new AForge.Imaging.Filters.ApplyMask(bmap);
            amask.ApplyInPlace(colorbmap);

            yellowbmap = yellowfilter.Apply(colorbmap);
            redbmap = redfilter.Apply(colorbmap);
            colorbmap = extractFilter.Apply(colorbmap);
            //pictureBox1.Image = bmap;
            //bmap = connectedfilter.Apply(colorbmap);
            // check objects count
            //objectCount = connectedfilter.ObjectCount;
            //colorbmap = grow.Apply(colorbmap);

            //process yellow (index finger)         

            //If new yellow blobs processed
            if (gotYellow)
            {
                gotYellow = false;

                try
                {
                    bgw.RunWorkerAsync(yellowbmap.Clone());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("YELLOW THREAD FAIL!!!");
                }
            }

            if (gotRed)
            {
                gotRed = false;
                try
                {
                    bgw_red.RunWorkerAsync(redbmap.Clone());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Red THREAD FAIL!!!");
                }
            }

            //process red (thumb)

              

                     

              fingerdistance = Math.Sqrt(Math.Pow(Math.Abs(red_x - yellow_x), 2) + Math.Pow(Math.Abs(red_y - yellow_y), 2));
              fingerdistance = red_x;
              //make sure distance not zero
              if (fingerdistance <= 0)
              {
                  fingerdistance = 1;
              }
              fingerDistanceValue.Text = fingerdistance.ToString();
              
           /*   if (fingerdistance<= 120)
              {
                  fingerdistance += 1;
              }
              else
              {
                  fingerdistance = 1;
              }
            */
              testBall.UpdateBall((int)(fingerdistance));
            
              pictureBox1.Image = redbmap;
              //ballBox.Image = ballBack;
              ballBox.Image = yellowbmap;
        }

        private Blob[] findBlobs(Bitmap bmap)
        {
            try
            {
                bmap = gray.Apply(bmap);
                thresholdfilter.ApplyInPlace(bmap);
                morphDilate.ApplyInPlace(bmap);
                morphDilate.ApplyInPlace(bmap);
                morphDilate.ApplyInPlace(bmap);
                meanfilter.ApplyInPlace(bmap);
                blobfilter.ApplyInPlace(bmap);
                blobCounter.ProcessImage(bmap);
                Blob[] blobs = blobCounter.GetObjectsInformation();
                return blobs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("findBlobs failed");
                return blobs;
            }
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
            BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0, PImage.Width,PImage.Height),ImageLockMode.WriteOnly,bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(PImage.Bits,0,ptr,PImage.Width *PImage.BytesPerPixel *PImage.Height);
            bmap.UnlockBits(bmapdata);
            return bmap;
            }

        int getValue(PlanarImage PImage,int x, int y)
        {
            int d = PImage.Bits[x *PImage.BytesPerPixel +y * PImage.Width *PImage.BytesPerPixel + 1];
            d <<= 8;
            d += PImage.Bits[x * PImage.BytesPerPixel +y * PImage.Width *PImage.BytesPerPixel];
            return d;
        }

        Bitmap FilterTest(Bitmap img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < 480; j++)
                {
                    if (img.GetPixel(i,j) == Color.Black)
                    {
                        img.SetPixel(i, j, Color.White);
                    }
                }
            }
            return img;
        }
        public ExerciseScreen()
        {
            InitializeComponent();
        }

        private void ExerciseScreen_Load(object sender, EventArgs e)
        {
            nui.Initialize(RuntimeOptions.UseColor|RuntimeOptions.UseDepth);
            nui.VideoStream.Open(ImageStreamType.Video, 2, ImageResolution.Resolution640x480, ImageType.Color);
            nui.VideoFrameReady += new EventHandler<ImageFrameReadyEventArgs>(FrameReady);

             nui.DepthStream.Open(ImageStreamType.Depth, 2, ImageResolution.Resolution320x240, ImageType.Depth);
             nui.DepthFrameReady += new EventHandler<ImageFrameReadyEventArgs>(DepthFrameReady);

            blobfilter.MinWidth = 2;
            blobfilter.MinHeight = 2;

            //Set up color parameters for red and yellow color filters
            yellowfilter.Red = new IntRange(100, 255);
            yellowfilter.Green = new IntRange(100, 255);
            yellowfilter.Blue = new IntRange(0, 10);
            redfilter.Red = new IntRange(20, 255);
            redfilter.Green = new IntRange(0, 20);
            redfilter.Blue = new IntRange(0, 20);
            testBall = new WindowsFormsApplication1.Ball(ballBack, 1600);
        }

        private void ExerciseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            nui.Uninitialize();
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap bmap = e.Argument as Bitmap;
            e.Result = (Blob[])findBlobs(bmap);
        }
        
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            blobsyellow = (Blob[])e.Result;
            if (blobsyellow.Length > 0)
            {
                foreach (Blob blob in blobsyellow)
                {
                    if (blob.Area >= 10)
                    {
                        this.yellow_x = (double)(blob.Rectangle.X + blob.Rectangle.Width / 2);
                        yellow_y = (double)(blob.Rectangle.Y + blob.Rectangle.Height / 2);
                    }

                }
            }
            gotYellow = true;
        }

        private void bgw_red_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap bmap = e.Argument as Bitmap;
            e.Result = (Blob[])findBlobs(bmap);
        }

        private void bgw_red_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            blobsred = (Blob[])e.Result;

            if (blobsred.Length > 0)
            {
                foreach (Blob blob in blobsred)
                {
                    if (blob.Area >= 3)
                    {
                        this.red_x = (double)(blob.Rectangle.X + blob.Rectangle.Width / 2);
                        red_y = (double)(blob.Rectangle.Y + blob.Rectangle.Height / 2);
                    }

                }
            }
            gotRed = true;
        }
    }
}
