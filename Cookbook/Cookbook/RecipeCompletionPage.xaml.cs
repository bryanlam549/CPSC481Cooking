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
    /// 

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

            _back.initAppearance(TransitionPageButton.Orientation.BACK, "BACK TO STEPS");
            _next.initAppearance(TransitionPageButton.Orientation.FORWARD, "GO TO RECIPE PAGE");

            favHeart._recipe = currentRecipe;
            if (recipe._isFavourite)
            {
                favHeart.HeartIconImage = (BitmapImage)Application.Current.Resources["heartIcon"];
                favHeart._isFilled = true;
            }

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<String, RecipeProfilePage> recipes = GlobalData.Instance.recipePageList;
            RecipeProfilePage recipeProfile = recipes[currentRecipe._name];
            recipeProfile._completionPage = this;
            recipeProfile._currentStep = 0;
            recipeProfile._startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "To RECIPE COMPLETION PAGE");
            this.NavigationService.Navigate(recipeProfile);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<String, RecipeProfilePage> recipes = GlobalData.Instance.recipePageList;
            RecipeProfilePage recipeProfile = recipes[currentRecipe._name];
            recipeProfile._completionPage = null;
            recipeProfile._currentStep = currentRecipe._steps.Count - 1;
            recipeProfile._startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "CONTINUE");

            StepByStepPage step = StepPage.allSteps.ElementAt(currentRecipe._steps.Count - 1);

            this.NavigationService.Navigate(step);
        }

        private void _close_Click(object sender, RoutedEventArgs e)
        {
            this.signInBox.Visibility = System.Windows.Visibility.Hidden;
            completionMain.IsEnabled = true;
        }

        private bool modified;
        public bool Modified
        {
            get { return modified; }
            set
            {
                modified = value;
            }
        }


        //Number in list
        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                //this.NumberText.Content = this.number + ".";
            }
        }

        private void onEdit(object sender, RoutedEventArgs e)
        {

            Mod mod = new Mod(currentRecipe, 0);
            ((MainWindow)App.Current.MainWindow).Main.Content = mod;

        }
    }

}
