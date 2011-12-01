using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
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
            
            //find better way then exposing storedusers like this
            if (caller.storedusers.ContainsKey(textBox1.Text))
            {
                MessageBox.Show("This user already exists");
            }
            else
            {
                caller.storedusers.Add(textBox1.Text, textBox2.Text);
                caller.fillUsernameAndPass(this, newUser);
                //add to user file
                try
                {
                    //open file. Login screen should have created if not there so append
                    StreamWriter writestream = new StreamWriter("userlist.txt", true);
                    writestream.WriteLine(textBox1.Text);
                    writestream.WriteLine(textBox2.Text);
                    writestream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //Add another exeption handler for if the username is already in the dictionary

                this.Close();
            
            }
            
        }

        public UserInfo getuserinput()
        {
           return newUser;
        }

    }
}
