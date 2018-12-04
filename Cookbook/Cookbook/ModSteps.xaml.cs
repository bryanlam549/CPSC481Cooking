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
        //int stepNum;
        public ModSteps(Recipe recipe)
        {
            InitializeComponent();
            _recipe = recipe;
            foodTitle.Text = _recipe._name;
            
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
            
            //This is important... Used to determine which step it's on
            var _stepNum = sender as Button;
            int  stepNum = (int)_stepNum.Tag;        //This was set during initiation 
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
            //This is important... Used to determine which step to delete
            
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var _stepNum = sender as Button;
            int stepNum = (int)_stepNum.Tag;        //This was set during initiation 
            _recipe._steps.RemoveAt(stepNum);
            ModSteps updatePage = new ModSteps(_recipe);
            ((MainWindow)App.Current.MainWindow).Main.Content = updatePage;
        }


        //----------------------------------------This pages buttons -----------------------------------------
        private void cookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            modBox.IsEnabled = false;
            this.modBox.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            modBox.IsEnabled = false;
            this.modBox.Visibility = System.Windows.Visibility.Hidden;
            //_recipe._steps[stepNum] = stepBox.Text;
            //GlobalData.Instance.modRecipeList.Add(_recipe);
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
    }
}
