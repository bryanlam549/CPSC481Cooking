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
                ModUserControl ing;
                if (_recipe._ingredients[i]._unitStr != "NO UNIT")
                {
                    ing = new ModUserControl(_recipe._ingredients[i]._measurementStr + " " + _recipe._ingredients[i]._unitStr
                        + " " + _recipe._ingredients[i]._mainText);
                }
                else
                {
                    ing = new ModUserControl(_recipe._ingredients[i]._measurementStr 
                        + " " + _recipe._ingredients[i]._mainText);
                }

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
            }
            initUnitMenu();
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
            AmountBox.Clear();
            modBox.IsEnabled = true;
            modBox.Visibility = System.Windows.Visibility.Visible;
            AmountBox.Text = (_recipe._ingredients[ingNum]._measurementStr).ToString();
            ingBox.Text = _recipe._ingredients[ingNum]._mainText.ToString();

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
            ingBox.Clear();
            AmountBox.Clear();
            modBox.IsEnabled = true;
            modBox.Visibility = System.Windows.Visibility.Visible;
            AmountBox.Text = "";
            ingBox.Text = "";
                       
        }
        //Back button
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
        //Incomplete
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //Only do this when both are empty
            if (!string.IsNullOrWhiteSpace(ingBox.Text) && !string.IsNullOrWhiteSpace(AmountBox.Text))
            {
                //Exit the popup
                modBox.IsEnabled = false;
                this.modBox.Visibility = System.Windows.Visibility.Hidden;

                if (!changeAddFlag)  //When change flag is set
                {
                    /*public double _measurement; // e.g. 1.5
                    public string _measurementStr; // e.g. 1/2
                    public UnitType _unitType;
                    public string _unitStr; // starting unit text can be hardcoded (this is text that goes in combobox at start or in specialtext)
                    public string _mainText;
                    // -==-=-=-=-=-=-=-=
                    public bool _isChecked = false;
                    public bool _hasStandardUnit = false; // if true, then the unitChanger will be visible...
                    public bool _hasSpecialUnit = false; // if true then the specialText will be visible...
                    */         //_recipe._ingredients[ingNum]._measurement = Convert.ToInt32(AmountBox.Text);

                    /*ing = new ModUserControl(_recipe._ingredients[i]._measurementStr + " " + _recipe._ingredients[i]._unitStr
                        + " " + _recipe._ingredients[i]._mainText);*/

                    //measurementChanger.SelectedItem.ToString()
                    //You want to change ingredient name, amount, measurement type and units

                    //_recipe._ingredients[ingNum]._measurement = Convert.ToInt32(AmountBox.Text);
                    //_recipe._ingredients[ingNum].convertMeasurement(AmountBox.Text);

                    //Change measurement
                    _recipe._ingredients[ingNum]._measurement = Convert.ToInt32(AmountBox.Text);
                    if (measurementChanger.SelectedItem.ToString() == "VOL.") // volume
                    {
                        _recipe._ingredients[ingNum]._unitType = Ingredient.UnitType.VOLUME;
                    }
                    else if (measurementChanger.SelectedItem.ToString() == "MASS") // mass
                    {
                        _recipe._ingredients[ingNum]._unitType = Ingredient.UnitType.MASS;
                    }
                    else if (measurementChanger.SelectedItem.ToString() == "LEN.")// length
                    {
                        _recipe._ingredients[ingNum]._unitType = Ingredient.UnitType.LENGTH;
                    }
                    else
                    {

                    }
                    //_recipe._ingredients[ingNum]._measurementStr = _recipe._ingredients[ingNum].convertMeasurement();
                    _recipe._ingredients[ingNum].convertMeasurement(unitChanger.SelectedItem.ToString());


                    //_recipe._ingredients[ingNum]._unitType = 
                    //_recipe._ingredients[ingNum]._measurementStr = AmountBox.Text;
                    //Change uit

                    _recipe._ingredients[ingNum]._unitStr = ingBox.Text;

                     //change name
                    _recipe._ingredients[ingNum]._mainText = ingBox.Text;
                    //Probably actually want to change the actual data too

                }
                else //Don't delete, just add
                {
                    //Instantiate more stuff tha this
                    //You want to change ingredient name, amount, measurement type and units
                    Ingredient newIng = new Ingredient();
                    newIng._mainText = ingBox.Text;
                    newIng._measurementStr = AmountBox.Text;
                    //newIng._unitStr = ingBox.Text;
                    _recipe._ingredients.Add(newIng);
                }
                ModIngredients updatePage = new ModIngredients(_recipe, recipeNum);
                ((MainWindow)App.Current.MainWindow).Main.Content = updatePage;
                mainGrid.IsEnabled = true;

                    }
                else
                {
                    MessageBox.Show("Cannot leave ingredient name/amount box empty");
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



        //DROP DOWN STUFF
        public void initUnitMenu()
        {
            measurementChanger.Items.Add("VOL.");
            measurementChanger.Items.Add("MASS");
            measurementChanger.Items.Add("LEN.");
            unitChanger.IsEnabled = false;
        }

        private void unitChangerButton_Click(object sender, RoutedEventArgs e)
        {
            if(unitChanger.IsEnabled)
                unitChanger.IsDropDownOpen = !unitChanger.IsDropDownOpen;
        }

        private void measChangerButton_Click(object sender, RoutedEventArgs e)
        {
            measurementChanger.IsDropDownOpen = !measurementChanger.IsDropDownOpen;
        }

        private void unitChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Nothing here i guess
        }
        private void measChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (measurementChanger.SelectedItem.ToString() == "VOL.") // volume
            {
                unitChanger.Items.Clear();
                unitChanger.Text = "UNIT";
                unitChanger.Items.Add(Ingredient.CUPS);
                unitChanger.Items.Add(Ingredient.FLOZ);
                unitChanger.Items.Add(Ingredient.ML);
                unitChanger.Items.Add(Ingredient.L);
                unitChanger.Items.Add(Ingredient.TBSP);
                unitChanger.Items.Add(Ingredient.TSP);
                unitChanger.IsEnabled = true;
            }
            else if (measurementChanger.SelectedItem.ToString() == "MASS") // mass
            {
                unitChanger.Items.Clear();
                unitChanger.Text = "UNIT";
                unitChanger.Items.Add(Ingredient.G);
                unitChanger.Items.Add(Ingredient.KG);
                unitChanger.Items.Add(Ingredient.LBS);
                unitChanger.Items.Add(Ingredient.MG);
                unitChanger.Items.Add(Ingredient.OZ);
                unitChanger.IsEnabled = true;
            }
            else if (measurementChanger.SelectedItem.ToString() == "LEN.")// length
            {
                unitChanger.Items.Clear();
                unitChanger.Text = "UNIT";
                unitChanger.Items.Add(Ingredient.CM);
                unitChanger.Items.Add(Ingredient.IN);
                unitChanger.Items.Add(Ingredient.M);
                unitChanger.Items.Add(Ingredient.MM);
                unitChanger.IsEnabled = true;
            }
            else
            {
                unitChanger.IsEnabled = false;
            }
        }
    }
}
