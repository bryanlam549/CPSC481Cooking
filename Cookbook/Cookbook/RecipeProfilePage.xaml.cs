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
    /// Interaction logic for RecipeProfilePage.xaml
    /// </summary>
    public partial class RecipeProfilePage : Page
    {
        public Recipe _recipe;

        public RecipeProfilePage(Recipe recipe)
        {
            InitializeComponent();

            // init components...
            //_heartButton._recipe = ... set based

            _recipe = recipe; // ~~~~NOTE: set to proper recipe later on based on recipe clicked on, but hard coded this for testing

            _heartButton._recipe = _recipe;

            _recipeImageBrush.ImageSource = _recipe._image;

            _startButton.transitionPageButton.Click += StartButton_Click;

        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StepPage mainStep = new StepPage(_recipe);
            this.NavigationService.Navigate(mainStep);
        }
    }
}
