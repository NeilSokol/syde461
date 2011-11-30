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
using AForge.Imaging;
using AForge.Vision;
using AForge;

namespace SYDE461_UI
{
    public partial class ExerciseScreen : Form
    {
        Runtime nui = new Runtime();
        Bitmap back;
        Bitmap colorbmap;
        Bitmap redbmap;
        Bitmap yellowbmap;
        Blob[] blobs;
        double red_x;
        double red_y;
        double yellow_x;
        double yellow_y;
        double fingerdistance;
        int objectCount;
        Bitmap ballBack = new Bitmap(320, 240);
        AForge.Imaging.Filters.SobelEdgeDetector filter = new AForge.Imaging.Filters.SobelEdgeDetector();
        AForge.Imaging.Filters.GrayscaleRMY gray = new AForge.Imaging.Filters.GrayscaleRMY();
        AForge.Imaging.Filters.ThresholdedDifference thresh = new AForge.Imaging.Filters.ThresholdedDifference(10);
        AForge.Imaging.Filters.GaussianBlur gauss = new AForge.Imaging.Filters.GaussianBlur(5, 1);
        AForge.Imaging.Filters.ResizeBilinear shrink = new AForge.Imaging.Filters.ResizeBilinear(160, 120);
        AForge.Imaging.Filters.ResizeBilinear grow = new AForge.Imaging.Filters.ResizeBilinear(640, 480);
        AForge.Imaging.Filters.BlobsFiltering blobfilter = new AForge.Imaging.Filters.BlobsFiltering();
        AForge.Imaging.Filters.ConnectedComponentsLabeling connectedfilter = new AForge.Imaging.Filters.ConnectedComponentsLabeling();
        AForge.Imaging.Filters.ColorFiltering yellowfilter = new AForge.Imaging.Filters.ColorFiltering();
        AForge.Imaging.Filters.ColorFiltering redfilter = new AForge.Imaging.Filters.ColorFiltering();
        AForge.Imaging.Filters.Threshold thresholdfilter = new AForge.Imaging.Filters.Threshold(10);
        AForge.Imaging.Filters.Dilatation morphDilate = new AForge.Imaging.Filters.Dilatation();
        AForge.Imaging.Filters.Mean meanfilter = new AForge.Imaging.Filters.Mean();
        AForge.Imaging.BlobCounter blobCounter = new AForge.Imaging.BlobCounter();
        AForge.Vision.Motion.TwoFramesDifferenceDetector detect = new AForge.Vision.Motion.TwoFramesDifferenceDetector(true);
        WindowsFormsApplication1.Ball testBall = null;

        void FrameReady(object sender, ImageFrameReadyEventArgs e)
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
            AForge.Imaging.Filters.ApplyMask amask = new AForge.Imaging.Filters.ApplyMask(bmap);
            amask.ApplyInPlace(colorbmap);

            yellowbmap = yellowfilter.Apply(colorbmap);
            redbmap = redfilter.Apply(colorbmap);

            //bmap = connectedfilter.Apply(colorbmap);
            // check objects count
            //objectCount = connectedfilter.ObjectCount;
            //colorbmap = grow.Apply(colorbmap);

            //process yellow (index finger)
            yellowbmap = gray.Apply(yellowbmap);
            thresholdfilter.ApplyInPlace(yellowbmap);
            morphDilate.ApplyInPlace(yellowbmap);
            morphDilate.ApplyInPlace(yellowbmap);
            meanfilter.ApplyInPlace(yellowbmap);
            blobfilter.ApplyInPlace(yellowbmap);
            blobCounter.ProcessImage(yellowbmap);
            Blob[] blobsyellow = blobCounter.GetObjectsInformation();

            foreach (Blob blob in blobsyellow)
            {
                if (blob.Area >= 10)
                {
                    yellow_x = (double)(blob.Rectangle.X + blob.Rectangle.Width / 2);
                    yellow_y = (double)(blob.Rectangle.Y + blob.Rectangle.Height / 2);
                }
 
            }

            //process red (thumb)
            redbmap = gray.Apply(redbmap);
            thresholdfilter.ApplyInPlace(redbmap);
            morphDilate.ApplyInPlace(redbmap);
            morphDilate.ApplyInPlace(redbmap);
            meanfilter.ApplyInPlace(redbmap);
            blobfilter.ApplyInPlace(redbmap);
            blobCounter.ProcessImage(redbmap);
            Blob[] blobsred = blobCounter.GetObjectsInformation();

            foreach (Blob blob in blobsred)
            {
                if (blob.Area >= 10)
                {
                    red_x = (double)(blob.Rectangle.X + blob.Rectangle.Width / 2);
                    red_y = (double)(blob.Rectangle.Y + blob.Rectangle.Height / 2);
                }

            }

            fingerdistance = Math.Sqrt(Math.Pow(Math.Abs(red_x - yellow_x), 2) + Math.Pow(Math.Abs(red_y - yellow_y), 2));
            fingerDistanceValue.Text = fingerdistance.ToString();
            testBall = new WindowsFormsApplication1.Ball(ballBack, 50);
            testBall.UpdateBall((int)(fingerdistance));
            pictureBox1.Image = colorbmap;
            ballBox.Image = ballBack;
        }

        void DepthFrameReady(object sender, ImageFrameReadyEventArgs e)
        {
            PlanarImage Image = e.ImageFrame.Image;
            Bitmap depthmap = DepthToBitmap(Image);
         //   pictureBox2.Image = depthmap;
        }

        Bitmap PImageToBitmap(PlanarImage PImage)
        {
            Bitmap bmap = new Bitmap(PImage.Width, PImage.Height, PixelFormat.Format32bppRgb);
            BitmapData bmapdata = bmap.LockBits(new Rectangle(0, 0, PImage.Width, PImage.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(PImage.Bits, 0, ptr, PImage.Width * PImage.Height * PImage.BytesPerPixel);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }

        Bitmap DepthToBitmap(PlanarImage PImage)
        {
            Bitmap bmap = new Bitmap(PImage.Width,PImage.Height,PixelFormat.Format16bppRgb555);
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
            nui.Initialize(RuntimeOptions.UseColor);
            nui.VideoStream.Open(ImageStreamType.Video, 2, ImageResolution.Resolution640x480, ImageType.Color);
            nui.VideoFrameReady += new EventHandler<ImageFrameReadyEventArgs>(FrameReady);

            // nui.DepthStream.Open(ImageStreamType.Depth, 2, ImageResolution.Resolution320x240, ImageType.Depth);
            // nui.DepthFrameReady += new EventHandler<ImageFrameReadyEventArgs>(DepthFrameReady);

            blobfilter.MinWidth = 10;
            blobfilter.MinHeight = 10;

            //Set up color parameters for red and yellow color filters
            yellowfilter.Red = new IntRange(50, 255);
            yellowfilter.Green = new IntRange(100, 255);
            yellowfilter.Blue = new IntRange(0, 2);
            redfilter.Red = new IntRange(100, 255);
            redfilter.Green = new IntRange(0, 2);
            redfilter.Blue = new IntRange(0, 2);
        }

        private void ExerciseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            nui.Uninitialize();
        }
    }
}
