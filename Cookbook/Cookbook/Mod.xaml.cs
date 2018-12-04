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

        public Recipe recipeMod = new Recipe();
        public Mod(Recipe _recipe)
        {
            InitializeComponent();
            //recipe = _recipe;
            //COPY the recipe...Might not actually be a copy....
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




            modTitle.Text = recipeMod._name;
        }

        private void cookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ingButton_Click(object sender, RoutedEventArgs e)
        {
            ModIngredients modIngPg = new ModIngredients(recipeMod);
            ((MainWindow)App.Current.MainWindow).Main.Content = modIngPg;
        }

        private void equipButton_Click(object sender, RoutedEventArgs e)
        {
            ModEquipments modEquipPg = new ModEquipments();
            ((MainWindow)App.Current.MainWindow).Main.Content = modEquipPg;
        }

        private void stepsButton_Click(object sender, RoutedEventArgs e)
        {
            ModSteps modStepsPg = new ModSteps(recipeMod);
            ((MainWindow)App.Current.MainWindow).Main.Content = modStepsPg;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //Need to add into ModList
            //Need to reload previous page, just gonna be hard coded to favourite page rn...
            GlobalData.Instance.modRecipeList.Add(recipeMod);

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
    }
}
