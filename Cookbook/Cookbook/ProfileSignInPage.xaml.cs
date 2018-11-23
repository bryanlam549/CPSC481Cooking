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
    /// Interaction logic for ProfileSignInPage.xaml
    /// </summary>
    public partial class ProfileSignInPage : Page
    {
        //private ProfileMainPage profileMainPage = new ProfileMainPage("", "", "");
        private List<string> accountList = new List<string>();

        public ProfileSignInPage()
        {
            InitializeComponent();

            accountList.Add("foodluver123");
            accountList.Add("ilovefood456@food.com");
            accountList.Add("123456789123456789123456789");

            accountList.Add("foodisLIFE");
            accountList.Add("burgers@food.com");
            accountList.Add("123456789");
        }


        private void SignIn_Click(object sender, RoutedEventArgs e)
        {


            if (accountList.Contains(UserInput.Text) && accountList.Contains(PasswordInput.Password))
            {

                ProfileMainPage profileMainPage = new ProfileMainPage(UserInput.Text, accountList[(accountList.IndexOf(UserInput.Text)) + 1], PasswordInput.Password);
                signInMain.Content = profileMainPage;
            }
            else
            {
                invalidInput.Text = "Invalid username or password";
               
            }
            
        }
    }
}
