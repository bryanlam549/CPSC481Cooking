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
    /// Interaction logic for RatingControl.xaml
    /// </summary>
    /// 
    public partial class CompletionPageRatingControl : UserControl
    {

        // cache global resources...
        private BitmapImage unfillStarImage = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
        private BitmapImage fillStarImage = (BitmapImage)Application.Current.Resources["fillStarIcon"];
        private int _currentRating = 0; // 0 = not-rated

        public CompletionPageRatingControl()
        {
            InitializeComponent();

            // init the stars based on recipe data
        }

        private void StarButton1_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalData.Instance.signedIn == false)
            {
                // cannot rate
                GlobalData.Instance.completionPage.favHeart.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.rating.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.signInBox.IsEnabled = true;
                GlobalData.Instance.completionPage.signInBox.Visibility = System.Windows.Visibility.Visible;
                GlobalData.Instance.completionPage.completionMain.IsEnabled = false;
                
            }
            else if (_currentRating != 1) // update to 1 star
            {
                starButton1ImageBrush.ImageSource = fillStarImage;
                starButton2ImageBrush.ImageSource = unfillStarImage;
                starButton3ImageBrush.ImageSource = unfillStarImage;
                starButton4ImageBrush.ImageSource = unfillStarImage;
                starButton5ImageBrush.ImageSource = unfillStarImage;

                _currentRating = 1;
            }
            else // disable
            {
                starButton1ImageBrush.ImageSource = unfillStarImage;
                starButton2ImageBrush.ImageSource = unfillStarImage;
                starButton3ImageBrush.ImageSource = unfillStarImage;
                starButton4ImageBrush.ImageSource = unfillStarImage;
                starButton5ImageBrush.ImageSource = unfillStarImage;

                _currentRating = 0;
            }
        }

        private void StarButton2_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalData.Instance.signedIn == false)
            {
                // cannot rate
                GlobalData.Instance.completionPage.favHeart.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.rating.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.signInBox.IsEnabled = true;
                GlobalData.Instance.completionPage.signInBox.Visibility = System.Windows.Visibility.Visible;
                GlobalData.Instance.completionPage.completionMain.IsEnabled = false;

            }
            else if (_currentRating != 2) // update to 2 star
            {
                starButton1ImageBrush.ImageSource = fillStarImage;
                starButton2ImageBrush.ImageSource = fillStarImage;
                starButton3ImageBrush.ImageSource = unfillStarImage;
                starButton4ImageBrush.ImageSource = unfillStarImage;
                starButton5ImageBrush.ImageSource = unfillStarImage;

                _currentRating = 2;
            }
            else // disable
            {
                starButton1ImageBrush.ImageSource = unfillStarImage;
                starButton2ImageBrush.ImageSource = unfillStarImage;
                starButton3ImageBrush.ImageSource = unfillStarImage;
                starButton4ImageBrush.ImageSource = unfillStarImage;
                starButton5ImageBrush.ImageSource = unfillStarImage;

                _currentRating = 0;
            }
        }

        private void StarButton3_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalData.Instance.signedIn == false)
            {
                // cannot rate
                GlobalData.Instance.completionPage.favHeart.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.rating.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.signInBox.IsEnabled = true;
                GlobalData.Instance.completionPage.signInBox.Visibility = System.Windows.Visibility.Visible;
                GlobalData.Instance.completionPage.completionMain.IsEnabled = false;
            }
            else if (_currentRating != 3) // update to 3 star
            {
                starButton1ImageBrush.ImageSource = fillStarImage;
                starButton2ImageBrush.ImageSource = fillStarImage;
                starButton3ImageBrush.ImageSource = fillStarImage;
                starButton4ImageBrush.ImageSource = unfillStarImage;
                starButton5ImageBrush.ImageSource = unfillStarImage;

                _currentRating = 3;
            }
            else // disable
            {
                starButton1ImageBrush.ImageSource = unfillStarImage;
                starButton2ImageBrush.ImageSource = unfillStarImage;
                starButton3ImageBrush.ImageSource = unfillStarImage;
                starButton4ImageBrush.ImageSource = unfillStarImage;
                starButton5ImageBrush.ImageSource = unfillStarImage;

                _currentRating = 0;
            }
        }

        private void StarButton4_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalData.Instance.signedIn == false)
            {
                // cannot rate
                GlobalData.Instance.completionPage.favHeart.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.rating.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.signInBox.IsEnabled = true;
                GlobalData.Instance.completionPage.signInBox.Visibility = System.Windows.Visibility.Visible;
                GlobalData.Instance.completionPage.completionMain.IsEnabled = false;
            }
            else  if (_currentRating != 4) // update to 4 star
            {
                starButton1ImageBrush.ImageSource = fillStarImage;
                starButton2ImageBrush.ImageSource = fillStarImage;
                starButton3ImageBrush.ImageSource = fillStarImage;
                starButton4ImageBrush.ImageSource = fillStarImage;
                starButton5ImageBrush.ImageSource = unfillStarImage;

                _currentRating = 4;
            }
            else // disable
            {
                starButton1ImageBrush.ImageSource = unfillStarImage;
                starButton2ImageBrush.ImageSource = unfillStarImage;
                starButton3ImageBrush.ImageSource = unfillStarImage;
                starButton4ImageBrush.ImageSource = unfillStarImage;
                starButton5ImageBrush.ImageSource = unfillStarImage;

                _currentRating = 0;
            }
        }

        private void StarButton5_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalData.Instance.signedIn == false)
            {
                // cannot rate
                GlobalData.Instance.completionPage.favHeart.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.rating.Visibility = System.Windows.Visibility.Hidden;
                GlobalData.Instance.completionPage.signInBox.IsEnabled = true;
                GlobalData.Instance.completionPage.signInBox.Visibility = System.Windows.Visibility.Visible;
                GlobalData.Instance.completionPage.completionMain.IsEnabled = false;
            }
            else if (_currentRating != 5) // update to 5 star
            {
                starButton1ImageBrush.ImageSource = fillStarImage;
                starButton2ImageBrush.ImageSource = fillStarImage;
                starButton3ImageBrush.ImageSource = fillStarImage;
                starButton4ImageBrush.ImageSource = fillStarImage;
                starButton5ImageBrush.ImageSource = fillStarImage;

                _currentRating = 5;
            }
            else // disable
            {
                starButton1ImageBrush.ImageSource = unfillStarImage;
                starButton2ImageBrush.ImageSource = unfillStarImage;
                starButton3ImageBrush.ImageSource = unfillStarImage;
                starButton4ImageBrush.ImageSource = unfillStarImage;
                starButton5ImageBrush.ImageSource = unfillStarImage;

                _currentRating = 0;
            }
        }
    }
}

