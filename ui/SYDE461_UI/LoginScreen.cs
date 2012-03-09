using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using Npgsql;

namespace SYDE461_UI
{
    
    // This class is for display the login screen of the UI
    public partial class LoginScreen : Form
    {
        //create holders for user input
        String username = "";
        String password = "";
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        BigMessageBox error = new BigMessageBox();

        //User Dictionary Storage
        public Dictionary<String, String> storedusers = new Dictionary<string,string>();

        // create a holder in case need to create a new user
        // This seems really sloppy, so we'll probably change this
        //CreateNewUser NewUser;

        //Default constructor
        public LoginScreen()
        {
            InitializeComponent();
            //textBox1.Text = Directory.GetCurrentDirectory();
        }

        //Button for creating a new user
        //We should really rename these buttons into something more descriptive
        private void loginButton_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=useitlab;Password=abc123;Database=UserData;");
            conn.Open();

            //create a UserInfo instance with the user input
            UserInfo loginInfo = new UserInfo(textBox1.Text, textBox2.Text);

            string sql = "select * from userinfo where username='" + textBox1.Text + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][2].ToString() == loginInfo.getPassword())
                {
                    WelcomeScreen MainMenu = new WelcomeScreen(loginInfo);
                    MainMenu.ShowDialog();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Error! Password is incorrect!");
                }
            }
            else
            {
                MessageBox.Show("User does not exist");
            }
            /***
            //Insert check for username and password
            //Need to check user input to all existing UserInfo instances

            //If the user input matchs existing user information then open the user's welcomescreen and info
            if (storedusers.ContainsKey(loginInfo.getUsername()))
            {
                if(storedusers[loginInfo.getUsername()] == textBox2.Text)
                {
                    //MessageBox.Show("Yay! User exists");
                    //Create and show a main menu screen for the specific user
                    WelcomeScreen MainMenu = new WelcomeScreen(loginInfo);
                    MainMenu.ShowDialog();
                }
                else
                {
                    // If the login fails show a screen that will inform the user
                    // Should provide useful information to user
                     error.show("Error! Password is incorrect!");
                    // LoginFail failed = new LoginFail();
                }
            }
            else
            {
                // If the login fails show a screen that will inform the user
                // Should provide useful information to user
                error.show("Error! Invalid user name.");
               // LoginFail failed = new LoginFail();
            } ***/


            conn.Close();

        }

        //
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

        public void fillUsernameAndPass(CreateNewUser newUser, UserInfo newInfo)
        {
            username = newInfo.getUsername();
            password = newInfo.getPassword();
            //NewUser.Close();

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
                    storedusers.Add(readText[i].ToString(),readText[i+1].ToString());
                }

            }
            catch(Exception ex)
            {
                error.show(ex.ToString());
            }
        }
    }
}
