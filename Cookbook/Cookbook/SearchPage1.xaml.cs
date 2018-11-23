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
    /// Interaction logic for SearchPage1.xaml
    /// </summary>
    public partial class SearchPage1 : Page
    {
        //public BitmapImage fillHeart = new BitmapImage(new Uri("pack://application:,,,/Images/heart.png"));
        //public BitmapImage unfillHeart = new BitmapImage(new Uri("pack://application:,,,/Images/unfillHeart.png"));
        public SearchPage1()
        {
            InitializeComponent();

            HeartButton hb = new HeartButton();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*if (this.fav.Source == fillHeart)
            {
                this.fav.Source = unfillHeart;
                MainWindow.burgerFave = false;
            }
            else
            {
                this.fav.Source = fillHeart;
                MainWindow.burgerFave = true;
            }*/
        }
    }
}
