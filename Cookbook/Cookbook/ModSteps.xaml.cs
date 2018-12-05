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
        public Recipe _recipe;
        public int recipeNum;
        int stepNum;
        bool changeAddFlag; //falsefor change, true for add
        public ModSteps(Recipe recipe, int _recipeNum)
        {
            InitializeComponent();
            //mainGrid.IsEnabled = true;
            _recipe = recipe;
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
            if (stepNum+1 == _recipe._steps.Count)
            {
                IncButton.IsEnabled = false;
                DecButton.IsEnabled = true;
            }
            else if(stepNum+1 == 1)
            {
                DecButton.IsEnabled = false;
                IncButton.IsEnabled = true;
            }

            
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var _stepNum = sender as Button;
            stepNum = (int)_stepNum.Tag;        //This was set during initiation 
            _recipe._steps.RemoveAt(stepNum);

            //Steps.Children.RemoveAt(stepNum);
            //Or i can update the page
            ModSteps updatePage = new ModSteps(_recipe, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = updatePage;

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

        }

        private void cookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            modBox.IsEnabled = false;
            this.modBox.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
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
                        DecButton.IsEnabled = true;
                    }
                    else
                    {
                        DecButton.IsEnabled = true;
                    }
                }
                //When you are in add mode
                else
                {
                    if (x == _recipe._steps.Count + 1)
                    {
                        IncButton.IsEnabled = false;
                        DecButton.IsEnabled = true;
                    }
                    else
                    {
                        DecButton.IsEnabled = true;
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
                    IncButton.IsEnabled = true;
                }
                else
                {
                    IncButton.IsEnabled = true;
                }

            }
        }

        private void doneButton_Click(object sender, RoutedEventArgs e)
        {
            //Determine where the recipe is...
            Mod doneUpdate = new Mod(_recipe, recipeNum);
            ((MainWindow)App.Current.MainWindow).Main.Content = doneUpdate;
        }

        
    }
}
