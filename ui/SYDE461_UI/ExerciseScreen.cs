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
        PinchExercise exercise;
        
        
        public ExerciseScreen(String username)
        {
            user = username;
            InitializeComponent();
        }

        private void ExerciseScreen_Load(object sender, EventArgs e)
        {

            InstructionVideo vid = new InstructionVideo("Pinch.wmv");
            //vid.ShowDialog();
            //this.label2.Text = vid.vidLocation;

            exercise = new PinchExercise(this);
            this.comboBoxHealth.SelectedItem = "No Stroke";
            exercise.start();
            //add analysis stuff
        }

        

        private void ExerciseScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            exercise.end();
        }

        private void comboBoxHealth_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBoxHealth.SelectedItem.ToString())
            {
                case "No Stroke":
                    exercise.setHealth(0);
                break;
                case "6 Month Recovery":
                    exercise.setHealth(1);
                break;
                case "1 Month Recoverye":
                    exercise.setHealth(2);
                break;
                case "Severe Stroke":
                    exercise.setHealth(3);
                break;
            };
        }

    }
}
