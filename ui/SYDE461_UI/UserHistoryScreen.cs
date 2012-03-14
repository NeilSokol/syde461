using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace SYDE461_UI
{
    // This class is for the UI component of displaying user activity
    public partial class UserHistoryScreen : Form
    {
        UserInfo user;
        BigMessageBox error = new BigMessageBox();

        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        NpgsqlConnection conn;

        public UserHistoryScreen(UserInfo username)
        {
            user = username;
            //connect to database, attempt to get list of exercises to populate listbox
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=useitlab;Database=UserData;");
            conn.Open();
            string sql = "SELECT * FROM ExerciseInfo WHERE usernum IN (SELECT usernum FROM UserInfo WHERE username ='"+username.getUsername()+"')";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            //if no exercise data. exit
            if (dt.Rows.Count == 0)
            {
                error.show("No exercises found for user!");
                conn.Close();
                this.Close();
            }

            //SELECT * FROM ExerciseInfo WHERE usernum IN (SELECT usernum FROM UserInfo WHERE username = 'Neil')

            

            InitializeComponent();
            
            //Replace this with a list of sessions provided from database
            sessionList.Items.AddRange(new object[] { "this", "is", "a ", "test" });
            exerciseGridView.DataSource = dt;
            loadChart();
        }

        public void loadChart()
        {
            chart1.DataSource = dt;

           
            //ds3 = new DataSet();
            //dt3 = CreateChartData();

            //ds3.Tables.Add(dt3);
            //chart1.DataSource = ds3.Tables[0].DefaultView;
            ////chart1.DataSource = dv3;

            chart1.Series["Series1"].XValueMember = dt.Columns["exercisenum"].ToString();
            chart1.Series["Series1"].YValueMembers = dt.Columns["amplevel"].ToString();

            chart1.DataBind();
        }

        private void sessionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = sessionList.SelectedItem.ToString();

            // Find the string in ListBox2.
            //int index = listBox2.FindString(curItem);
            
            //String referencePath = Directory.GetCurrentDirectory();
            //String relativePath = "...\\...\\" + curItem + ".jpg";
            //imageloc = Path.GetFullPath(Path.Combine(referencePath, relativePath));
            label1.Text = curItem;

            try
            {

                //pictureBox1.Image = System.Drawing.Image.FromFile(imageloc);
                //sessionList.SelectedItem.
            }
            catch (Exception ex)
            {
                error.show(ex.ToString());
            }
        }

        private void llOpenConnAndSelect_LinkClicked(object sender,
             LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // PostgeSQL-style connection string
                NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=useitlab;Database=UserData;");
                conn.Open();
                // quite complex sql statement
                string sql = "SELECT * FROM simple_table";
                // data adapter making request from our connection
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                // i always reset DataSet before i do
                // something with it.... i don't know why :-)
                ds.Reset();
                // filling DataSet with result from NpgsqlDataAdapter
                da.Fill(ds);
                // since it C# DataSet can handle multiple tables, we will select first
                dt = ds.Tables[0];
                // connect grid to DataTable
                //chart1.DataSource = dt;
                // since we only showing the result we don't need connection anymore
                conn.Close();
            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                error.show(msg.ToString());
                throw;
            }
        }



        private void close_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

    }
}
