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
        public List<String> recipeSteps;
        int currentStep;
        string currentLookUpWord;
        RecipeProfilePage recipeProfilePage;

 
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
   
            }
        
            if(currentStep == 0)
            {
                // need a way to make it hidden
                // TO: DO  need a clearner way to do this 
                _previousStep.transitionPageButton.IsEnabled = false;
                _previousStep.transitionPageButton.Visibility = System.Windows.Visibility.Hidden;
                _previousStep.initAppearance(TransitionPageButton.Orientation.BACK, "");
            }
            else
            {
                _previousStep.initAppearance(TransitionPageButton.Orientation.BACK, "PREVIOUS");
            }

            setStepBody(recipeSteps.ElementAt(currentStep));
            _nextStep.transitionPageButton.Click += Next_Step_Click;
            _previousStep.transitionPageButton.Click += Prev_Step_Click;
            _backButton.transitionPageButton.Click += Back_Button_Click;


            _backButton.initAppearance(TransitionPageButton.Orientation.BACK, "BACK");
            _nextStep.initAppearance(TransitionPageButton.Orientation.FORWARD, "NEXT");


            //setting a reference for the current step in recipeProfile everytime navigated to this step page 
            Dictionary<String, RecipeProfilePage> recipes = GlobalData.Instance.recipePageList;
            recipeProfilePage = recipes[currentRecipe._name];
            recipeProfilePage._currentStep = currentStep;
            recipeProfilePage._currentStep = currentStep;
            recipeProfilePage._startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "CONTINUE");




        }

        private void setStepBody(String step)
        {
            List<string> keyList = new List<string>(GlobalData.Instance.lookUpTerms.Keys);
            Boolean lookUpAdded = false;
            for (int i = 0; i < keyList.Count; i++)
            {
                string keyword = keyList.ElementAt(i);
                if (step.Contains(keyword) && !lookUpAdded)
                {
                    _stepBody.Text = "";
                    string keyWord = keyList.ElementAt(i);
                    if (step.ToLower().Contains(keyWord.ToLower()))
                    {
                        int index = step.IndexOf(keyList.ElementAt(i));
                        String textBeforeLookup = "";
                        if (index > 0)
                        {
                            textBeforeLookup = step.Substring(0, index);
                        }
                        // String textAfterLookUp = step.Substring(index + 1, step.Length -1 );
                        int wordLength = keyList.ElementAt(i).Count();
                        int endTag;
                        if (index == -1)
                        {
                            endTag = index + 1 + wordLength;
                        }
                        else
                        {
                            endTag = index + wordLength;
                        }

                        String restOfString = step.Substring(endTag);
                        Console.WriteLine(textBeforeLookup);
                        Console.WriteLine(restOfString);
                        Console.WriteLine(keyList.ElementAt(i));

                        _stepBody.Inlines.Add(textBeforeLookup);

                        Hyperlink link = new Hyperlink();
                        link.IsEnabled = true;
                        link.Inlines.Add(keyList.ElementAt(i));
                        link.TextDecorations = null;
                        link.Click += handleLookUpWord;
                        _stepBody.Inlines.Add(link);
                        _stepBody.Inlines.Add(restOfString);

                    }
                    lookUpAdded = true;
                    currentLookUpWord = keyword;
                }
            }

            if(!lookUpAdded)
            {
                _stepBody.Text = recipeSteps.ElementAt(currentStep);
            }
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
                GlobalData.Instance.completionPage = new RecipeCompletionPage(currentRecipe);
                this.NavigationService.Navigate(GlobalData.Instance.completionPage);
            }
        }

        private void Prev_Step_Click(object sender, RoutedEventArgs e)
        {
            if(currentStep > 0)
            {
                StepByStepPage prevStep = new StepByStepPage(currentRecipe, currentStep - 1);
                this.NavigationService.Navigate(prevStep);
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(recipeProfilePage);
        }

        private void onButtonClickEdit(object sender, RoutedEventArgs e)
        {
            Mod mod = new Mod(currentRecipe, 0);
            ((MainWindow)App.Current.MainWindow).Main.Content = mod;
        }

        private void handleLookUpWord(object sender, RoutedEventArgs e)

        {
            Console.WriteLine("The link works!");
            // String word = GlobalData.Instance.lookUpTerms.at("marinade");
            string lookupDef = GlobalData.Instance.lookUpTerms[currentLookUpWord];
            termDef.Visibility = System.Windows.Visibility.Visible;
            _lookupDef.Text = lookupDef;
            mainGrid.IsEnabled = false;


        }

        private void StartTimer(object sender, RoutedEventArgs e)
        {
          


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.IsEnabled = true;
            termDef.Visibility= System.Windows.Visibility.Hidden;
        }
    }


}
