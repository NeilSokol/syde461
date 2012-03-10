using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;
namespace SYDE461_UI
{
    // This class is for displaying the main menu to the user
    public partial class WelcomeScreen : Form
    {
        //Screen must have access to user info
        UserInfo user = new UserInfo();
        String username;
        DataSet ds;
        DataTable dt;
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
            /*
            //check if user has any exercises for today
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=useitlab;Password=abc123;Database=UserData;");
            conn.Open();

            DateTime today = DateTime.Today;

            string sql = "select * from exercisedata where date='" +  + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            */

            //Explain exercise to the user


            // Create new exercise screen and show to user
            ExerciseScreen exerciseScreen = new ExerciseScreen(username);
            exerciseScreen.ShowDialog();
        }

        // When user selects user history screen
        private void button2_Click(object sender, EventArgs e)
        {
            //Create user history screen and show to user
            UserHistoryScreen UserHistory = new UserHistoryScreen(user);
            UserHistory.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
