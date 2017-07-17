using AppManagement.Controller;
using AppManagement.Models;

using System;
using System.Text;
using System.Windows;
using System.Web.UI.WebControls;



namespace Interface
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User User = new User();

        public MainWindow(User user)
        {
            InitializeComponent();
            User = user;
            this.Title = "Hello " + user.Firstname + " " + user.Lastname;
            firstname.Text = user.Firstname;
            lastname.Text = user.Lastname;
            email.Text = user.Email;
            username.Text = user.Username;
            var nameList = TestsController.GetServiceName();
            var listSize = nameList.Count;
            var newItem = new ListItem();
            foreach (var item in nameList)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    newItem = new ListItem();
                    newItem.Text = item;
                    newItem.Value = item;
                    servicenameList.Items.Add(newItem);
                }
            }





        }

        private void btnSubmitSoap_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtboxUrlSoap.Text))
            {
                var header = new Headers
                {
                    Name = headername1.ToString(),
                    Value = headervalue1.ToString()
                };
                var test = TestsController.GetSOAPResponse(txtboxUrlSoap.Text, txtboxSoapRequest.Text, User, header);
                txtboxSoapResponse.Text = test.Response;
                timeProcessing_Soap.Text = test.ProcessingTime.ToString();

                if (!string.IsNullOrWhiteSpace(key1soap.Text) && (!string.IsNullOrWhiteSpace(value1soap.Text)))
                {
                    var validare = TestsController.ValidateResponse(key1soap.Text, value1soap.Text, test.Response);
                    if (validare == 1)
                    {
                        assert1.Background = System.Windows.Media.Brushes.Green;
                    }
                    else if (validare == 0)
                    {
                        assert1.Background = System.Windows.Media.Brushes.Red;
                    }
                    else
                    {
                        assert1.Background = System.Windows.Media.Brushes.Yellow;
                    }
                };
                if (!string.IsNullOrWhiteSpace(key2soap.Text) && (!string.IsNullOrWhiteSpace(value2soap.Text)))
                {
                    var validare = TestsController.ValidateResponse(key2soap.Text, value2soap.Text, test.Response);
                    if (validare == 1)
                    {
                        assert2.Background = System.Windows.Media.Brushes.Green;
                    }
                    else if (validare == 0)
                    {
                        assert2.Background = System.Windows.Media.Brushes.Red;
                    }
                    else
                    {
                        assert2.Background = System.Windows.Media.Brushes.Yellow;
                    }
                }
            };
        }


        private void btnSubmitRest_Click(object sender, RoutedEventArgs e)
        {
            var request = new RESTRequest
            {
                EndPoint = txtboxUrlRest.Text + txtboxParams.Text,
                Method = dropdownMethod.Text,
                PostData = txtboxRestRequest.Text,
                ContentType = contentTypeList.Text,
            };

            var test = TestsController.GetRESTResponse(request, User);
            txtboxRestResponse.Text = test.Response;
            timeProcessing_Rest.Text = test.ProcessingTime.ToString();

            if (!string.IsNullOrWhiteSpace(key1rest.Text) && (!string.IsNullOrWhiteSpace(value1rest.Text)))
            {
                var validare = TestsController.ValidateResponseREST(key1rest.Text, value1rest.Text, test.Response);
                if (validare == 1)
                {
                    assert1rest.Background = System.Windows.Media.Brushes.Green;
                }
                else if (validare == 0)
                {
                    assert1rest.Background = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    assert1rest.Background = System.Windows.Media.Brushes.Yellow;
                }
            };
            if (!string.IsNullOrWhiteSpace(key2rest.Text) && (!string.IsNullOrWhiteSpace(value2rest.Text)))
            {
                var validare = TestsController.ValidateResponseREST(key2rest.Text, value2rest.Text, test.Response);
                if (validare == 1)
                {
                    assert2rest.Background = System.Windows.Media.Brushes.Green;
                }
                else if (validare == 0)
                {
                    assert2rest.Background = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    assert2rest.Background = System.Windows.Media.Brushes.Yellow;
                }
            }

        }

        private void saveDbSoap_Click(object sender, RoutedEventArgs e)
        {
            var testcase = new Test
            {
                Request=txtboxSoapRequest.Text,
                Response=txtboxSoapResponse.Text,
                ProcessingTime=TimeSpan.Parse(timeProcessing_Soap.Text),
                Uri=txtboxUrlSoap.Text,
                UserId=User.Id,
                ServiceName=User.ServiceName
            };
            

            if (TestsController.InsertInDB(testcase))
            {
                MessageBox.Show("TestCase saved.");
            }
            else
            {
                MessageBox.Show("Error.");
            }

        }

        private void saveDbRest_Click(object sender, RoutedEventArgs e)
        {
            var testcase = new Test
            {
                Request = txtboxRestRequest.Text,
                Response = txtboxRestResponse.Text,
                ProcessingTime = TimeSpan.Parse(timeProcessing_Rest.Text),
                Uri = txtboxUrlRest.Text,
                UserId = User.Id,
                ServiceName = User.ServiceName,
                Method=dropdownMethod.Text,
                Params=txtboxParams.Text,
                ContentType=contentTypeList.Text
                
            };
            if (TestsController.InsertInDB(testcase))
            {
                MessageBox.Show("TestCase saved.");
            }
            else
            {
                MessageBox.Show("Error.");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Username=username.Text,
                Firstname=firstname.Text,
                Lastname=lastname.Text,
                Email=email.Text,
                Id=User.Id
            };
            if (!string.IsNullOrEmpty(passwordBox.Password))

            {
                byte[] data = Encoding.ASCII.GetBytes(passwordBox.Password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                string hashedPassword = Encoding.ASCII.GetString(data);
                user.Password = passwordBox.Password;
            }
            else
            {
                user.Password = User.Password;
            }
                
            if (!string.IsNullOrEmpty(username.Text))
            {
                if (!UserController.CheckUser(user))
                {
                    if (UserController.UpdateUser(user))
                    {
                        MessageBox.Show("Update succesfully.");
                        User = user;
                    }
                    else
                    {
                        MessageBox.Show("Error while updateing user.");
                    }
                }
                else
                {
                    MessageBox.Show("Username already exists.");
                }
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            User = null;
            
            this.Hide();
            LoginWindow lg = new LoginWindow();
            lg.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var passed = 0;
            var failed = 0;
            var executed = 0;
            var testsList = TestsController.GetTests(servicenameList.SelectedValue.ToString());
            foreach (var item in testsList)
            {
                var testExecuted = TestsController.GetSOAPResponse(item.Uri, item.Request, User, null);
                executed = executed + 1;
                if (testExecuted.Response == item.Response)
                {
                    passed = passed + 1;
                }
                else
                {
                    failed = failed + 1;
                }
                
            }
            testeExecutate.Content = executed;
            testeFailed.Content = failed;
            testePassed.Content = passed;

           
        }

        private void servicenameList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void servicenameList_ContextMenuOpening(object sender, System.Windows.Controls.ContextMenuEventArgs e)
        {

        }
    }
}
