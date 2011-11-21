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
    public partial class LoginScreen : Form
    {
        //create holders for user input
        String username = "";
        String password = "";

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //create a UserInfo instance with the user input
            UserInfo loginInfo = new UserInfo(textBox1.Text, textBox2.Text);

            //Insert check for username and password
            //Need to check user input to all existing UserInfo instances
            bool match = true;

            //If the user input matchs existing user information then open the user's welcomescreen and info
            if ((match == true))
            {
                WelcomeScreen MainMenu = new WelcomeScreen(loginInfo);
                MainMenu.ShowDialog();
            }
            else
            {
                LoginFail failed = new LoginFail();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateNewUser NewUser = new CreateNewUser(this);
            NewUser.ShowDialog();
            UserInfo newInfo = NewUser.getuserinput();
            textBox1.Text = newInfo.getUsername();
            textBox2.Text = newInfo.getPassword();
            NewUser.Close();

            //UserControl1 NewUser2 = new UserControl1();

        }

    }
}
