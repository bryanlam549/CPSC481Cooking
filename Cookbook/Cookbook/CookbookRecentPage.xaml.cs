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
    /// Interaction logic for CookbookRecentPage.xaml
    /// </summary>
    public partial class CookbookRecentPage : Page
    {
        private BitmapImage fillStarImage = (BitmapImage)Application.Current.Resources["fillStarIcon"];
        private BitmapImage unfillStarImage = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

        private List<Recipe> _recipeList;

        public CookbookRecentPage(List<Recipe> recipeList)
        {
            InitializeComponent();

            _recipeList = recipeList;


            /*
            int num =recipeList.Count + 1;
            for (int i = 0; i < recipeList.Count; i++)
            {
                
                CookbookRecipes recipe = new CookbookRecipes(RecipeProfilePage.BackPage.RECENT);
                num--;
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
                Recipes.Children.Insert(0,recipe);

            }
            if (Recipes.Children.Count == 0)
            {
                noText.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                noText.Visibility = System.Windows.Visibility.Hidden;

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

            int num = _recipeList.Count + 1;
            for (int i = 0; i < _recipeList.Count; i++)
            {

                CookbookRecipes recipe = new CookbookRecipes();
                num--;
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
                Recipes.Children.Insert(0, recipe);

            }
            if (Recipes.Children.Count == 0)
            {
                noText.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                noText.Visibility = System.Windows.Visibility.Hidden;

            }
        }


    }
}
