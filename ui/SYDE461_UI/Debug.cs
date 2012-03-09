using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SYDE461_UI
{
    public partial class Debug : Form
    {
public String user;
        public PinchExercise exercise;
        
        
        public Debug(String username)
        {
            user = username;
            InitializeComponent();
        }

        public void Debug_Load(object sender, EventArgs e)
        {

            InstructionVideo vid = new InstructionVideo("Pinch.wmv");
            vid.ShowDialog();
            //this.label2.Text = vid.vidLocation;

            exercise = new PinchExercise(this);
            this.comboBoxHealth.SelectedItem = "No Stroke";
            exercise.start();
            //add analysis stuff
        }

        

        public void Debug_FormClosing(object sender, FormClosingEventArgs e)
        {
            exercise.end();
        }

        public void comboBoxHealth_SelectedIndexChanged(object sender, EventArgs e)
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
