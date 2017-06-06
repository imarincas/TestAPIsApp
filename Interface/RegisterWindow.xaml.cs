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
            var user = new UsersDTO
            {
                Username = txt_username.Text,
                Firstname = txt_firstname.Text,
                Lastname = txt_lastname.Text,
                Email = txt_email.Text,
                Password = passwordBox.Password
            };
            var userRepo = new UsersRepository();
            if (string.IsNullOrEmpty(userRepo.GetUser(txt_username.Text).Username))
            {
                if (userRepo.InsertUserInDB(user))
                {
                    MessageBox.Show("Registration succesfully.");
                    this.Hide();
                    LoginWindow lgn = new LoginWindow();
                    lgn.Show();
                }
            }else
            {
                MessageBox.Show("User already exists.");
              
            }
            
        }
    }
}
