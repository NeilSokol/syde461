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
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int todayExercise = 0;
        //initialization of screen
        //passes in user info from login screen
        public WelcomeScreen(UserInfo loginInfo)
        {
            user = loginInfo;
            username = loginInfo.getUsername();
            InitializeComponent();

            //Check if any exercises need to be done
             NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=useitlab;Database=UserData;");
             conn.Open();
             
            //get all uncompleted exercises for dates before todays date
             string today = DateTime.Today.ToShortDateString();
            string sql = "SELECT exercisenum FROM exerciseinfo WHERE (date < '"+today+"') AND (usernum = (SELECT usernum FROM userinfo WHERE username ='"+loginInfo.getUsername()+"')) AND (completed = false)";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            if (dt.Rows.Count == 0)
            {
                
            }
            else
            {
                todayExercise = (int)dt.Rows[0].ItemArray[0];
            }
                this.label1.Text = "Welcome " + username + "!";
                conn.Close();
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
            if (dt.Rows.Count > 0)
            {
                ExerciseScreen exerciseScreen = new ExerciseScreen(username, todayExercise);
                exerciseScreen.ShowDialog();
            }
            else 
            {
                MessageBox.Show("You have no Exercises for Today");
            }
            //// Create new debug screen and show to user
            //Debug exerciseScreen = new Debug(username);
            //exerciseScreen.ShowDialog();
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
