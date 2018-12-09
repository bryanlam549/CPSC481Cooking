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
        public Mod(Recipe _recipe, int _recipeNum)
        {
            InitializeComponent();
            recipeNum = _recipeNum;  //This is used to determine which recipe to replace when the  recipe being edited is already modified

            // deep copy recipe...

            recipeMod = new Recipe(_recipe);

            modTitle.Text = recipeMod._name;
        }

        //Back button
        private void cookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void ingButton_Click(object sender, RoutedEventArgs e)
        {
            ModIngredients modIngPg = new ModIngredients(recipeMod, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = modIngPg;
        }

        private void equipButton_Click(object sender, RoutedEventArgs e)
        {
            ModEquipments modEquipPg = new ModEquipments(recipeMod, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = modEquipPg;
        }

        private void stepsButton_Click(object sender, RoutedEventArgs e)
        {
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
            if (!string.IsNullOrWhiteSpace(foodBox.Text))
            {
                recipeMod._name = foodBox.Text;
                this.modBox.Visibility = System.Windows.Visibility.Hidden;
                Mod updatePage = new Mod(recipeMod,recipeNum);
                ((MainWindow)App.Current.MainWindow).Main.Content = updatePage;
                mainGrid.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Can't leave blank.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.modBox.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
        }
    }
}
