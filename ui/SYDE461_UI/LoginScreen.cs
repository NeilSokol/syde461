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
    // This class is for display the login screen of the UI
    public partial class LoginScreen : Form
    {
        //create holders for user input
        String username = "";
        String password = "";

        //User Dictionary Storage
        public Dictionary<String, String> storedusers = new Dictionary<string,string>();

        // create a holder in case need to create a new user
        // This seems really sloppy, so we'll probably change this
        //CreateNewUser NewUser;

        //Default constructor
        public LoginScreen()
        {
            InitializeComponent();
        }
        //Button for loging in user
        //We should really rename these buttons into something more descriptive
        private void loginButton_Click(object sender, EventArgs e)
        {

            //create a UserInfo instance with the user input
            UserInfo loginInfo = new UserInfo(textBox1.Text, textBox2.Text);

            //Insert check for username and password
            //Need to check user input to all existing UserInfo instances

            //If the user input matchs existing user information then open the user's welcomescreen and info
            if (storedusers.ContainsKey(loginInfo.getUsername()))
            {
                if (storedusers[loginInfo.getUsername()] == textBox2.Text)
                {
                    //Create and show a main menu screen for the specific user
                    WelcomeScreen MainMenu = new WelcomeScreen(loginInfo, this);
                    MainMenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error! Invalid password!");
                }
            }
            else
            {
                // If the login fails show a screen that will inform the user
                // Should provide useful information to user
                MessageBox.Show("Error! Invalid user name!");
               // LoginFail failed = new LoginFail();
            }
        }


        //Button for creating a new user
        //We should really rename these buttons into something more descriptive
        private void createUser_Click(object sender, EventArgs e)
        {

            CreateNewUser NewUser = new CreateNewUser(this);
            NewUser.ShowDialog();
            UserInfo newInfo = NewUser.getuserinput();
            this.fillUsernameAndPass(NewUser, newInfo);

            //NewUser.Close();

            //UserControl1 NewUser2 = new UserControl1();

        }

        public void fillUsernameAndPass(CreateNewUser newUser, UserInfo newInfo)
        {
            textBox1.Text = newInfo.getUsername();
            textBox2.Text = newInfo.getPassword();
            newUser.Close();

            //UserControl1 NewUser2 = new UserControl1();

        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            //Check if user information file exists, create if not
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\userlist.txt"))
            {
               FileStream fs = File.Create(Directory.GetCurrentDirectory() + "\\userlist.txt");
               fs.Close();
            }
            //read in current user info file
            try
            {
                string[] readText = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\userlist.txt");
                
                //for now, assume user info stored in adjacent username/password pairs
                for (int i = 0; i < readText.Length; i+=2)
                {
                    if (!storedusers.ContainsKey(readText[i].ToString()))
                    storedusers.Add(readText[i].ToString(),readText[i+1].ToString());
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
