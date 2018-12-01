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
        public List<Recipe> _faveList;
        //Pass in a LIST of recipes. 
        public CookbookFavouritePage(List<Recipe> faveList)
        {
            InitializeComponent();
            _faveList = faveList;
            for(int i = 0; i < _faveList.Count; i++)
            {
                CookbookRecipes recipe = new CookbookRecipes();
                int num = i + 1;
                recipe.Number = num.ToString() + ".";
                recipe.Title = _faveList[i]._name;
                recipe.Dur = _faveList[i]._duration.ToString() + " min";

                recipe.FoodImage = _faveList[i]._image;

               

                if (_faveList[i]._difficulty == Recipe.Difficulties.EASY)
                    recipe.DiffImage = (BitmapImage)Application.Current.Resources["easyIconIcon"];
                else if (_faveList[i]._difficulty == Recipe.Difficulties.MEDIUM)
                    recipe.DiffImage = (BitmapImage)Application.Current.Resources["medIconIcon"];
                else if (_faveList[i]._difficulty == Recipe.Difficulties.HARD)
                    recipe.DiffImage = (BitmapImage)Application.Current.Resources["hardIconIcon"];

                //recipe.editButton.Click += editButton_Click;
                //recipe.foodProfileButton.Click += foodProfileButton_Click;

                //Still need to add ratings

                Recipes.Children.Add(recipe);
            }


            /*for(int i = 0; i < 10; i++)
            {

                CookbookRecipes recipe = new CookbookRecipes();
                
                recipe.editButton.Click += editButton_Click;
                recipe.foodProfileButton.Click += foodProfileButton_Click;
                Recipes.Children.Add(recipe);
            }*/

            /*
            //If buger is favourited, then display it.
            if (MainWindow.burgerFave)
            {
                CookbookRecipes burger = new CookbookRecipes();
                burger.Number = 1.ToString() + ".";
                burger.Title = GlobalData.Instance._burger._name;
                //burger.Description = GlobalData.Instance._burger._description;
                burger.Dur = GlobalData.Instance._burger._duration.ToString() + " min";

                
                //BitmapImage food = new BitmapImage();
                //food.BeginInit();
                //food.UriSource = new Uri("Images/burger.jpg", UriKind.Relative);
                //food.EndInit();

                burger.FoodImage = GlobalData.Instance._burger._image;

                //IF recipe difficulty = medium
                burger.DiffImage = (BitmapImage)Application.Current.Resources["medIconIcon"];

                if (GlobalData.Instance._burger._difficulty == Recipe.Difficulties.EASY)
                    burger.DiffImage = (BitmapImage)Application.Current.Resources["easyIconIcon"];
                else if (GlobalData.Instance._burger._difficulty == Recipe.Difficulties.MEDIUM)
                    burger.DiffImage = (BitmapImage)Application.Current.Resources["medIconIcon"];
                else if (GlobalData.Instance._burger._difficulty == Recipe.Difficulties.HARD)
                    burger.DiffImage = (BitmapImage)Application.Current.Resources["hardIconIcon"];

                //burger.Click += editButton_Click;
                burger.editButton.Click += editButton_Click;
                burger.foodProfileButton.Click += foodProfileButton_Click;

                Recipes.Children.Add(burger);
            }*/


            /*This is with Global data in main...
            if (MainWindow.burgerFave)
            {
                //IF burger is favourited
                CookbookRecipes burger = new CookbookRecipes();
                burger.Number = 1.ToString() + ".";
                burger.Title = MainWindow.burgerProperties._name;
                burger.Description = MainWindow.burgerProperties._description;
                burger.Dur = MainWindow.burgerProperties._duration.ToString() + " min";


                burger.FoodImage = MainWindow.burgerProperties._image;

                //IF recipe difficulty = medium
                burger.DiffImage = (BitmapImage)Application.Current.Resources["medIconIcon"];

                if (MainWindow.burgerProperties._difficulty == Recipe.Difficulties.EASY)
                    burger.DiffImage = (BitmapImage)Application.Current.Resources["easyIconIcon"];
                else if (MainWindow.burgerProperties._difficulty == Recipe.Difficulties.MEDIUM)
                    burger.DiffImage = (BitmapImage)Application.Current.Resources["medIconIcon"];
                else if (MainWindow.burgerProperties._difficulty == Recipe.Difficulties.HARD)
                    burger.DiffImage = (BitmapImage)Application.Current.Resources["hardIconIcon"];

                //burger.Click += editButton_Click;
                burger.editButton.Click += editButton_Click;
                burger.foodProfileButton.Click += foodProfileButton_Click;

                Recipes.Children.Add(burger);
            }
            */

            /* OG
            if (MainWindow.burgerFave == true)
            {
                //IF burger is favourited
                CookbookRecipes burger = new CookbookRecipes();
                burger.Number = 1.ToString() + ".";
                burger.Title = GlobalData.Instance._burger._name;
                //burger.Title = GlobalData.Instance.burger._name;
                burger.Description = "This is the food description";
                burger.Dur = "30 min";


                //BitmapImage food = new BitmapImage();
                //food.BeginInit();
                //food.UriSource = new Uri("Images/burger.jpg", UriKind.Relative);
                //food.EndInit();

                burger.FoodImage = (BitmapImage)Application.Current.Resources["burgerIcon"];

                //IF recipe difficulty = medium
                burger.DiffImage = (BitmapImage)Application.Current.Resources["medIconIcon"];

                //burger.Click += editButton_Click;
                burger.editButton.Click += editButton_Click;
                burger.foodProfileButton.Click += foodProfileButton_Click;

                Recipes.Children.Add(burger);

            }
            */
        }
        /*
        //public event RoutedEventHandler Click;
        public void editButton_Click(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/questions/41333040/wpf-best-practice-to-get-current-mainwindow-instance
            //burger.Title = "HOW DARE YOU!!!";
            //blah.Content = "HOW DARE YOU!!!!";
            //((MainWindow)App.Current.MainWindow).Test.Text = "This is simply a test";
            //Mod mod = new Mod();
            Mod mod = GlobalData.Instance.modification;
            ((MainWindow)App.Current.MainWindow).Main.Content = mod;


        }
        public void foodProfileButton_Click(object sender, RoutedEventArgs e)
        {
            //https://stackoverflow.com/questions/41333040/wpf-best-practice-to-get-current-mainwindow-instance
            //burger.Title = "HOW DARE YOU!!!";
            //blah.Content = "HOW DARE YOU!!!!";
            //((MainWindow)App.Current.MainWindow).Test.Text = "This is simply a test";
            
            //((MainWindow)App.Current.MainWindow).Main.Content = ((MainWindow)App.Current.MainWindow).searchPage1;
            //((MainWindow)App.Current.MainWindow).Main.Content = GlobalData.Instance.search;

            //RecipeProfilePage profile = new RecipeProfilePage(GlobalData.Instance._shanghaiNoodlesRecipe);
            
            
            
            //((MainWindow)App.Current.MainWindow).Main.Content = MainWindow.shanghaiProfile;
        }
        */
    }
}
