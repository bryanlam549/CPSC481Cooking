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
using System.Windows.Shapes;

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : UserControl
	{

		private string categoryName;
		public Recipe.Categories category;


		public Category(string categoryName, Recipe.Categories category)
        {
            InitializeComponent();
			this.categoryName = categoryName;
			this.category = category;
			Button.Content = categoryName;

        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SearchPage1.setCategory(this);
		}

		public void setPressed()
		{
			Button.Background = new SolidColorBrush(Color.FromRgb(124, 47, 31));
		}

		public void setUnpressed()
		{
			Button.Background = new SolidColorBrush(Color.FromRgb(157, 56, 40));

		}
	}
}
