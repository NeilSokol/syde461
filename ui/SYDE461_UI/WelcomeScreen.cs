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
    public partial class WelcomeScreen : Form
    {
        UserInfo user = new UserInfo();

        public WelcomeScreen(UserInfo loginInfo)
        {
            user = loginInfo;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExerciseScreen exerciseScreen = new ExerciseScreen();
            exerciseScreen.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserHistoryScreen UserHistory = new UserHistoryScreen();
            UserHistory.ShowDialog();
        }

    }
}
