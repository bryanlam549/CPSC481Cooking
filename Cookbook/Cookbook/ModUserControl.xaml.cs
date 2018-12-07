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
    /// Interaction logic for ModUserControl.xaml
    /// </summary>
    public partial class ModUserControl : UserControl
    {
        public ModUserControl(string ies) //Ingredient, equipment, or step
        {
            InitializeComponent();
            IES.Text =ies;
        }

        public event RoutedEventHandler Click;
        private void Change_Click(object sender, RoutedEventArgs e)
        {

            //Something LIKE this IF you are in modSTEPS...This is ugly but whatever.
            /*
            ((((MainWindow)App.Current.MainWindow).Main.Content) as ModSteps).stepBox.Clear();
            //((((MainWindow)App.Current.MainWindow).Main.Content) as ModSteps).modBox.IsEnabled = true;
            ((((MainWindow)App.Current.MainWindow).Main.Content) as ModSteps).modBox.Visibility = System.Windows.Visibility.Visible;
            

            ((((MainWindow)App.Current.MainWindow).Main.Content) as ModSteps).stepBox.Text = IES.Text;
            */
            //MessageBox.Show()

            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }
    }
}
