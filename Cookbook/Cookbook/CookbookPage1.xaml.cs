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
    /// Interaction logic for CookbookPage1.xaml
    /// </summary>
    public partial class CookbookPage1 : Page
    {
        /*
        public BitmapImage favouriteButtonImage = new BitmapImage(new Uri("pack://application:,,,/Images/favouriteButton.png")); // only need to load the images once
        public BitmapImage favouriteButtonDarkImage = new BitmapImage(new Uri("pack://application:,,,/Images/favouriteButtonDark.png"));

        public BitmapImage personalButtonImage = new BitmapImage(new Uri("pack://application:,,,/Images/personalButton.png"));
        public BitmapImage personalButtonDarkImage = new BitmapImage(new Uri("pack://application:,,,/Images/personalButtonDark.png"));

        public BitmapImage recentRecipeButtonImage = new BitmapImage(new Uri("pack://application:,,,/Images/recentButton.png"));
        public BitmapImage recentRecipeButtonDarkImage = new BitmapImage(new Uri("pack://application:,,,/Images/recentButtonDark.png"));
        */

        private CookbookFavouritePage cookbookfavouritePage = new CookbookFavouritePage();
        private CookbookRecentPage cookbookRecentPage = new CookbookRecentPage();
        private CookbookPersonalPage cookbookPersonalPage = new CookbookPersonalPage();

        
        public CookbookPage1()
        {
            InitializeComponent();
            cookMain.Content = cookbookfavouritePage; // start cookbook at favourite page all the time
            
        }
        //heartButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["unfillHeartIcon"];
        private void FavouriteButton_Click(object sender, RoutedEventArgs e)
        {
            //Selected
            FavouriteButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["favouriteButtonDarkIcon"];
            //Unselected
            personaleButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["personalButtonIcon"];
            recentButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["recentButtonIcon"];
            //Switch content
            cookMain.Content = cookbookfavouritePage;
        }

        private void PersonalButton_Click(object sender, RoutedEventArgs e)
        {
            //Selected
            personaleButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["personalButtonDarkIcon"];
            //Unselected
            FavouriteButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["favouriteButtonIcon"];
            recentButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["recentButtonIcon"];
            //Switch content
            cookMain.Content = cookbookPersonalPage;
        }

        private void recentButton_Click(object sender, RoutedEventArgs e)
        {
            //Selected
            recentButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["recentButtonDarkIcon"];
            //Unselected
            FavouriteButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["favouriteButtonIcon"];
            personaleButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["personalButtonIcon"];
            //Switch Content
            cookMain.Content = cookbookRecentPage;
        }
    }
}
