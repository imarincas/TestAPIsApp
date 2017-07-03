using DataAccess.DTO;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserManagement;

namespace Interface
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_username.Text))
            {
                if (!UserController.CheckUsername(txt_username.Text))
                {
                    if (UserController.RegisterUser(txt_username.Text, passwordBox.Password, txt_firstname.Text, txt_lastname.Text, txt_email.Text))
                    {
                        MessageBox.Show("Registration succesfully.");
                        this.Hide();
                        LoginWindow lgn = new LoginWindow();
                        lgn.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error while registration.");

                    }
                }
                else
                {
                    MessageBox.Show("User already exists.");
                }
            }
        }
    }
}
