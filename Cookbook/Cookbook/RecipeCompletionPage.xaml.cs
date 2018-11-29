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
    /// Interaction logic for RecipeCompletionPage.xaml
    /// </summary>
    public partial class RecipeCompletionPage : Page
    {
        Recipe currentRecipe;
        public RecipeCompletionPage(Recipe recipe)
        {
            InitializeComponent();
            this.currentRecipe = recipe;
            _back.transitionPageButton.Click += Back_Click;
            _next.transitionPageButton.Click += Next_Click;
            _recipeImageBrush.ImageSource = recipe._image;
            _recipeName.Text = recipe._name;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            RecipeProfilePage recipeProfile = new RecipeProfilePage(currentRecipe);
            this.NavigationService.Navigate(recipeProfile);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void onButtonClickEdit(object sender, RoutedEventArgs e)
        {
            //((MainWindow)App.Current.MainWindow).Test.Text = "This is simply a test";

        }

    }
}
