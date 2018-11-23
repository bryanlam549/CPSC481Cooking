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

        // cache global resources...
        private BitmapImage backImage = (BitmapImage)Application.Current.Resources["backIcon"];
        private BitmapImage forwardImage = (BitmapImage)Application.Current.Resources["forwardIcon"];


        public Page _page; // page to transition to...

        public TransitionPageButton()
        {
            InitializeComponent();

            // init the proper icon here...
        }


        private void TransitionPageButton_Click(object sender, RoutedEventArgs e)
        {
            // change main window page to the page field of this class (_page)

        }

    }
}
