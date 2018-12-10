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
        //public Recipe recipeMod = new Recipe();
        public Recipe recipeMod;

        // _recipe is the recipe to copy...
        //public Recipe recipeMod = new Recipe();
        //public Recipe copy = new Recipe();
        public Mod(Recipe _recipe, int _recipeNum)
        {
            InitializeComponent();
            recipeNum = _recipeNum;  //This is used to determine which recipe to replace when the  recipe being edited is already modified
            
            // deep copy recipe...

            recipeMod = new Recipe(_recipe);


            if (recipeMod.modified)
                Explaination.Content = "*Any changes replaces the recipe in the personal list!*";

            for (int i = 0; i < GlobalData.Instance.recipeList.Count; i++)
            {
                if(recipeMod._name == GlobalData.Instance.recipeList[i]._name)
                {
                    recipeMod._name = "*" + recipeMod._name;
                    break;
                }
                /*
                if (!recipeMod.modified)
                {
                    recipeMod._name = "*" + recipeMod._name;
                }*/
            }
            modTitle.Text = recipeMod._name;
        }

        //Back button
        private void cookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            unsavedPopup.Visibility = System.Windows.Visibility.Visible;
            mainGrid.IsEnabled = false;

            //this.NavigationService.Navigate(previousPage);
        }

        private void ingButton_Click(object sender, RoutedEventArgs e)
        {
            //GlobalData.Instance.currentlyModifying = GlobalData.Instance.copy(recipeMod);
            GlobalData.Instance.currentlyModifying = new Recipe(recipeMod);
            ModIngredients modIngPg = new ModIngredients(recipeMod, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = modIngPg;
        }

        private void equipButton_Click(object sender, RoutedEventArgs e)
        {
            //GlobalData.Instance.currentlyModifying = GlobalData.Instance.copy(recipeMod);
            GlobalData.Instance.currentlyModifying = new Recipe(recipeMod);
            ModEquipments modEquipPg = new ModEquipments(recipeMod, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = modEquipPg;
        }

        private void stepsButton_Click(object sender, RoutedEventArgs e)
        {
            //GlobalData.Instance.currentlyModifying = GlobalData.Instance.copy(recipeMod);
            GlobalData.Instance.currentlyModifying = new Recipe(recipeMod);
            ModSteps modStepsPg = new ModSteps(recipeMod, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = modStepsPg;
        }



        public List<Recipe> globalModRecipeList = GlobalData.Instance.modRecipeList;
        public List<RecipeProfilePage> globalModPageList = GlobalData.Instance.modrecipePageList;
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            bool nameTaken = false;
            for (int i = 0; i < GlobalData.Instance.modRecipeList.Count; i++)
            {
                if (recipeMod._name == GlobalData.Instance.modRecipeList[i]._name)
                {
                    nameTaken = true;
                }
            }
            if (!nameTaken || recipeMod.modified)
            {
                //If the recipe is an original, then add it into the modified tab
                if (recipeMod.modified == false)
                {
                    //Need to add into ModList
                    recipeMod.modified = true;  //Flag as modified recipe
                    globalModRecipeList.Add(recipeMod);   //Add it into the modified recipe list
                                                          //Also make an instance of a profile page for later access
                                                          /*
                    bool nameInRecipe = false;
                    for(int i = 0; i < GlobalData.Instance.recipeList.Count; i++)
                    {
                        if(recipeMod._name == GlobalData.Instance.recipeList[i]._name)
                        {
                            nameInRecipe = true;
                        }
                    }*/
                    //if (nameInRecipe)
                      //  recipeMod._name = "*" + recipeMod._name;

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
                //CookbookPage1 prevPage = new CookbookPage1();
                //((MainWindow)App.Current.MainWindow).Main.Content = prevPage;
                //this.NavigationService.Navigate(previousPage);
                GlobalData.Instance.currentRecipe = null;
                GlobalData.Instance.goBackToPersonal = true;
                CookbookPage1 x = new CookbookPage1();
                ((MainWindow)App.Current.MainWindow).currentRecipePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["currentRecipeButtonIcon"];
                ((MainWindow)App.Current.MainWindow).cookbookPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["cookbookButtonDarkIcon"];
                this.NavigationService.Navigate(x);

            }
            else
            {
                error1.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Don't update the modList
            //Probably pass in previous page into this page. Or have "previous page" as a global data. and reload it when this button is pressed.
            //CookbookPage1 prevPage = new CookbookPage1();
            //((MainWindow)App.Current.MainWindow).Main.Content = prevPage;
            this.NavigationService.Navigate(previousPage);
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
            for (int i = 0; i < GlobalData.Instance.modRecipeList.Count; i++)
            {
                if (foodBox.Text == GlobalData.Instance.modRecipeList[i]._name)
                {
                    nameTaken = true;
                }
            }

            if (!nameTaken || recipeMod.modified)
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

        private void unsavedYesButton_Click(object sender, RoutedEventArgs e)
        {

            unsavedPopup.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
            this.NavigationService.Navigate(previousPage);
        }

        private void unsaved_noButton_Click(object sender, RoutedEventArgs e)
        {
            unsavedPopup.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
        }

    }
}
