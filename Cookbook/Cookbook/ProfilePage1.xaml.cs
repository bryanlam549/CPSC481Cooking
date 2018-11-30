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
    /// Interaction logic for ProfilePage1.xaml
    /// </summary>
    public partial class ProfilePage1 : Page
    {
        private ProfileSignUpPage profilesignUpPage = new ProfileSignUpPage();
        private ProfileSignInPage profilesignInPage = new ProfileSignInPage();

        public ProfilePage1()
        {
            InitializeComponent();

        }

        private void ProfileSignUp_Click(object sender, RoutedEventArgs e)
        {
            profileMain.Content = profilesignUpPage;
        }

        private void ProfileSignIn_Click(object sender, RoutedEventArgs e)
        {
            profileMain.Content = profilesignInPage;
        }
    }
}
