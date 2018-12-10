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
        private BitmapImage fillStarImage = (BitmapImage) Application.Current.Resources["fillStarIcon"];
        private BitmapImage unfillStarImage = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

        private List<Recipe> _recipeList;

        //Pass in a LIST of recipes. 
        public CookbookFavouritePage(List<Recipe> recipeList)
        {
            InitializeComponent();

            _recipeList = recipeList;

            /*
            int num = 0;
            for (int i = 0; i < recipeList.Count; i++)
            {
                if (recipeList[i]._isFavourite)
                {
                    CookbookRecipes recipe = new CookbookRecipes(RecipeProfilePage.BackPage.FAV);
                    num++;
                    recipe.Number = num.ToString();
                    recipe.Title = recipeList[i]._name;
                    recipe.Dur = recipeList[i]._duration.ToString() + "m";
                    recipe.ingNum.Content = recipeList[i]._ingredients.Count.ToString() + " Ingredients";
                    recipe.FoodImage = recipeList[i]._image;



                    if (recipeList[i]._difficulty == Recipe.Difficulties.EASY)
                        recipe.DiffImage = (BitmapImage)Application.Current.Resources["easyIconIcon"];
                    else if (recipeList[i]._difficulty == Recipe.Difficulties.MEDIUM)
                        recipe.DiffImage = (BitmapImage)Application.Current.Resources["medIconIcon"];
                    else if (recipeList[i]._difficulty == Recipe.Difficulties.HARD)
                        recipe.DiffImage = (BitmapImage)Application.Current.Resources["hardIconIcon"];

                    //recipe.editButton.Click += editButton_Click;
                    //recipe.foodProfileButton.Click += foodProfileButton_Click;

                    //Still need to add ratings
                    if (recipeList[i]._rating == 1)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = unfillStarImage;
                        recipe.Rate3Image = unfillStarImage;
                        recipe.Rate4Image = unfillStarImage;
                        recipe.Rate5Image = unfillStarImage;
                    }
                    else if (recipeList[i]._rating == 2)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = fillStarImage;
                        recipe.Rate3Image = unfillStarImage;
                        recipe.Rate4Image = unfillStarImage;
                        recipe.Rate5Image = unfillStarImage;
                    }
                    else if (recipeList[i]._rating == 3)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = fillStarImage;
                        recipe.Rate3Image = fillStarImage;
                        recipe.Rate4Image = unfillStarImage;
                        recipe.Rate5Image = unfillStarImage;
                    }
                    else if (recipeList[i]._rating == 4)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = fillStarImage;
                        recipe.Rate3Image = fillStarImage;
                        recipe.Rate4Image = fillStarImage;
                        recipe.Rate5Image = unfillStarImage;
                    }
                    else if (recipeList[i]._rating == 5)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = fillStarImage;
                        recipe.Rate3Image = fillStarImage;
                        recipe.Rate4Image = fillStarImage;
                        recipe.Rate5Image = fillStarImage;
                    }
                    recipe.Modified = recipeList[i].modified; 
                    Recipes.Children.Add(recipe);
                }
                else
                {
                    continue;
                }
            }
            */

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePage();
            GlobalData.Instance.savedMainWindowContent = ((MainWindow)App.Current.MainWindow).Main.Content;
            GlobalData.Instance.backPageTag = RecipeProfilePage.BackPage.COOKBOOK;
        }


        private void UpdatePage()
        {
            Recipes.Children.Clear();

            int num = 0;
            for (int i = 0; i < _recipeList.Count; i++)
            {
                if (_recipeList[i]._isFavourite)
                {
                    CookbookRecipes recipe = new CookbookRecipes();
                    num++;
                    recipe.Number = num.ToString();
                    recipe.Title = _recipeList[i]._name;
                    recipe.Dur = _recipeList[i]._duration.ToString() + "m";
                    recipe.ingNum.Content = _recipeList[i]._ingredients.Count.ToString() + " Ingredients";
                    recipe.FoodImage = _recipeList[i]._image;



                    if (_recipeList[i]._difficulty == Recipe.Difficulties.EASY)
                        recipe.DiffImage = (BitmapImage)Application.Current.Resources["easyIconIcon"];
                    else if (_recipeList[i]._difficulty == Recipe.Difficulties.MEDIUM)
                        recipe.DiffImage = (BitmapImage)Application.Current.Resources["medIconIcon"];
                    else if (_recipeList[i]._difficulty == Recipe.Difficulties.HARD)
                        recipe.DiffImage = (BitmapImage)Application.Current.Resources["hardIconIcon"];

                    //recipe.editButton.Click += editButton_Click;
                    //recipe.foodProfileButton.Click += foodProfileButton_Click;

                    //Still need to add ratings
                    if (_recipeList[i]._rating == 1)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = unfillStarImage;
                        recipe.Rate3Image = unfillStarImage;
                        recipe.Rate4Image = unfillStarImage;
                        recipe.Rate5Image = unfillStarImage;
                    }
                    else if (_recipeList[i]._rating == 2)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = fillStarImage;
                        recipe.Rate3Image = unfillStarImage;
                        recipe.Rate4Image = unfillStarImage;
                        recipe.Rate5Image = unfillStarImage;
                    }
                    else if (_recipeList[i]._rating == 3)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = fillStarImage;
                        recipe.Rate3Image = fillStarImage;
                        recipe.Rate4Image = unfillStarImage;
                        recipe.Rate5Image = unfillStarImage;
                    }
                    else if (_recipeList[i]._rating == 4)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = fillStarImage;
                        recipe.Rate3Image = fillStarImage;
                        recipe.Rate4Image = fillStarImage;
                        recipe.Rate5Image = unfillStarImage;
                    }
                    else if (_recipeList[i]._rating == 5)
                    {
                        recipe.Rate1Image = fillStarImage;
                        recipe.Rate2Image = fillStarImage;
                        recipe.Rate3Image = fillStarImage;
                        recipe.Rate4Image = fillStarImage;
                        recipe.Rate5Image = fillStarImage;
                    }
                    recipe.Modified = _recipeList[i].modified;
                    Recipes.Children.Add(recipe);
                }
                else
                {
                    continue;
                }
            }
        }



    }
    /*
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
    if(_faveList[i]._rating==1)
    {
        recipe.Rate1Image = fillStarImage;
        recipe.Rate2Image = unfillStarImage;
        recipe.Rate3Image = unfillStarImage;
        recipe.Rate4Image = unfillStarImage;
        recipe.Rate5Image = unfillStarImage;
    }
    else if (_faveList[i]._rating==2)
    {
        recipe.Rate1Image = fillStarImage;
        recipe.Rate2Image = fillStarImage;
        recipe.Rate3Image = unfillStarImage;
        recipe.Rate4Image = unfillStarImage;
        recipe.Rate5Image = unfillStarImage;
    }
    else if (_faveList[i]._rating==3)
    {
        recipe.Rate1Image = fillStarImage;
        recipe.Rate2Image = fillStarImage;
        recipe.Rate3Image = fillStarImage;
        recipe.Rate4Image = unfillStarImage;
        recipe.Rate5Image = unfillStarImage;
    }
    else if (_faveList[i]._rating==4)
    {
        recipe.Rate1Image = fillStarImage;
        recipe.Rate2Image = fillStarImage;
        recipe.Rate3Image = fillStarImage;
        recipe.Rate4Image = fillStarImage; 
        recipe.Rate5Image = unfillStarImage;
    }
    else if (_faveList[i]._rating==5)
    {
        recipe.Rate1Image = fillStarImage;
        recipe.Rate2Image = fillStarImage;
        recipe.Rate3Image = fillStarImage;
        recipe.Rate4Image = fillStarImage;
        recipe.Rate5Image = fillStarImage;
    }
    Recipes.Children.Add(recipe);
}
*/

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
