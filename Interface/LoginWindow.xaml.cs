using AppManagement.Controller;
using AppManagement.Models;
using System.Windows;

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
            if (!string.IsNullOrEmpty(txt_Username.Text) && !string.IsNullOrEmpty(txt_Password.Password))
            {
               var user = new User();
               user = UserController.LoginUser(txt_Username.Text, txt_Password.Password);
                if (user!=null)
                {
                    if (!string.IsNullOrEmpty(servicename.Text))
                    {
                        user.ServiceName = servicename.Text;
                    }
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
