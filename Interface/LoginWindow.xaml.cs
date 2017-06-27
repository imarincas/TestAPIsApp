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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var userRepo = new UsersRepository();
            var user = userRepo.GetUser(txt_Username.Text);

            byte[] data = Encoding.ASCII.GetBytes(txt_Password.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashedPassword = Encoding.ASCII.GetString(data);

            if (!string.IsNullOrEmpty(txt_Username.Text) && !string.IsNullOrEmpty(txt_Password.Password))
            {
                if (txt_Username.Text == user.Username && hashedPassword == user.Password)
                {
                    // MessageBox.Show("Login succesfully");
                    this.Hide();
                    MainWindow main = new MainWindow(user);
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!");
                }
            }
            else
            {
                MessageBox.Show("Please type username and password!");
            }
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            this.Hide();
            register.Show();
        }
    }
}
