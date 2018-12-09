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
    /// Interaction logic for Mod.xaml
    /// </summary>
    public partial class Mod : Page
    {
        public int recipeNum;
        Page previousPage = GlobalData.Instance.prevPage;
        public Recipe recipeMod = new Recipe();
        public Recipe copy = new Recipe();
        public Mod(Recipe _recipe, int _recipeNum)
        {
            InitializeComponent();
            recipeNum = _recipeNum;  //This is used to determine which recipe to replace when the  recipe being edited is already modified
            //recipe = _recipe;
            //COPY the recipe...Might not actually be a copy....
            //I NEEEED A DEEP COPY!
            /*This doesn't do it!
            Recipe deepCopy = new Recipe()
            {
                _isFavourite = _recipe._isFavourite,
                _name = _recipe._name,
                _image = _recipe._image,
                _difficulty = _recipe._difficulty,
                _rating = _recipe._rating,
                _duration = _recipe._duration,
                _description = _recipe._description,
                _servings = _recipe._servings,
                _ingredientCount = _recipe._ingredientCount,
                _category = _recipe._category,
                _equipment = _recipe._equipment,
                _steps = _recipe._steps
            };
            recipeMod = deepCopy;*/


            //This doesn't do it either for some reason....

            
            bool tempFave = _recipe._isFavourite;
            recipeMod._isFavourite = tempFave;

            string tempName = _recipe._name;
            recipeMod._name = tempName;

            BitmapImage tempImage = _recipe._image;
            recipeMod._image = tempImage;

            int tempRating = _recipe._rating;
            recipeMod._rating = tempRating;

            int tempDuration = _recipe._duration;
            recipeMod._duration = tempDuration;

            Recipe.Difficulties tempDiff = _recipe._difficulty;
            recipeMod._difficulty = tempDiff;

            string tempDesc = _recipe._description;
            recipeMod._description = tempDesc;

            int tempServe = _recipe._servings;
            recipeMod._servings = tempServe;

            int tempIngCount = _recipe._ingredientCount;
            recipeMod._ingredientCount = tempIngCount;

            Recipe.Categories tempCategories = _recipe._category;
            recipeMod._category = tempCategories;

            bool tempModified = _recipe.modified;
            recipeMod.modified = tempModified;

            List<Ingredient> tempIngredients = new List<Ingredient>();
            for(int i = 0; i < _recipe._ingredients.Count; i++)
            {
                tempIngredients.Add(_recipe._ingredients[i]);
                recipeMod._ingredients.Add(tempIngredients[i]);
            }
            
            List<string> tempEquip = new List<string>();
            for (int i = 0; i < _recipe._equipment.Count; i++)
            {
                tempEquip.Add(_recipe._equipment[i]);
                recipeMod._equipment.Add(tempEquip[i]);
            }
            
            List<string> tempSteps = new List<string>();
            for (int i = 0; i < _recipe._steps.Count; i++)
            {
                tempSteps.Add(_recipe._steps[i]);
                recipeMod._steps.Add(tempSteps[i]);
            }
            

            /*
            recipeMod._isFavourite = _recipe._isFavourite;
            recipeMod._name = _recipe._name;
            recipeMod._image = _recipe._image;
            recipeMod._rating = _recipe._rating;
            recipeMod._duration = _recipe._duration;
            recipeMod._difficulty = _recipe._difficulty;
            recipeMod._description = _recipe._description;
            recipeMod._servings = _recipe._servings;
            recipeMod._ingredientCount = _recipe._ingredientCount;
            recipeMod._category = _recipe._category;
            recipeMod._ingredients = _recipe._ingredients;
            recipeMod._equipment = _recipe._equipment;
            recipeMod._steps = _recipe._steps;
            */
            modTitle.Text = recipeMod._name;
            //modTitle.Text = recipeMod._steps.Count.ToString();
        }

        //Back button
        private void cookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.GoBack();
            this.NavigationService.Navigate(previousPage);
        }

        private void ingButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.currentlyModifying = GlobalData.Instance.copy(recipeMod);
            ModIngredients modIngPg = new ModIngredients(recipeMod, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = modIngPg;
        }

        private void equipButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.currentlyModifying = GlobalData.Instance.copy(recipeMod);
            ModEquipments modEquipPg = new ModEquipments(recipeMod, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = modEquipPg;
        }

        private void stepsButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.Instance.currentlyModifying = GlobalData.Instance.copy(recipeMod);
            ModSteps modStepsPg = new ModSteps(recipeMod, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = modStepsPg;
        }

        public List<Recipe> globalModRecipeList = GlobalData.Instance.modRecipeList;
        public List<RecipeProfilePage> globalModPageList = GlobalData.Instance.modrecipePageList;
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            
            //If the recipe is an original, then add it into the modified tab
            if (recipeMod.modified == false)
            {
                //Need to add into ModList
                recipeMod.modified = true;  //Flag as modified recipe
                globalModRecipeList.Add(recipeMod);   //Add it into the modified recipe list
                                                                    //Also make an instance of a profile page for later access
                RecipeProfilePage modProfilePage = new RecipeProfilePage(recipeMod);
                globalModPageList.Add(modProfilePage);

                
            }
            //If the recipe is modified, then the edits will just replace it
            else
            {
                //I need to know the one i'm replacing
                globalModRecipeList.RemoveAt(recipeNum);
                globalModPageList.RemoveAt(recipeNum);

                globalModRecipeList.Insert(recipeNum, recipeMod);
                RecipeProfilePage modProfilePage = new RecipeProfilePage(recipeMod);
                globalModPageList.Insert(recipeNum, modProfilePage);

            }

            //Need to reload previous page, just gonna be hard coded to favourite page rn...
            //Probably pass in previous page into this page. Or have "previous page" as a global data. and reload it when this button is pressed.
            CookbookPage1 prevPage = new CookbookPage1();
            ((MainWindow)App.Current.MainWindow).Main.Content = prevPage;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Don't update the modList
            //Probably pass in previous page into this page. Or have "previous page" as a global data. and reload it when this button is pressed.
            CookbookPage1 prevPage = new CookbookPage1();
            ((MainWindow)App.Current.MainWindow).Main.Content = prevPage;
        }

        //This is for rename button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.IsEnabled = false;
            foodBox.Text = recipeMod._name;
            modBox.Visibility = System.Windows.Visibility.Visible;
            
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            bool nameTaken = false;
            for(int i = 0; i < GlobalData.Instance.modRecipeList.Count; i++)
            {
                if (recipeMod._name == GlobalData.Instance.modRecipeList[i]._name)
                {
                    nameTaken = true;
                }
            }

            if (!nameTaken)
            {
                if (!string.IsNullOrWhiteSpace(foodBox.Text))
                {
                    recipeMod._name = foodBox.Text;
                    this.modBox.Visibility = System.Windows.Visibility.Hidden;
                    Mod updatePage = new Mod(recipeMod, recipeNum);
                    ((MainWindow)App.Current.MainWindow).Main.Content = updatePage;
                    mainGrid.IsEnabled = true;
                    error.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    error.Visibility = System.Windows.Visibility.Visible;
                    error.Content = "*Please do not leave blank*";

                }
            }
            else
            {
                error.Visibility = System.Windows.Visibility.Visible;
                error.Content = "*Name already in your personal list*";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.modBox.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
            error.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
