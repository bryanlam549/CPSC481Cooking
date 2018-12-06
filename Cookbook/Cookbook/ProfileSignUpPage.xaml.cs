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
            ProfileMainPage profileMainPage = new ProfileMainPage(nameInput.Text, emailInput.Text, passwordInput.Password);
            GlobalData.Instance.signedIn = true;
            signUpMain.Content = profileMainPage;

            //removing later
            //RecipeCompletionPage rcpage = new RecipeCompletionPage();
            //signUpMain.Content = rcpage;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage1 profilepage1 = new ProfilePage1();
            this.NavigationService.Navigate(profilepage1);

        }
    }
}
