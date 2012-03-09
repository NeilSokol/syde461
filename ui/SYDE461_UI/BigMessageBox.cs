using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SYDE461_UI
{
    public partial class BigMessageBox : Form
    {
        public BigMessageBox()
        {
            InitializeComponent();
        }
        
        public BigMessageBox(String text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        public void show(String text)
        {
            label1.Text = text;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
