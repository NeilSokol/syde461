using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class LoginScreen : Form
    {
        String username = "test";
        String password = "password";

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //username = textBox1.Text;
            //password = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateNewUser NewUser = new CreateNewUser();
            NewUser.ShowDialog();
        }
    }
}
