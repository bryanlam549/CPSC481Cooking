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
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            ProfileMainPage profileMainPage = new ProfileMainPage(nameInput.Text, emailInput.Text, passwordInput.Password);
            signUpMain.Content = profileMainPage;
        }
    }
}
