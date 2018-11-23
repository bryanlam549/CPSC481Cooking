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
    /// Interaction logic for HeartButton.xaml
    /// </summary>
    public partial class HeartButton : UserControl
    {

        // cache global resources...
        private BitmapImage unfillHeartImage = (BitmapImage)Application.Current.Resources["unfillHeartIcon"];
        private BitmapImage heartImage = (BitmapImage)Application.Current.Resources["heartIcon"];

        public Recipe _recipe;


        // ~~~~~~~LATER ON: have a Recipe (instance of Recipe class) field here (set by the page) so this button can be applied to a specific recipe

        private bool _isFilled = false; // unfilled heart or filled heart?


        public HeartButton()
        {
            InitializeComponent();

        }



        private void HeartButton_Click(object sender, RoutedEventArgs e)
        {
            _isFilled = !_isFilled; // toggle flag

            if (_isFilled)
            {
                heartButtonImageBrush.ImageSource = heartImage; // change icon
                // ~~~~~~~LATER ON: set the recipe to favorited
            }
            else
            {
                heartButtonImageBrush.ImageSource = unfillHeartImage; // change icon
                // ~~~~~~~LATER ON: set the recipe to unfavorited
            }
            
        }

    }
}
