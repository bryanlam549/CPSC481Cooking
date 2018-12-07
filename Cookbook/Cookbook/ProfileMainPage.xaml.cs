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
    /// Interaction logic for ProfileInfoPage.xaml
    /// </summary>
    /// 
    public partial class ProfileMainPage : Page
    {

        public BitmapImage infoButtonImage = new BitmapImage(new Uri("pack://application:,,,/Images/InfoButton.png"));
        public BitmapImage infoButtonDarkImage = new BitmapImage(new Uri("pack://application:,,,/Images/InfoButtonDark.png"));

        public BitmapImage preferencesButtonImage = new BitmapImage(new Uri("pack://application:,,,/Images/PreferencesButton.png"));
        public BitmapImage preferencesButtonDarkImage = new BitmapImage(new Uri("pack://application:,,,/Images/PreferencesButtonDark.png"));

        //private ProfileInfoPage profileInfoPage = new ProfileInfoPage(UserNameInput.Text); 

        public ProfileMainPage(string username, string email, string password, string pref1, string pref2)
        {
            InitializeComponent();
            UserNameInput.Text = username;
            EmailInput.Text = email;
            //PasswordInput.Text = password;
            string x = "";
            int i;
            for (i = 0;  i < password.Length; i++)  {
                x = x + "*";

            }
            PasswordInput.Text = x;

            _tempPref.Text = pref1;
            _weightPref.Text = pref2;
        }

        private void ProfileInfoButton_Click(object sender, RoutedEventArgs e)
        {
            //Selected
            InfoButtonImageBrush.ImageSource = infoButtonDarkImage;
            //Unselected
            PreferencesButtonImageBrush.ImageSource = preferencesButtonImage;

            //Switch content
            ProfileInfoPage profileInfoPage = new ProfileInfoPage(UserNameInput.Text, EmailInput.Text, PasswordInput.Text);
            profileMain.Content = profileInfoPage;
        }

        private void ProfilePreferencesButton_Click(object sender, RoutedEventArgs e)
        {
            //Selected
            PreferencesButtonImageBrush.ImageSource = preferencesButtonDarkImage;
            //Unselected
            InfoButtonImageBrush.ImageSource = infoButtonImage;

            //Switch content
            ProfilePreferencesPage profilePreferencesPage = new ProfilePreferencesPage(_tempPref.Text, _weightPref.Text);
            profileMain.Content = profilePreferencesPage;
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage1 profilepage1 = new ProfilePage1();
            GlobalData.Instance.signedIn = false;
            GlobalData.Instance.newAcc = false;
            this.NavigationService.Navigate(profilepage1);
        }
    }
}
