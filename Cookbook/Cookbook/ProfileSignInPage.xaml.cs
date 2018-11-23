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

        public ProfileSignInPage()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            ProfileMainPage profileMainPage = new ProfileMainPage(UserInput.Text, "", PasswordInput.Password);
            signInMain.Content = profileMainPage;
        }
    }
}
