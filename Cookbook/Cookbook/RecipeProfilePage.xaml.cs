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
        public int _currentStep = 0 ;
        public Page _completionPage;
      

        public RecipeProfilePage(Recipe recipe)
        {
            InitializeComponent();

            // init components...
            //_heartButton._recipe = ... set based

            _recipe = recipe; // ~~~~NOTE: set to proper recipe later on based on recipe clicked on, but hard coded this for testing

            //This was done by me, BRYAN. I would've initialized heartButton user control so that it is filled if the recipe is fave or not. 
            //but I was running into problems there (i think because _recipe is null even though you make it equal to this _recipe...)
            //but it works if try it on this page. Had to add function in HeartButton.xaml and made isfilled public.
            _heartButton._recipe = _recipe;
            if (_recipe._isFavourite)
            {
                _heartButton.HeartIconImage = (BitmapImage)Application.Current.Resources["heartIcon"];
                _heartButton._isFilled = true;
            }
            else
            {
                _heartButton.HeartIconImage = (BitmapImage)Application.Current.Resources["unfillHeartIcon"];
                _heartButton._isFilled = false;
            }

            _recipeNameTextBlock.Text = _recipe._name;

            _recipeImageBrush.ImageSource = _recipe._image;

            _startButton.transitionPageButton.Click += StartButton_Click;

            _backButton.initAppearance(TransitionPageButton.Orientation.BACK, "BACK");

            _startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "START");

            AddIngredientTabs();
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_completionPage == null && _currentStep == 0 )
            {
                StepPage mainStep = new StepPage(_recipe);
                this.NavigationService.Navigate(mainStep);
            }
            else if(_completionPage == null && _currentStep > 0)
            {
                StepByStepPage step = StepPage.allSteps.ElementAt(_currentStep);
                this.NavigationService.Navigate(step);
            }else if(_completionPage != null)
            {
                this.NavigationService.Navigate(_completionPage);
            }
            
        }

        
        private void AddIngredientTabs()
        {
            foreach(Ingredient ingredient in _recipe._ingredients)
            {
                stackPanel.Children.Add(new IngredientTab(ingredient));
            }

        }



    }
}
