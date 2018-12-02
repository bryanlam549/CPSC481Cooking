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
        public ModSteps(Recipe _recipe)
        {
            InitializeComponent();
            foodTitle.Text = _recipe._name;
            for(int i = 0; i < _recipe._steps.Count; i++)
            {
                //Instead of this...Use a user control...
                System.Windows.Controls.TextBlock newStep = new System.Windows.Controls.TextBlock();
                newStep.TextWrapping = System.Windows.TextWrapping.Wrap;
                newStep.FontSize = 18;
                newStep.Text = _recipe._steps[i];
                Steps.Children.Add(newStep);
            }
        }
        private void cookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
