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
    /// Interaction logic for TransitionPageButton.xaml
    /// </summary>
    public partial class TransitionPageButton : UserControl
    {

        public enum Orientation { BACK, FORWARD };


        // cache global resources...
        private BitmapImage backImage = (BitmapImage)Application.Current.Resources["backIcon"];
        private BitmapImage forwardImage = (BitmapImage)Application.Current.Resources["forwardIcon"];


        public Page _page; // page to transition to...

        public static readonly DependencyProperty ImageSrc = DependencyProperty.Register("ImageSource", typeof(BitmapImage), typeof(TransitionPageButton));
        public static readonly DependencyProperty buttonLabel = DependencyProperty.Register("ButtonLabel", typeof(string), typeof(TransitionPageButton));

        public BitmapImage ImageSource
        {
            get { return (BitmapImage)GetValue(ImageSrc); }
            set { SetValue(ImageSrc, value); }
        }

        public string ButtonLabel
        {
            get { return (string)GetValue(buttonLabel); }
            set { SetValue(buttonLabel, value); }
        }

        public TransitionPageButton()
        {
            InitializeComponent();
            this.DataContext = this;
            // init the proper icon here...
        }

        public void initAppearance(Orientation orientation, String text)
        {
            if (orientation == Orientation.BACK)
            {
                transitionPageButtonImageBrush.ImageSource = backImage;
            }
            else
            {
                transitionPageButtonImageBrush.ImageSource = forwardImage;
            }

            buttonTextControl.Content = text;

        }




        private void TransitionPageButton_Click(object sender, RoutedEventArgs e)
        {
            // change main window page to the page field of this class (_page)

        }

    }
}
