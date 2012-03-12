using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syde462WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUser NewUser = new CreateNewUser(this);
            NewUser.ShowDialog();
            //UserInfo newInfo = NewUser.getuserinput();
            //textBox1.Text = newInfo.getUsername();
            //textBox2.Text = newInfo.getPassword();
            NewUser.Close();
        }
    }
}
