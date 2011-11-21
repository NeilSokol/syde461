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
    public partial class CreateNewUser : Form
    {

        String username = "test";
        String password = "password";
        UserInfo newUser= new UserInfo();
        LoginScreen caller;

        public CreateNewUser(LoginScreen logscreen)
        {          
            InitializeComponent();
            caller = logscreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newUser.setUserInfo(textBox1.Text, textBox2.Text);
            caller.fillUsernameAndPass(this, newUser);
            this.Close();
        }

        public UserInfo getuserinput()
        {
           return newUser;
        }

    }
}
