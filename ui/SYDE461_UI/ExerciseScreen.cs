/*TO DO TOMORROW! PUT BOTH RED AND YELLOW PROCESSIGN THREADS INTO ONE, SHOULD PREVENT ISSUE WITH CURRENT UNKNOWN INVOKE EXCEPTION*/


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
    public partial class ExerciseScreen : Form
    {
        String user;
        
        public ExerciseScreen(String username)
        {
            user = username;
            InitializeComponent();
        }

        private void ExerciseScreen_Load(object sender, EventArgs e)
        {

            InstructionVideo vid = new InstructionVideo("Pinch.wmv");
            vid.ShowDialog();
            this.label2.Text = vid.vidLocation;
        }

        

        private void ExerciseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

    }
}
