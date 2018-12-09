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

using System.Diagnostics;

// ~~~~~~~~~~~~~~~NOTE: make sure to actually update the recipe instance when something changes (or create new recipe and add to 

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for RecipeProfilePage.xaml
    /// </summary>
    public partial class RecipeProfilePage : Page
    {
        public enum BackPage { SEARCH, COOKBOOK };

        public Recipe _recipe;
        public int _currentStep = 0;
        public Page _completionPage;

        public BackPage backPage;

        private List<IngredientTab> ingredientTabs = new List<IngredientTab>(); // my workaround for the recipes not referring to proper tabs (IDK WHATS GOING ON)

      

        public RecipeProfilePage(Recipe recipe)
        {
            InitializeComponent();



            // init components...

            _recipe = recipe; 

            //This was done by me, BRYAN. I would've initialized heartButton user control so that it is filled if the recipe is fave or not. 
            //but I was running into problems there (i think because _recipe is null even though you make it equal to this _recipe...)
            //but it works if try it on this page. Had to add function in HeartButton.xaml and made isfilled public.

            // FAVOURITE...
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


            // DIFFICULTY...
            if (_recipe._difficulty == Recipe.Difficulties.EASY)
            {
                _difficultyImage.Source = (BitmapImage)Application.Current.Resources["easyIconIcon"];
            }
            else if (_recipe._difficulty == Recipe.Difficulties.MEDIUM)
            {
                _difficultyImage.Source = (BitmapImage)Application.Current.Resources["medIconIcon"];
            }
            else
            {
                _difficultyImage.Source = (BitmapImage)Application.Current.Resources["hardIconIcon"];
            }

            // RATING...
            _ratingControl.initStartingRating(_recipe._rating);

            // DURATION...
            _durationText.Content = _recipe._duration.ToString() + "m";


            // NAME...
            _recipeNameTextBlock.Text = _recipe._name;

            // IMAGE...
            _recipeImageBrush.ImageSource = _recipe._image;

            // DESCRIPTION...
            _descTextBlock.Text = _recipe._description;

            // SERVINGS...
            servingValueText.Text = _recipe._servings.ToString();


            // TRANSITION BUTTONS...
            _backButton.initAppearance(TransitionPageButton.Orientation.BACK, "BACK");

            _startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "START");

            _backButton.transitionPageButton.Click += BackButton_Click;

            _startButton.transitionPageButton.Click += StartButton_Click;


            // NOTE: im assuming that every recipe has ingredients, equipment and steps (otherwise what is the point?)

            AddIngredientTabs();

            AddEquipmentList();

            AddStepsList();
        }



        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (backPage == BackPage.COOKBOOK)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new Uri("CookbookPage1.xaml", UriKind.RelativeOrAbsolute));
            }
            else if (backPage == BackPage.SEARCH)
            {
                // TODO after i know what the search page is called
            }
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
            }
            else if(_completionPage != null)
            {
                this.NavigationService.Navigate(_completionPage);
            }
            
        }

        
        private void AddIngredientTabs()
        {

            TextBlock header = new TextBlock();
            header.Text = "INGREDIENT CHECKLIST:";
            header.TextAlignment = TextAlignment.Center;
            header.FontSize = 24;
            stackPanel.Children.Add(header);

            foreach(Ingredient ingredient in _recipe._ingredients)
            {
                IngredientTab nextIngredientTab = new IngredientTab(ingredient);
                ingredientTabs.Add(nextIngredientTab);
                stackPanel.Children.Add(nextIngredientTab);
            }

        }


        private void AddEquipmentList()
        {
            TextBlock padding = new TextBlock(); 
            padding.Text = "==================";
            padding.TextAlignment = TextAlignment.Center;
            padding.FontSize = 40;
            stackPanel.Children.Add(padding);


            TextBlock header = new TextBlock();
            header.Text = "EQUIPMENT LIST:";
            header.TextAlignment = TextAlignment.Center;
            header.FontSize = 24;
            stackPanel.Children.Add(header);

            foreach(string eq in _recipe._equipment)
            {
                TextBlock eqText = new TextBlock();
                eqText.Text = "• " + eq;
                eqText.TextAlignment = TextAlignment.Left;
                eqText.FontSize = 24;
                eqText.Width = 500;
                stackPanel.Children.Add(eqText);
            }


        }


        private void AddStepsList()
        {
            TextBlock padding = new TextBlock(); 
            padding.Text = "==================";
            padding.TextAlignment = TextAlignment.Center;
            padding.FontSize = 40;
            stackPanel.Children.Add(padding);

            TextBlock header = new TextBlock();
            header.Text = "STEPS LIST:";
            header.TextAlignment = TextAlignment.Center;
            header.FontSize = 24;
            stackPanel.Children.Add(header);

            int stepNum = 1;
            foreach (string step in _recipe._steps)
            {
                TextBlock stepText = new TextBlock();
                stepText.Text = stepNum + ". " + step;
                stepText.TextAlignment = TextAlignment.Left;
                stepText.FontSize = 18;
                stepText.TextWrapping = TextWrapping.Wrap;
                stepText.Width = 500;
                stackPanel.Children.Add(stepText);
                stepNum++;

                TextBlock smallPadding = new TextBlock();
                smallPadding.Text = "";
                smallPadding.FontSize = 10;
                stackPanel.Children.Add(smallPadding);

            }


        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            int oldServings = _recipe._servings;
            if (oldServings > 1)
            {
                _recipe._servings--;
                int newServings = _recipe._servings;
                servingValueText.Text = newServings.ToString();
                double scalar = (double) newServings / oldServings;

                Debug.WriteLine(scalar);

                foreach(IngredientTab tab in ingredientTabs)
                {
                    tab._ingredient._measurement *= scalar;
                    tab._ingredient.updateMeasurementStr();
                    tab.primaryText.Text = tab._ingredient._measurementStr;
                }

            }

        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            int oldServings = _recipe._servings;
            if (oldServings < 20)
            {
                _recipe._servings++;
                int newServings = _recipe._servings;
                servingValueText.Text = newServings.ToString();
                double scalar = (double) newServings / oldServings;

                foreach (IngredientTab tab in ingredientTabs)
                {
                    tab._ingredient._measurement *= scalar;
                    tab._ingredient.updateMeasurementStr();
                    tab.primaryText.Text = tab._ingredient._measurementStr;
                }

            }
        }

        private void Scroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            foreach (IngredientTab tab in ingredientTabs)
            {
                if (tab.unitChanger.IsVisible && tab.unitChanger.IsDropDownOpen)
                {
                    tab.unitChanger.IsDropDownOpen = false;
                }

                if (tab.subChanger.IsVisible && tab.subChanger.IsDropDownOpen)
                {
                    tab.subChanger.IsDropDownOpen = false;
                }
            }
            
        }
    }
}
