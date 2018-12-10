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
    /// Interaction logic for IngredientTag.xaml
    /// </summary>
    public partial class IngredientTag : UserControl
    {
		SearchPage1 page;

		public IngredientTag(String name, SearchPage1 page)
        {
            InitializeComponent();

			this.name.Text = name;
			this.page = page;
        }

		private void delete_Click(object sender, RoutedEventArgs e)
		{
			((Panel)this.Parent).Children.Remove(this);
			page.removeIngr(this);
		}
	}
}
