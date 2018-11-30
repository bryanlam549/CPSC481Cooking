﻿ using System;
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

        private BitmapImage favouriteButtonImage = (BitmapImage)Application.Current.Resources["favouriteButtonIcon"]; // only need to load the images once
        private BitmapImage favouriteButtonDarkImage = (BitmapImage)Application.Current.Resources["favouriteButtonDarkIcon"];

        private BitmapImage personalButtonImage = (BitmapImage)Application.Current.Resources["personalButtonIcon"];
        private BitmapImage personalButtonDarkImage = (BitmapImage)Application.Current.Resources["personalButtonDarkIcon"];

        private BitmapImage recentRecipeButtonImage = (BitmapImage)Application.Current.Resources["recentButtonIcon"];
        private BitmapImage recentRecipeButtonDarkImage = (BitmapImage)Application.Current.Resources["recentButtonDarkIcon"];

        //private CookbookFavouritePage cookbookfavouritePage = new CookbookFavouritePage();
        //private CookbookRecentPage cookbookRecentPage = new CookbookRecentPage();
        //private CookbookPersonalPage cookbookPersonalPage = new CookbookPersonalPage();
        private CookbookFavouritePage cookbookfavouritePage = new CookbookFavouritePage(GlobalData.Instance.favouriteList);
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
            FavouriteButtonImageBrush.ImageSource = favouriteButtonDarkImage;
            //Unselected
            personaleButtonImageBrush.ImageSource = personalButtonImage;
            recentButtonImageBrush.ImageSource = recentRecipeButtonImage;
            //Switch content
            cookMain.Content = cookbookfavouritePage;
        }

        private void PersonalButton_Click(object sender, RoutedEventArgs e)
        {
            //Selected
            personaleButtonImageBrush.ImageSource = personalButtonDarkImage;
            //Unselected
            FavouriteButtonImageBrush.ImageSource = favouriteButtonImage;
            recentButtonImageBrush.ImageSource = recentRecipeButtonImage;
            //Switch content
            cookMain.Content = cookbookPersonalPage;
        }

        private void recentButton_Click(object sender, RoutedEventArgs e)
        {
            //Selected
            recentButtonImageBrush.ImageSource = recentRecipeButtonDarkImage;
            //Unselected
            FavouriteButtonImageBrush.ImageSource = favouriteButtonImage;
            personaleButtonImageBrush.ImageSource = personalButtonImage;
            //Switch Content
            cookMain.Content = cookbookRecentPage;
        }
    }
}
