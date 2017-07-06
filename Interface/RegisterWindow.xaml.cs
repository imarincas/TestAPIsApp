using AppManagement.Controller;
using System.Windows;


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
