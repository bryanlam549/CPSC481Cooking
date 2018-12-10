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
            //_backButton.transitionPageButton.Click += BackButton_Click;
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

            //Functional stuff make pop up display right info
            //And display which step it's on
            if (_recipe._ingredients[ingNum]._unitType.ToString() == "VOLUME")
                measurementChanger.SelectedItem = "VOL.";
            else if (_recipe._ingredients[ingNum]._unitType.ToString() == "MASS")
                measurementChanger.SelectedItem = "MASS";
            else if (_recipe._ingredients[ingNum]._unitType.ToString() == "LENGTH")
                measurementChanger.SelectedItem = "LEN.";
            else if (_recipe._ingredients[ingNum]._unitType.ToString() == "SPECIAL")
                measurementChanger.SelectedItem = "SPEC.";
            else if (_recipe._ingredients[ingNum]._unitType.ToString() == "NONE")
                measurementChanger.SelectedItem = "NONE";
            if (_recipe._ingredients[ingNum]._unitType.ToString() == "NONE")
            {
                unitChanger.Items.Clear();
                unitChanger.Text = "N/A";
                unitChanger.IsEnabled = false;
            }
            else
            {
                unitChanger.IsEnabled = true;
                unitChanger.SelectedItem = _recipe._ingredients[ingNum]._unitStr;
            }

            AmountBox.Clear();
            modBox.IsEnabled = true;
            modBox.Visibility = System.Windows.Visibility.Visible;
            AmountBox.Text = (_recipe._ingredients[ingNum]._measurement).ToString("###, #.##");


            ingBox.Text = _recipe._ingredients[ingNum]._mainText.ToString();


        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var _ingNum = sender as Button;
            ingNum = (int)_ingNum.Tag;        //This was set during initiation 
            confirmBox.Visibility = System.Windows.Visibility.Visible;
            confirmStepText.Text = (ingNum + 1).ToString() + ".) " + _recipe._ingredients[ingNum]._mainText;
            mainGrid.IsEnabled = false;
        }
        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            confirmBox.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
        }
        private void yesButton_Click(object sender, RoutedEventArgs e)
        {

            _recipe._ingredients.RemoveAt(ingNum);
            //Steps.Children.RemoveAt(stepNum);
            //Or i can update the page
            ModIngredients updatePage = new ModIngredients(_recipe, ingNum);
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
            ingBox.Clear();
            AmountBox.Clear();

            //measurementChanger.SelectedItem = null;
            measurementChanger.Text = "MEAS.";
            unitChanger.Text = "UNIT";

            modBox.IsEnabled = true;
            modBox.Visibility = System.Windows.Visibility.Visible;
            AmountBox.Text = "";
            ingBox.Text = "";
                       
        }
        //Back button
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            unsavedPopup.Visibility = System.Windows.Visibility.Visible;
            mainGrid.IsEnabled = false;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            modBox.IsEnabled = false;
            this.modBox.Visibility = System.Windows.Visibility.Hidden;
            mainGrid.IsEnabled = true;
            InvalidInput.Visibility = System.Windows.Visibility.Hidden;
            InvalidInput2.Visibility = System.Windows.Visibility.Hidden;
            InvalidInput3.Visibility = System.Windows.Visibility.Hidden;
        }
        //Incomplete
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //Parse the amount box
            double d = -1;
            bool frac;
            string[] amount = AmountBox.Text.Split('/');
            for (int i = 0; i < amount.Length; i++)
            {
                amount[i].Trim();
            }
            if (amount.Length == 2 && Double.TryParse(amount[0].ToString(), out d) && Double.TryParse(amount[1].ToString(), out d))
            {
                frac = true;
            }
            else
            {
                frac = false;
            }

            //Only do this when both are empty
            if (!string.IsNullOrWhiteSpace(ingBox.Text) && !string.IsNullOrWhiteSpace(AmountBox.Text) && measurementChanger.SelectedItem != null
            && (unitChanger.SelectedItem != null || measurementChanger.SelectedItem.ToString() == "NONE")
            && (Double.TryParse(AmountBox.Text.ToString(), out d)) || frac == true)
            {
                //Exit the popup
                modBox.IsEnabled = false;
                this.modBox.Visibility = System.Windows.Visibility.Hidden;

                //When you are changing an item
                if (!changeAddFlag)
                {
                    if (frac == true)
                    {
                        //It's a fraction
                        int num = Convert.ToInt32(amount[0]);
                        int den = Convert.ToInt32(amount[1]);
                        _recipe._ingredients[ingNum]._measurement = (double)num / (double)den;
                    }
                    else
                    {
                        //Double.TryParse(AmountBox.Text.ToString(), out d);
                        _recipe._ingredients[ingNum]._measurement = d;
                    }

                    //_recipe._ingredients[ingNum]._measurement = d;//Convert.ToDouble(AmountBox.Text.ToString());


                    //Changer measurement number
                    //_recipe._ingredients[ingNum]._measurement = Convert.ToInt32(AmountBox.Text);
                    if (measurementChanger.SelectedItem.ToString() == "VOL.") // volume
                    {
                        _recipe._ingredients[ingNum]._unitType = Ingredient.UnitType.VOLUME;
                        _recipe._ingredients[ingNum]._hasStandardUnit = true;
                        _recipe._ingredients[ingNum]._hasSpecialUnit = false;

                    }
                    else if (measurementChanger.SelectedItem.ToString() == "MASS") // mass
                    {
                        _recipe._ingredients[ingNum]._unitType = Ingredient.UnitType.MASS;
                        _recipe._ingredients[ingNum]._hasStandardUnit = true;
                        _recipe._ingredients[ingNum]._hasSpecialUnit = false;


                    }
                    else if (measurementChanger.SelectedItem.ToString() == "LEN.")// length
                    {
                        _recipe._ingredients[ingNum]._unitType = Ingredient.UnitType.LENGTH;
                        _recipe._ingredients[ingNum]._hasStandardUnit = true;
                        _recipe._ingredients[ingNum]._hasSpecialUnit = false;


                    }
                    else if (measurementChanger.SelectedItem.ToString() == "SPEC.")
                    {
                        _recipe._ingredients[ingNum]._unitType = Ingredient.UnitType.SPECIAL;
                        _recipe._ingredients[ingNum]._hasStandardUnit = false;
                        _recipe._ingredients[ingNum]._hasSpecialUnit = true;

                    }
                    else
                    {
                        _recipe._ingredients[ingNum]._unitType = Ingredient.UnitType.NONE;
                        _recipe._ingredients[ingNum]._hasStandardUnit = false;
                        _recipe._ingredients[ingNum]._hasSpecialUnit = false;


                    }

                    if (measurementChanger.SelectedItem.ToString() == "NONE")
                    {
                        _recipe._ingredients[ingNum]._unitStr = "";
                        _recipe._ingredients[ingNum]._measurementStr = AmountBox.Text;
                    }

                    else
                    {
                        _recipe._ingredients[ingNum]._unitStr = unitChanger.SelectedItem.ToString();
                        _recipe._ingredients[ingNum].convertMeasurement(unitChanger.SelectedItem.ToString());
                    }

                    _recipe._ingredients[ingNum]._mainText = ingBox.Text;

                    //measurement str



                }
                else //Don't delete, just add
                {
                    //Instantiate more stuff tha this
                    //You want to change ingredient name, amount, measurement type and units
                    //List<string> _substitutions = new List<string> { };
                    //Ingredient newIng = new Ingredient(0, "0", Ingredient.UnitType.NONE,"", "", _substitutions);
                    //need to be able to write fractions too right?
                    //newIng._measurement = Convert.ToDouble(AmountBox.Text.ToString());

                    Ingredient newIng;

                    double measurement;
                    string measurementStr;
                    Ingredient.UnitType unitType;
                    string unitStr;
                    string mainText;
                    List<string> substitutions = new List<string> { };

                    if (frac == true)
                    {
                        //It's a fraction
                        int num = Convert.ToInt32(amount[0]);
                        int den = Convert.ToInt32(amount[1]);
                        measurement = (double)num / (double)den;
                        measurementStr = num.ToString() + "/" + den.ToString();
                    }
                    else
                    {
                        //Double.TryParse(AmountBox.Text.ToString(), out d);
                        measurement = d;
                        measurementStr = measurement.ToString();
                    }
                    //TODO: measurement str
                    if (measurementChanger.SelectedItem.ToString() == "VOL.") // volume
                    {
                        unitType = Ingredient.UnitType.VOLUME;
                    }
                    else if (measurementChanger.SelectedItem.ToString() == "MASS") // mass
                    {
                        unitType = Ingredient.UnitType.MASS;
                    }
                    else if (measurementChanger.SelectedItem.ToString() == "LEN.")// length
                    {
                        unitType = Ingredient.UnitType.LENGTH;
                    }
                    else if (measurementChanger.SelectedItem.ToString() == "SPEC.")
                    {
                        unitType = Ingredient.UnitType.SPECIAL;
                    }
                    else
                    {
                        unitType = Ingredient.UnitType.NONE;
                    }

                    mainText = ingBox.Text;



                    if (measurementChanger.SelectedItem.ToString() == "NONE")
                    {
                        unitStr = "";
                        measurementStr = AmountBox.Text;
                        newIng = new Ingredient(measurement, measurementStr, unitType, unitStr, mainText, substitutions);
                    }
                    else
                    {
                        unitStr = unitChanger.SelectedItem.ToString();
                        newIng = new Ingredient(measurement, measurementStr, unitType, unitStr, mainText, substitutions);
                        newIng.convertMeasurement(unitChanger.SelectedItem.ToString());
                    }

                    _recipe._ingredients.Add(newIng);

                    //measurement str
                    //_recipe._ingredients[ingNum].convertMeasurement(unitChanger.SelectedItem.ToString());
                }
                ModIngredients updatePage = new ModIngredients(_recipe, recipeNum);
                ((MainWindow)App.Current.MainWindow).Main.Content = updatePage;
                mainGrid.IsEnabled = true;
                InvalidInput.Visibility = System.Windows.Visibility.Hidden;
                InvalidInput2.Visibility = System.Windows.Visibility.Hidden;
                InvalidInput3.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(ingBox.Text))
                {
                    InvalidInput.Visibility = System.Windows.Visibility.Visible;
                }
                if (string.IsNullOrWhiteSpace(AmountBox.Text) || measurementChanger.SelectedItem != null
            || (unitChanger.SelectedItem != null || measurementChanger.SelectedItem.ToString() == "NONE"))
                {
                    InvalidInput2.Visibility = System.Windows.Visibility.Visible;
                    InvalidInput3.Visibility = System.Windows.Visibility.Visible;
                }
                //MessageBox.Show("Ingredient name/Amount is empty OR meas/unit is not selected OR amount not in decimals");
            }

        }
        private void doneButton_Click(object sender, RoutedEventArgs e)
        {
            if (_recipe._ingredients.Count == 0)
            {
                //MessageBox.Show("Uh. You need at least one step stoopud human.");
                InvalidInputDone.Visibility = System.Windows.Visibility.Visible;
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
            measurementChanger.Items.Add("SPEC.");
            measurementChanger.Items.Add("NONE");
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
            if (measurementChanger.SelectedItem == null)
            {
                unitChanger.IsEnabled = false;
            }
            else
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
                else if (measurementChanger.SelectedItem.ToString() == "SPEC.") //Special
                {
                    unitChanger.Items.Clear();
                    unitChanger.Text = "UNIT";
                    unitChanger.Items.Add("cloves");
                    unitChanger.Items.Add("filet");
                    unitChanger.Items.Add("head");
                    unitChanger.IsEnabled = true;

                }
                else if (measurementChanger.SelectedItem.ToString() == "NONE") //Special
                {
                    unitChanger.Items.Clear();
                    unitChanger.Text = "N/A";
                    unitChanger.IsEnabled = false;
                }
                else
                {
                    unitChanger.IsEnabled = false;
                }
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
