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
    /// Interaction logic for ModSteps.xaml
    /// </summary>
    public partial class ModSteps : Page
    {
        public ImageSource incfadeicon =  (BitmapImage) Application.Current.Resources["servingplusIcon"];
        public ImageSource decfadeicon =  (BitmapImage)Application.Current.Resources["servingminusIcon"];
        public ImageSource incicon = (BitmapImage)Application.Current.Resources["servingplusIcon"];
        public ImageSource decicon = (BitmapImage)Application.Current.Resources["servingminusIcon"];
        public Recipe _recipe;
        public Recipe _copy;
        public int recipeNum;
        int stepNum;
        bool changeAddFlag; //falsefor change, true for add
        public ModSteps(Recipe recipe, int _recipeNum)
        {
            InitializeComponent();
            //mainGrid.IsEnabled = true;
            _recipe = recipe;
            //_copy = GlobalData.Instance.copy(recipe);
            _copy = new Recipe(recipe);
            foodTitle.Text = _recipe._name;
            recipeNum = _recipeNum;
            for(int i = 0; i < _recipe._steps.Count; i++)
            {

                ModUserControl step = new ModUserControl(_recipe._steps[i]);
                step.Change.Tag = i;    //This will be used to determine which user control is connected to which button
                step.Delete.Tag = i;    //Same as above to use it for delete button
                //Instead of this...Use a user control...
                /*
                System.Windows.Controls.TextBlock newStep = new System.Windows.Controls.TextBlock();
                newStep.TextWrapping = System.Windows.TextWrapping.Wrap;
                newStep.FontSize = 18;
                newStep.Text = _recipe._steps[i];*/
                step.IES.Text = (i+1).ToString() + ") " + step.IES.Text;
                step.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                step.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                Thickness margin = step.Margin;
                margin.Top = 20;
                step.Margin = margin;
                step.Change.Click += Change_Click;
                step.Delete.Click += Delete_Click;
                
                Steps.Children.Add(step);
                
                
            }
        }

        //-------------------------User control buttons--------------------------------
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.IsEnabled = false;
            changeAddFlag = false;
            //This is important... Used to determine which step it's on
            var _stepNum = sender as Button;
            stepNum = (int)_stepNum.Tag;        //This was set during initiation 
            //MessageBox.Show(resp.ToString());
            
            //Functional stuff, make the popup, display the step that's going to be changed in the text box
            //And display which step it's on
            stepBox.Clear();
            modBox.IsEnabled = true;
            modBox.Visibility = System.Windows.Visibility.Visible;
            incBox.Text = (stepNum+1).ToString();
            stepBox.Text = _recipe._steps[stepNum];

            //Depending on which step its on, disable up and down arrow
            if (stepNum + 1 == _recipe._steps.Count && stepNum + 1 == 1)
            {
                IncButton.IsEnabled = false;
                incrementBrush.ImageSource = incfadeicon;
                DecButton.IsEnabled = false;
                decrementBrush.ImageSource = decfadeicon;
            }
            else if (stepNum+1 == _recipe._steps.Count)
            {
                IncButton.IsEnabled = false;
                incrementBrush.ImageSource = incfadeicon;
                DecButton.IsEnabled = true;
                decrementBrush.ImageSource = decicon;
            }
            else if(stepNum+1 == 1)
            {
                DecButton.IsEnabled = false;
                decrementBrush.ImageSource = decfadeicon;
                IncButton.IsEnabled = true;
                incrementBrush.ImageSource = incicon;
            }

            
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var _stepNum = sender as Button;
            stepNum = (int)_stepNum.Tag;        //This was set during initiation
            confirmBox.Visibility = System.Windows.Visibility.Visible;
            confirmStepText.Text = (stepNum+1).ToString() + ".) " + _recipe._steps[stepNum];
            mainGrid.IsEnabled = false;

           
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            confirmBox.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
        }
        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
              
            _recipe._steps.RemoveAt(stepNum);

            // need to delete corresponding time for step
            _recipe._timerValuesForSteps.RemoveAt(stepNum);

            //Steps.Children.RemoveAt(stepNum);
            //Or i can update the page
            ModSteps updatePage = new ModSteps(_recipe, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = updatePage;
            mainGrid.IsEnabled = true;

            //GlobalData.Instance.modRecipeList.Add(_recipe);
        }
        //----------------------------------------This pages buttons -----------------------------------------
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.IsEnabled = false;
            changeAddFlag = true;
            //Functional stuff, make the popup, display the step that's going to be changed in the text box
            //And display which step it's on
            stepBox.Clear();
            modBox.IsEnabled = true;
            modBox.Visibility = System.Windows.Visibility.Visible;
            incBox.Text = ((_recipe._steps.Count) + 1).ToString();    //Always make increment box at the max
            stepBox.Text= "";
            IncButton.IsEnabled = false;
            incrementBrush.ImageSource = incfadeicon;
            if(_recipe._steps.Count == 0)
            {
                DecButton.IsEnabled = false;
                decrementBrush.ImageSource = decfadeicon;
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.GoBack();
            unsavedPopup.Visibility = System.Windows.Visibility.Visible;
            mainGrid.IsEnabled = false;
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            modBox.IsEnabled = false;
            this.modBox.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
            InvalidInput.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(stepBox.Text))
            {
                //Exit the popup
                modBox.IsEnabled = false;
                this.modBox.Visibility = System.Windows.Visibility.Hidden;

                if (!changeAddFlag)  //When change flag is set
                {
                    //Change the step and place it accordingly
                    _recipe._steps.RemoveAt(stepNum);
                    //Steps.Children.RemoveAt(stepNum);
                    int x = 0;
                    if (Int32.TryParse(incBox.Text, out x))
                    {
                        x = Int32.Parse(incBox.Text) - 1;
                    }
                    _recipe._steps.Insert(x, stepBox.Text);

                    //Make the new step and add it in
                    //ModUserControl changedStep = new ModUserControl(stepBox.Text);
                    /*
                    changedStep.Change.Tag = x;    //This will be used to determine which user control is connected to which button
                    changedStep.Delete.Tag = x;    //Same as above to use it for delete button
                    changedStep.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                    changedStep.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    changedStep.Change.Click += Change_Click;
                    changedStep.Delete.Click += Delete_Click;
                    Steps.Children.Insert(x, changedStep);
                    */
                    //OR i can just update the page

                }
                else
                {
                    int x = 0;
                    if (Int32.TryParse(incBox.Text, out x))
                    {
                        x = Int32.Parse(incBox.Text) - 1;
                    }
                    _recipe._steps.Insert(x, stepBox.Text);

                }
                ModSteps updatePage = new ModSteps(_recipe, recipeNum);
                ((MainWindow)App.Current.MainWindow).Main.Content = updatePage;
                mainGrid.IsEnabled = true;
                InvalidInput.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                InvalidInput.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void IncButton_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            //If the textbox is an integer...
            if(Int32.TryParse(incBox.Text, out x))
            {
                
                x = Int32.Parse(incBox.Text);
                //If x is not maximum step then you can't increase anymore.
                x++;
                incBox.Text = x.ToString();
                //When you are in change mode
                if (!changeAddFlag)
                {
                    if (x == _recipe._steps.Count)
                    {
                        IncButton.IsEnabled = false;
                        incrementBrush.ImageSource = incfadeicon;
                        DecButton.IsEnabled = true;
                        decrementBrush.ImageSource = decicon;
                    }
                    else
                    {
                        DecButton.IsEnabled = true;
                        decrementBrush.ImageSource = decicon;
                    }
                }
                //When you are in add mode
                else
                {
                    if (x == _recipe._steps.Count + 1)
                    {
                        IncButton.IsEnabled = false;
                        incrementBrush.ImageSource = incfadeicon;
                        DecButton.IsEnabled = true;
                        decrementBrush.ImageSource = decicon;
                    }
                    else
                    {
                        DecButton.IsEnabled = true;
                        incrementBrush.ImageSource = incicon;
                    }
                }
            }
        }

        private void DecButton_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            //If the textbox is an integer...
            if (Int32.TryParse(incBox.Text, out x))
            {

                x = Int32.Parse(incBox.Text);
                //If x is not maximum step then you can't increase anymore.
                x--;
                incBox.Text = x.ToString();
                if (x == 1)
                {
                    DecButton.IsEnabled = false;
                    decrementBrush.ImageSource = decfadeicon;
                    IncButton.IsEnabled = true;
                    incrementBrush.ImageSource = incicon;
                }
                else
                {
                    IncButton.IsEnabled = true;
                    incrementBrush.ImageSource = incicon;
                }

            }
        }

        private void doneButton_Click(object sender, RoutedEventArgs e)
        {
            if (_recipe._steps.Count == 0)
            {
                InvalidInputDone.Visibility = System.Windows.Visibility.Visible;
                //MessageBox.Show("Uh. You need at least one step stoopud human.");
            }
            else
            {
                //Determine where the recipe is...
                Mod doneUpdate = new Mod(_recipe, recipeNum);
                ((MainWindow)App.Current.MainWindow).Main.Content = doneUpdate;
            }
        }

        private void unsavedYesButton_Click(object sender, RoutedEventArgs e)
        {
            
            unsavedPopup.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
            Mod modGoBack = new Mod(GlobalData.Instance.currentlyModifying, recipeNum);
            this.NavigationService.Navigate(modGoBack);
        }

        private void unsaved_noButton_Click(object sender, RoutedEventArgs e)
        {
            unsavedPopup.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
        }
    }
}
