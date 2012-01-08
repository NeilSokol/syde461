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
    // This class is for displaying the main menu to the user
    public partial class WelcomeScreen : Form
    {
        //Screen must have access to user info
        UserInfo user = new UserInfo();
        String username;

        //initialization of screen
        //passes in user info from login screen
        public WelcomeScreen(UserInfo loginInfo)
        {
            user = loginInfo;
            username = loginInfo.getUsername();
            InitializeComponent();
            this.label1.Text = "Welcome " + username + "!";
            
        }

        // When user selects exercise screen
        private void button1_Click(object sender, EventArgs e)
        {

            //Explain exercise to the user


            // Create new exercise screen and show to user
            ExerciseScreen exerciseScreen = new ExerciseScreen();
            exerciseScreen.ShowDialog();
        }

        // When user selects user history screen
        private void button2_Click(object sender, EventArgs e)
        {
            //Create user history screen and show to user
            UserHistoryScreen UserHistory = new UserHistoryScreen();
            UserHistory.ShowDialog();
        }

    }
}
