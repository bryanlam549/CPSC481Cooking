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
    /// Interaction logic for CookbookFavouritePage.xaml
    /// </summary>
    public partial class CookbookFavouritePage : Page
    {
        public CookbookFavouritePage()
        {
            InitializeComponent();

            //We can have 5 recipes, meanining 5 of these.

            if (MainWindow.burgerFave == true)
            {
                //IF burger is favourited
                CookbookRecipes burger = new CookbookRecipes();
                burger.Number = 1.ToString() + ".";
                burger.Title = "Burgers";
                burger.Description = "This is the food description";
                burger.Dur = "30 min";

                BitmapImage food = new BitmapImage();
                food.BeginInit();
                food.UriSource = new Uri("Images/burger.jpg", UriKind.Relative);
                food.EndInit();
                burger.FoodImage = food;

                BitmapImage diff = new BitmapImage();
                diff.BeginInit();
                diff.UriSource = new Uri("Images/medIcon.png", UriKind.Relative);
                diff.EndInit();
                burger.DiffImage = diff;

                //burger.Click += editButton_Click;
                burger.editButton.Click += editButton_Click;
                burger.foodProfileButton.Click += foodProfileButton_Click;

                Recipes.Children.Add(burger);
            }
        }
        //public event RoutedEventHandler Click;
        public void editButton_Click(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/questions/41333040/wpf-best-practice-to-get-current-mainwindow-instance
            //burger.Title = "HOW DARE YOU!!!";
            //blah.Content = "HOW DARE YOU!!!!";
            //((MainWindow)App.Current.MainWindow).Test.Text = "This is simply a test";
            Mod mod = new Mod();
            ((MainWindow)App.Current.MainWindow).Main.Content = mod;


        }
        public void foodProfileButton_Click(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/questions/41333040/wpf-best-practice-to-get-current-mainwindow-instance
            //burger.Title = "HOW DARE YOU!!!";
            //blah.Content = "HOW DARE YOU!!!!";
            //((MainWindow)App.Current.MainWindow).Test.Text = "This is simply a test";
            RecipeProfilePage profile = new RecipeProfilePage();
            ((MainWindow)App.Current.MainWindow).Main.Content = profile;


        }
    }
}
