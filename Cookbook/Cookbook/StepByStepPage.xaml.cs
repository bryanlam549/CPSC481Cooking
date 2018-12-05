using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;


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
               String step =  recipeSteps.ElementAt(currentStep);
                if (step.Contains("<hyperLink>"))
                {
                    int index = step.IndexOf("<hyperLink>");
                    String textBeforeLookup = step.Substring(0, index);
                    // String textAfterLookUp = step.Substring(index + 1, step.Length -1 );
                    int endTag = step.IndexOf("</hyperLink>");
                    int wordLength = endTag - index - 11;
                    String lookUpWord = step.Substring(index + 11, wordLength);
                    String restOfString = step.Substring(endTag + 12);
                    Console.WriteLine(textBeforeLookup);
                    Console.WriteLine(restOfString);
                    Console.WriteLine(lookUpWord);

                    _stepBody.Inlines.Add(textBeforeLookup);

                    Hyperlink link = new Hyperlink();
                    link.IsEnabled = true;
                    link.Inlines.Add(lookUpWord);
                    link.Click += handleLookUpWord;
                    _stepBody.Inlines.Add(link);
                    _stepBody.Inlines.Add(restOfString);

                }
                else
                {
                    _stepBody.Text = recipeSteps.ElementAt(currentStep);
                }
            }
        
            if(currentStep == 0)
            {
                // need a way to make it hidden
                // TO: DO  need a clearner way to do this 
                _previousStep.transitionPageButton.IsEnabled = false;
                _previousStep.transitionPageButton.Visibility = System.Windows.Visibility.Hidden;
            }
            _nextStep.transitionPageButton.Click += Next_Step_Click;
            _previousStep.transitionPageButton.Click += Prev_Step_Click;
            _backButton.transitionPageButton.Click += Back_Button_Click;


            _backButton.initAppearance(TransitionPageButton.Orientation.BACK, "BACK");
            _previousStep.initAppearance(TransitionPageButton.Orientation.BACK, "PREVIOUS");
            _nextStep.initAppearance(TransitionPageButton.Orientation.FORWARD, "NEXT");





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

                // go to completion page
                RecipeCompletionPage completionPage = new RecipeCompletionPage(currentRecipe);
                this.NavigationService.Navigate(completionPage);
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
            Mod mod = new Mod(currentRecipe, 0);
            ((MainWindow)App.Current.MainWindow).Main.Content = mod;
        }

        private void handleLookUpWord(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("The link works!");


        }
    }


}
