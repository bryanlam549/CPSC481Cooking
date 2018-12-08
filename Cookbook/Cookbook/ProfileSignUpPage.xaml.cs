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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for ProfileSignUpPage.xaml
    /// </summary>
    public partial class ProfileSignUpPage : Page
    {

        public ProfileSignUpPage()
        {
            InitializeComponent();
            _back.transitionPageButton.Click += Back_Click;

            _back.initAppearance(TransitionPageButton.Orientation.BACK, "BACK");
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (nameInput.Text == "" || emailInput.Text == "" || passwordInput.Password.Length == 0)
            {
                if (nameInput.Text == "")
                {
                    nameText.Foreground = Brushes.Red;
                }
                if (emailInput.Text == "")
                {
                    emailText.Foreground = Brushes.Red;
                }
                if (passwordInput.Password.Length == 0)
                {
                    passText.Foreground = Brushes.Red;
                }
                
                invalidInput.Text = "Highlighted field(s) are required.";
            }
            else if (nameInput.Text.Length < 4)
            {
                invalidInput.Text = "Username needs to be at least 4 characters.";
                nameText.Foreground = Brushes.Red;

            }
            else if (passwordInput.Password.Length < 8)
            {
                invalidInput.Text = "Password needs to be at least 8 characters.";
                passText.Foreground = Brushes.Red;

            }
            else if (!(passwordInput.Password.Contains("1") || passwordInput.Password.Contains("2") || passwordInput.Password.Contains("3") || passwordInput.Password.Contains("4") || passwordInput.Password.Contains("5") || passwordInput.Password.Contains("6") || passwordInput.Password.Contains("7") || passwordInput.Password.Contains("8") || passwordInput.Password.Contains("9") || passwordInput.Password.Contains("0")))
            {
                invalidInput.Text = "Password needs to contain at least 1 digit.";
                passText.Foreground = Brushes.Red;
            }
            else
            {
                ProfileMainPage profileMainPage = new ProfileMainPage(nameInput.Text, emailInput.Text, passwordInput.Password);
                GlobalData.Instance.signedIn = true;
                GlobalData.Instance.accountList.Add(nameInput.Text);
                GlobalData.Instance.accountList.Add(emailInput.Text);
                GlobalData.Instance.accountList.Add(passwordInput.Password);
                GlobalData.Instance.accountList.Add("");
                GlobalData.Instance.accountList.Add("");
                signUpMain.Content = profileMainPage;
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage1 profilepage1 = new ProfilePage1();
            this.NavigationService.Navigate(profilepage1);

        }

        private void UserInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            invalidInput.Text = "";
            nameText.Foreground = Brushes.Black;
            emailText.Foreground = Brushes.Black;
            passText.Foreground = Brushes.Black;
        }

        private void EmailInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            invalidInput.Text = "";
            nameText.Foreground = Brushes.Black;
            emailText.Foreground = Brushes.Black;
            passText.Foreground = Brushes.Black;
        }

        private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            invalidInput.Text = "";
            nameText.Foreground = Brushes.Black;
            emailText.Foreground = Brushes.Black;
            passText.Foreground = Brushes.Black;
        }
    }
}
