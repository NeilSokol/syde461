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
    // This class is for the UI component of displaying user activity
    public partial class UserHistoryScreen : Form
    {
        String user;

        public UserHistoryScreen(String username)
        {
            user = username;
            InitializeComponent();
        }

    }
}
