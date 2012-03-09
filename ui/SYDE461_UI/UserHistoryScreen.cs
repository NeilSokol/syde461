using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SYDE461_UI
{
    // This class is for the UI component of displaying user activity
    public partial class UserHistoryScreen : Form
    {
        UserInfo user;
        String imageloc;

        public UserHistoryScreen(UserInfo username)
        {
            user = username;
            
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
            this.Close();
        }

    }
}
