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
        String imageloc;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        NpgsqlConnection conn;
        public UserHistoryScreen(UserInfo username)
        {
            user = username;
            
            //connect to database, attempt to get list of exercises to populate listbox
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=useitlab;Database=UserData;");
            conn.Open();
            string sql = "SELECT * FROM ExerciseInfo WHERE usernum IN (SELECT usernum FROM UserInfo WHERE username ="+username.ToString();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            exerciseGridView.DataSource = dt;
            if (dt.Rows.Count == 0)
            {

            }

            //SELECT * FROM ExerciseInfo WHERE usernum IN (SELECT usernum FROM UserInfo WHERE username = 'Neil')

            //sessionList.ObjectCollection = 
            InitializeComponent();



        }

        private void sessionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = sessionList.SelectedItem.ToString();

            // Find the string in ListBox2.
            //int index = listBox2.FindString(curItem);
            
            String referencePath = Directory.GetCurrentDirectory();
            String relativePath = "...\\...\\" + curItem + ".jpg";
            imageloc = Path.GetFullPath(Path.Combine(referencePath, relativePath));
            label1.Text = imageloc;

            try
            {

                //pictureBox1.Image = System.Drawing.Image.FromFile(imageloc);
                //sessionList.SelectedItem.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }





        private void close_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

    }
}
