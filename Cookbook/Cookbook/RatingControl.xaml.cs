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
    public partial class RatingControl : UserControl
    {

        // cache global resources...
        private BitmapImage unfillStarImage = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
        private BitmapImage fillStarImage = (BitmapImage)Application.Current.Resources["fillStarIcon"];
        private int _currentRating = 0; // 0 = not-rated

        public RecipeProfilePage _recipeProfilePage;

        public RatingControl()
        {
            InitializeComponent();

        }


        // init the stars based on recipe data
        public void initStartingRating(int rating)
        {
            if (rating == 0)
            {
                Disable();
            }
            else
            {
                Enable(rating);
            }
        }




        private void StarButton1_Click(object sender, RoutedEventArgs e)
        {
            if (!GlobalData.Instance.signedIn)
            {
                _recipeProfilePage.signInBox.Visibility = Visibility.Visible;
            }
            else
            {
                if (_currentRating != 1) // update to 1 star
                {
                    Enable(1);
                }
                else // disable
                {
                    Disable();
                }
            }

        }

        private void StarButton2_Click(object sender, RoutedEventArgs e)
        {
            if (!GlobalData.Instance.signedIn)
            {
                _recipeProfilePage.signInBox.Visibility = Visibility.Visible;
            }
            else
            {
                if (_currentRating != 2) // update to 2 star
                {
                    Enable(2);
                }
                else // disable
                {
                    Disable();
                }
            }

        }

        private void StarButton3_Click(object sender, RoutedEventArgs e)
        {
            if (!GlobalData.Instance.signedIn)
            {
                _recipeProfilePage.signInBox.Visibility = Visibility.Visible;
            }
            else
            {
                if (_currentRating != 3) // update to 3 star
                {
                    Enable(3);
                }
                else // disable
                {
                    Disable();
                }
            }

        }

        private void StarButton4_Click(object sender, RoutedEventArgs e)
        {
            if (!GlobalData.Instance.signedIn)
            {
                _recipeProfilePage.signInBox.Visibility = Visibility.Visible;
            }
            else
            {
                if (_currentRating != 4) // update to 4 star
                {
                    Enable(4);
                }
                else // disable
                {
                    Disable();
                }
            }

            
        }

        private void StarButton5_Click(object sender, RoutedEventArgs e)
        {
            if (!GlobalData.Instance.signedIn)
            {
                _recipeProfilePage.signInBox.Visibility = Visibility.Visible;
            }
            else
            {
                if (_currentRating != 5) // update to 5 star
                {
                    Enable(5);
                }
                else // disable
                {
                    Disable();
                }
            }

        }



        private void Enable(int numOfStars)
        {

            if (numOfStars < 1 || numOfStars > 5)
            {
                return;
            }

            starButton1ImageBrush.ImageSource = fillStarImage;
            starButton2ImageBrush.ImageSource = numOfStars >= 2 ? fillStarImage : unfillStarImage;
            starButton3ImageBrush.ImageSource = numOfStars >= 3 ? fillStarImage : unfillStarImage;
            starButton4ImageBrush.ImageSource = numOfStars >= 4 ? fillStarImage : unfillStarImage;
            starButton5ImageBrush.ImageSource = numOfStars >= 5 ? fillStarImage : unfillStarImage;

            _currentRating = numOfStars;

            _recipeProfilePage._recipe._rating = _currentRating;

        }



        private void Disable()
        {
            starButton1ImageBrush.ImageSource = unfillStarImage;
            starButton2ImageBrush.ImageSource = unfillStarImage;
            starButton3ImageBrush.ImageSource = unfillStarImage;
            starButton4ImageBrush.ImageSource = unfillStarImage;
            starButton5ImageBrush.ImageSource = unfillStarImage;

            _currentRating = 0;

            _recipeProfilePage._recipe._rating = _currentRating;

        }



    }
}
