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
    /// Interaction logic for ModIngredients.xaml
    /// </summary>
    public partial class ModIngredients : Page
    {
        public ImageSource incfadeicon = (BitmapImage)Application.Current.Resources["incfadeIcon"];
        public ImageSource decfadeicon = (BitmapImage)Application.Current.Resources["decfadeIcon"];
        public ImageSource incicon = (BitmapImage)Application.Current.Resources["incIcon"];
        public ImageSource decicon = (BitmapImage)Application.Current.Resources["decIcon"];
        public Recipe _recipe;
        public int recipeNum;
        int ingNum;
        bool changeAddFlag; //falsefor change, true for add
        public ModIngredients(Recipe recipe, int _recipeNum)
        {
            InitializeComponent();
            //mainGrid.IsEnabled = true;
            _recipe = recipe;
            foodTitle.Text = _recipe._name;
            recipeNum = _recipeNum;
            for (int i = 0; i < _recipe._ingredients.Count; i++)
            {

                //MessageBox.Show(_recipe._ingredients[i]._name);
                /*
                ModUserControl ing = new ModUserControl(_recipe._ingredients[i]._name);
                ing.Change.Tag = i;    //This will be used to determine which user control is connected to which button
                ing.Delete.Tag = i;    //Same as above to use it for delete button
                //Instead of this...Use a user control...
                
                ing.IES.Text = (i + 1).ToString() + ") " + ing.IES.Text;
                ing.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                ing.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                Thickness margin = ing.Margin;
                margin.Top = 20;
                ing.Margin = margin;
                ing.Change.Click += Change_Click;
                ing.Delete.Click += Delete_Click;

                Ings.Children.Add(ing);
                */

            }
        }

        //-------------------------User control buttons--------------------------------
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.IsEnabled = false;
            changeAddFlag = false;
            //This is important... Used to determine which step it's on
            var _ingNum = sender as Button;
            ingNum = (int)_ingNum.Tag;        //This was set during initiation 
                                                  //MessageBox.Show(resp.ToString());

            //Functional stuff, make the popup, display the step that's going to be changed in the text box
            //And display which step it's on
            stepBox.Clear();
            modBox.IsEnabled = true;
            modBox.Visibility = System.Windows.Visibility.Visible;
            incBox.Text = (ingNum + 1).ToString();
            stepBox.Text = _recipe._ingredients[ingNum].ToString();

            //Depending on which step its on, disable up and down arrow
            if (ingNum + 1 == _recipe._ingredients.Count)
            {
                IncButton.IsEnabled = false;
                incrementBrush.ImageSource = incfadeicon;
                DecButton.IsEnabled = true;
                decrementBrush.ImageSource = decicon;
            }
            else if (ingNum + 1 == 1)
            {
                DecButton.IsEnabled = false;
                decrementBrush.ImageSource = decfadeicon;
                IncButton.IsEnabled = true;
                incrementBrush.ImageSource = incicon;
            }


        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var _ingNum = sender as Button;
            ingNum = (int)_ingNum.Tag;        //This was set during initiation 
            _recipe._ingredients.RemoveAt(ingNum);

            //Steps.Children.RemoveAt(stepNum);
            //Or i can update the page
            ModIngredients updatePage = new ModIngredients(_recipe, recipeNum);
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
            incBox.Text = ((_recipe._ingredients.Count) + 1).ToString();    //Always make increment box at the max
            stepBox.Text = "";
            IncButton.IsEnabled = false;
            incrementBrush.ImageSource = incfadeicon;
            if (_recipe._ingredients.Count == 0)
            {
                DecButton.IsEnabled = false;
                decrementBrush.ImageSource = decfadeicon;
            }

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
            if (!string.IsNullOrWhiteSpace(stepBox.Text))
            {
                //Exit the popup
                modBox.IsEnabled = false;
                this.modBox.Visibility = System.Windows.Visibility.Hidden;

                if (!changeAddFlag)  //When change flag is set
                {
                    //Change the step and place it accordingly
                    _recipe._ingredients.RemoveAt(ingNum);
                    //Steps.Children.RemoveAt(stepNum);
                    int x = 0;
                    if (Int32.TryParse(incBox.Text, out x))
                    {
                        x = Int32.Parse(incBox.Text) - 1;
                    }
                    //Need to instantiate an ingredient here
                    //_recipe._ingredients.Insert(x, stepBox.Text);

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
                    //_recipe._ingredients.Insert(x, stepBox.Text);

                }
                ModIngredients updatePage = new ModIngredients(_recipe, recipeNum);
                ((MainWindow)App.Current.MainWindow).Main.Content = updatePage;
                mainGrid.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("One does not simply put in an empty step!!!!!! You stupid Biiimbo");
            }

        }

        private void IncButton_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            //If the textbox is an integer...
            if (Int32.TryParse(incBox.Text, out x))
            {

                x = Int32.Parse(incBox.Text);
                //If x is not maximum step then you can't increase anymore.
                x++;
                incBox.Text = x.ToString();
                //When you are in change mode
                if (!changeAddFlag)
                {
                    if (x == _recipe._ingredients.Count)
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
                    if (x == _recipe._ingredients.Count + 1)
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
            if (_recipe._ingredients.Count == 0)
            {
                MessageBox.Show("Uh. You need at least one step stoopud human.");
            }
            else
            {
                //Determine where the recipe is...
                Mod doneUpdate = new Mod(_recipe, recipeNum);
                ((MainWindow)App.Current.MainWindow).Main.Content = doneUpdate;
            }
        }


    }
}
