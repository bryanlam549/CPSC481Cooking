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
        Recipe _currentRecipe;
        int _currentStep; 
        public StepByStepPage( Recipe recipe,int currentStep)
        {
            InitializeComponent();
            _currentRecipe = recipe;
            _currentStep = currentStep;
        }
        private void Next_Step_Click(object sender, RoutedEventArgs e)
        {
            StepByStepPage nextStep = new StepByStepPage(_currentRecipe, _currentStep + 1);
            this.NavigationService.Navigate(nextStep);
        }

        private void Prev_Step_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }


}
