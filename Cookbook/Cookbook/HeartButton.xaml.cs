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
using System.Diagnostics;

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

        public Recipe _recipe; // ~~~~~~~~~~~~~~gets set by page


        // ~~~~~~~LATER ON: have a Recipe (instance of Recipe class) field here (set by the page) so this button can be applied to a specific recipe

        //Changed this to public: BRYAN
        public bool _isFilled; // unfilled heart or filled heart?


        public HeartButton()
        {
            InitializeComponent();

        }

        //Heart icon image, either filled or unfilled when page is open: made by BRYAN
        private ImageSource hearticonimage;
        public ImageSource HeartIconImage
        {
            get { return hearticonimage; }
            set
            {
                hearticonimage = value;
                this.heartButtonImageBrush.ImageSource = this.heartImage;
            }
        }
        

        //Button
        private void HeartButton_Click(object sender, RoutedEventArgs e)
        {
            _isFilled = !_isFilled; // toggle flag

            if (_isFilled)
            {
                heartButtonImageBrush.ImageSource = heartImage; // change icon
                // set the recipe to favorited
                if (_recipe != null)
                {
                    _recipe._isFavourite = true;
                }
                else
                {
                    Debug.WriteLine("ERROR: HeartButton.xaml.cs | NULL RECIPE");
                }
            }
            else
            {
                heartButtonImageBrush.ImageSource = unfillHeartImage; // change icon
                // set the recipe to unfavorited
                if (_recipe != null)
                {
                    _recipe._isFavourite = false;
                }
                else
                {
                    Debug.WriteLine("ERROR: HeartButton.xaml.cs | NULL RECIPE");
                }
            }
            
        }

    }
}
