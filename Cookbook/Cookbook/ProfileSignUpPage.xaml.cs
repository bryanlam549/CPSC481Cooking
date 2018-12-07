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
        //private ProfileMainPage profileMainPage = new ProfileMainPage("");

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
            else if (passwordInput.Password.Length < 8)
            {
                invalidInput.Text = "Password needs to be at least 8 characters.";
                
            }
            else if (!(passwordInput.Password.Contains("1") || passwordInput.Password.Contains("2") || passwordInput.Password.Contains("3") || passwordInput.Password.Contains("4") || passwordInput.Password.Contains("5") || passwordInput.Password.Contains("6") || passwordInput.Password.Contains("7") || passwordInput.Password.Contains("8") || passwordInput.Password.Contains("9") || passwordInput.Password.Contains("0")))
            {
                invalidInput.Text = "Password needs to contain at least 1 digit.";
            }
            else
            {
                ProfileMainPage profileMainPage = new ProfileMainPage(nameInput.Text, emailInput.Text, passwordInput.Password, "", "");
                GlobalData.Instance.signedIn = true;
                signUpMain.Content = profileMainPage;
            }

            
            //RecipeCompletionPage rcpage = new RecipeCompletionPage();
            //signUpMain.Content = rcpage;
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
        }

        private void EmailInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            invalidInput.Text = "";
            emailText.Foreground = Brushes.Black;
        }

        private void PasswordInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            invalidInput.Text = "";
            passText.Foreground = Brushes.Black;
        }
    }
}
