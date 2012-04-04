using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace doctorInterface
{
    public partial class mainScreen : Form
    {

        public mainScreen()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            InitializeComponent();
            ampLabel.Text = (((double)ampTrackBar.Value / 10)).ToString();
            repCountLabel.Text = repTrackBar.Value.ToString();

            //Connect to paitent database
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=useitlab;Database=UserData;");
            conn.Open();

            //grab user data
            string sql = "SELECT username FROM userinfo";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                patientListbox.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }

            conn.Close();

            patientListbox.SelectedIndex = 0;
        }

        private void ampTrackBar_ValueChanged(object sender, EventArgs e)
        {
            ampLabel.Text = (((double)ampTrackBar.Value / 10)).ToString();
        }

        private void repTrackBar_ValueChanged(object sender, EventArgs e)
        {
            repCountLabel.Text = repTrackBar.Value.ToString();
        }

        private void addExerciseButton_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=useitlab;Database=UserData;");
            conn.Open();

            string sql = "SELECT MAX(exercisenum) FROM exerciseinfo";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                int exercisenum_new = (int)dt.Rows[0].ItemArray[0] + 1;
                //Build SQL string to add exercise
                sql = "INSERT INTO exerciseinfo VALUES ((SELECT usernum FROM userinfo WHERE username ='" + patientListbox.SelectedItem.ToString() + "'), '" + exerciseDate.Value.ToShortDateString() + "','"+exerciseComboBox.Text.ToString()+"',FALSE,"+((double)ampTrackBar.Value / 10).ToString()+"," + exercisenum_new.ToString() + ","+repTrackBar.Value.ToString()+",0,'{0}')";
                
                //generate new exercise, insert into database
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                int rowsadded = command.ExecuteNonQuery();

                if (rowsadded > 0)
                {
                    MessageBox.Show("Exercise Successfully Added for "+patientListbox.SelectedItem.ToString());
                    exerciseDataGrid.Refresh();
                }
                else
                {
                    MessageBox.Show("ERROR: Failed to Add Exercise");
                }

            }
        }

        private void patientListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            //Load patient's exercises
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=useitlab;Database=UserData;");
            conn.Open();
            string sql = "SELECT * FROM ExerciseInfo WHERE usernum IN (SELECT usernum FROM UserInfo WHERE username ='" + patientListbox.SelectedItem.ToString() + "')";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            exerciseDataGrid.DataSource = dt;
            conn.Close();
        }
    }
}
