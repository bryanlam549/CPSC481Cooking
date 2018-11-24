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
            /*for(int i = 0; i < 10; i++)
            {

                CookbookRecipes recipe = new CookbookRecipes();
                
                recipe.editButton.Click += editButton_Click;
                recipe.foodProfileButton.Click += foodProfileButton_Click;
                Recipes.Children.Add(recipe);
            }*/
         
            //If buger is favourited, then display it.
            if (MainWindow.burgerFave == true)
            {
                //IF burger is favourited
                CookbookRecipes burger = new CookbookRecipes();
                burger.Number = 1.ToString() + "."; 
                burger.Title = "Burgers";
                burger.Description = "This is the food description";
                burger.Dur = "30 min";

                /*
                BitmapImage food = new BitmapImage();
                food.BeginInit();
                food.UriSource = new Uri("Images/burger.jpg", UriKind.Relative);
                food.EndInit();*/

                burger.FoodImage = (BitmapImage)Application.Current.Resources["burgerIcon"];

                //IF recipe difficulty = medium
                burger.DiffImage = (BitmapImage)Application.Current.Resources["easyIconIcon"];

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
            //((MainWindow)App.Current.MainWindow).Main.Content = ((MainWindow)App.Current.MainWindow).searchPage1;
            //((MainWindow)App.Current.MainWindow).Main.Content = GlobalData.Instance.search;
            ((MainWindow)App.Current.MainWindow).Main.Content = profile;
        }
    }
}
