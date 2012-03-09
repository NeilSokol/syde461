using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Npgsql;

namespace SYDE461_UI
{
    public partial class CreateNewUser : Form
    {

        String username = "test";
        String password = "password";
        UserInfo newUser= new UserInfo();
        LoginScreen caller;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public CreateNewUser(LoginScreen logscreen)
        {          
            InitializeComponent();
            caller = logscreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //try to connect to user data database
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=useitlab;Password=abc123;Database=UserData;");
            conn.Open();

            
            
            /*if (caller.storedusers.ContainsKey(textBox1.Text))
            {
                MessageBox.Show("Error! User already exists!");
            }*/

            //check if name already exists
            //NpgsqlCommand command = new NpgsqlCommand("select username from userinfo where username='"+textBox1.Text+"'", conn);
           // string sql = "select username from userinfo where username='"+textBox1.Text+"'";

            string sql = "select username from userinfo where username='" + textBox1.Text + "'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql,conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            //row returned not Null, contains name already
            if (dt.Rows.Count == null)
            {
                MessageBox.Show("Error! User already exists!");
            }

            else
            {
                sql = "select * from userinfo";
                da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                int usercount = dt.Rows.Count + 1;

                //execute command to add rows
                NpgsqlCommand command = new NpgsqlCommand("INSERT into UserInfo VALUES ("+usercount.ToString()+",'"+textBox1.Text+"','"+textBox2.Text + "')",conn);
                int rowsadded = command.ExecuteNonQuery();

               /* newUser.setUserInfo(textBox1.Text, textBox2.Text);
                caller.fillUsernameAndPass(this, newUser);

                //find better way then exposing storedusers like this
                caller.storedusers.Add(textBox1.Text, textBox2.Text);

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
                */
                conn.Close();
                this.Close();
            }
        }

        public UserInfo getuserinput()
        {
           return newUser;
        }

    }
}
