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
    //This screen is for displaying login errors
    //I haven't fleshed this out yet because I
    // haven't implemented a login check  yet in LoginScreen.cs
    public partial class LoginFail : Form
    {
        //default constructor
        //Will probably want another constructor that will pass in
        //error info
        public LoginFail()
        {
            InitializeComponent();
        }
    }
}
