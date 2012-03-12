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
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace SYDE461_UI
{
    // This class is for collecting exercise information
    public class ExerciseData
    {
        public String exerciseName;
        public String exerciseDescription;
        public String instructions;
        //public InstructionVideo video;
        public  Runtime nui = new Runtime();

        public void initializeKinect()
        {
            nui.Initialize(RuntimeOptions.UseColor | RuntimeOptions.UseDepth);
        }

        public void uninitializeKinect()
        {
            nui.Uninitialize();
        }
        //THINGS TO INCLUDE: 
        //exercise name
        //exercise description
        //exercise instructions
        //exercise video
        //    
    }
}
