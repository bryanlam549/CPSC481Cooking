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

using System.Diagnostics;

// loop over List<Ingredient> and generate an IngredientTab for every ingredient and initializing _ingredient 

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for IngredientTab.xaml
    /// </summary>
    public partial class IngredientTab : UserControl
    {

        public Ingredient _ingredient; // gets set by auto-generation, set this befofre IngredientTab()

        // cache global resources...
        private BitmapImage uncheckedImage = (BitmapImage)Application.Current.Resources["uncheckedIcon"];
        private BitmapImage checkedImage = (BitmapImage)Application.Current.Resources["checkedIcon"];

        public IngredientTab(Ingredient ingredient)
        {

            InitializeComponent();

            _ingredient = ingredient;



            // init the TEXT (for measurement) + UNITCHANGER (visible unit) + TEXT (name)
            // have the unit drop down control be sorted alphabetically, highlight the currently selected unit

            

            primaryText.Text = _ingredient._measurementStr;


            if (_ingredient._hasStandardUnit)
            {
                unitChanger.Text = _ingredient._unitStr;
                // fill in combobox contents...
                initUnitMenu();

                specialUnitText.Visibility = Visibility.Hidden;
            }
            else if (_ingredient._hasSpecialUnit)
            {
                specialUnitText.Text = _ingredient._unitStr;

                unitChanger.Visibility = Visibility.Hidden;
                unitChangerButton.Visibility = Visibility.Hidden;
            }
            else
            {
                specialUnitText.Visibility = Visibility.Hidden;
                unitChanger.Visibility = Visibility.Hidden;
                unitChangerButton.Visibility = Visibility.Hidden;
            }



            if (_ingredient._substitutions == null)
            {
                subChanger.Visibility = Visibility.Hidden;
                subChangerButton.Visibility = Visibility.Hidden;
                secondaryText.Text = _ingredient._mainText;
            }
            else if (_ingredient._substitutions.Count > 0)
            {
                secondaryText.Visibility = Visibility.Hidden;
                subChanger.Text = _ingredient._mainText;
                initSubMenu();
            }
            else // no substitutions...
            {
                subChanger.Visibility = Visibility.Hidden;
                subChangerButton.Visibility = Visibility.Hidden;
                secondaryText.Text = _ingredient._mainText;
            }


        }


        public void initUnitMenu()
        {
            if (_ingredient._unitType == Ingredient.UnitType.VOLUME) // volume
            {
                unitChanger.Items.Add(Ingredient.CUPS);
                unitChanger.Items.Add(Ingredient.FLOZ);
                unitChanger.Items.Add(Ingredient.ML);
                unitChanger.Items.Add(Ingredient.L);
                unitChanger.Items.Add(Ingredient.TBSP);
                unitChanger.Items.Add(Ingredient.TSP);
            }
            else if (_ingredient._unitType == Ingredient.UnitType.MASS) // mass
            {
                unitChanger.Items.Add(Ingredient.G);
                unitChanger.Items.Add(Ingredient.KG);
                unitChanger.Items.Add(Ingredient.LBS);
                unitChanger.Items.Add(Ingredient.MG);
                unitChanger.Items.Add(Ingredient.OZ);
            }
            else if (_ingredient._unitType == Ingredient.UnitType.LENGTH)// length
            {
                unitChanger.Items.Add(Ingredient.CM);
                unitChanger.Items.Add(Ingredient.IN);
                unitChanger.Items.Add(Ingredient.M);
                unitChanger.Items.Add(Ingredient.MM);
            }
        }


        public void initSubMenu()
        {
            foreach(string sub in _ingredient._substitutions)
            {
                subChanger.Items.Add(sub);
            }
        }





        private void Checkbox_Click(object sender, RoutedEventArgs e)
        {
            _ingredient._isChecked = !_ingredient._isChecked;
            if (_ingredient._isChecked)
            {
                checkboxImageBrush.ImageSource = checkedImage;
            }
            else
            {
                checkboxImageBrush.ImageSource = uncheckedImage;
            }
        }

        private void unitChangerButton_Click(object sender, RoutedEventArgs e)
        {
            unitChanger.IsDropDownOpen = !unitChanger.IsDropDownOpen;
        }


        

        private void subChangerButton_Click(object sender, RoutedEventArgs e)
        {
            subChanger.IsDropDownOpen = !subChanger.IsDropDownOpen;
        }



        private void unitChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string oldUnitStr = _ingredient._unitStr;
            //string newUnitStr = unitChanger.SelectedValue.ToString(); // THIS IS NULL WITH STRINGS
            string newUnitStr = unitChanger.SelectedItem.ToString(); // THANK YOU

            //Debug.WriteLine(oldUnitStr);
            //Debug.WriteLine("=-=-=-=-=-=");
            //Debug.WriteLine(newUnitStr);

            if (oldUnitStr == newUnitStr)
            {
                return;
            }
            // ONLY call update if oldUnitStr != newUnitStr
            // now update the measurement value
            _ingredient.convertMeasurement(newUnitStr);
            // then convert this value to str
            // get this string and set the primary string to this (which is fine since no secondary string will exist)
            //_ingredient._unitStr = newUnitStr;

            primaryText.Text = _ingredient._measurementStr;
            //Debug.WriteLine(primaryText.Text);
            
        }

        private void subChanger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _ingredient._mainText = subChanger.SelectedItem.ToString();
        }
    }
}
