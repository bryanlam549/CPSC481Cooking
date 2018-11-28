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
    /// Interaction logic for StepByStepPage.xaml
    /// </summary>
    public partial class StepByStepPage : Page
    {
        Recipe currentRecipe;
        List<String> recipeSteps;
        int currentStep;
        public StepByStepPage(Recipe recipe, int currentStep)
        {
            InitializeComponent();
            this.currentRecipe = recipe;
            this.currentStep = currentStep;
            this.recipeSteps = currentRecipe.GetSteps();

            _recipeName.Text = currentRecipe.getName();
            _stepNumber.Text = "Step " + (currentStep + 1) + " of " + recipeSteps.Count();

            if (currentStep < recipeSteps.Count)
            {
                _stepBody.Text = recipeSteps.ElementAt(currentStep);
            }
        

            _nextStep.transitionPageButton.Click += Next_Step_Click;
            _previousStep.transitionPageButton.Click += Prev_Step_Click;
            _backButton.transitionPageButton.Click += Back_Button_Click;



        }
        private void Next_Step_Click(object sender, RoutedEventArgs e)
        {
            if (currentStep  < recipeSteps.Count - 1)
            {
                StepByStepPage nextStep = new StepByStepPage(currentRecipe, currentStep + 1);
                this.NavigationService.Navigate(nextStep);
            }
            else
            {
                //make the next button invisible
            }
        }

        private void Prev_Step_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            RecipeProfilePage recipeProfile = new RecipeProfilePage(currentRecipe);

        }

        private void onButtonClickEdit(object sender, RoutedEventArgs e)
        {
            //((MainWindow)App.Current.MainWindow).Test.Text = "This is simply a test";
           
        }
    }


}
