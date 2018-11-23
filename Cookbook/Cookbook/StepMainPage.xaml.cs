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
    /// Interaction logic for StepPage.xaml
    /// </summary>

    public partial class StepPage : Page
    {
       
        public StepPage(Recipe recipe)
        {
            InitializeComponent();
            StepByStepPage step1 = new StepByStepPage(recipe, 0);
            stepsMain.NavigationService.Navigate(step1); // start cookbook at favourite page all the time
        }


        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
