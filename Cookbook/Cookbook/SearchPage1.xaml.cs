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
    /// Interaction logic for SearchPage1.xaml
    /// </summary>
    public partial class SearchPage1 : Page
    {
		private static string onCategory = "All Categories";

        public SearchPage1()
        {
            InitializeComponent();

			// Creating the list of categories
			var categories = new StackPanel()
			{
				Orientation = Orientation.Horizontal,

				Children = {
					new Category("All\nCategories"),
					new Category("Pastries"),
					new Category("Seafood"),
					new Category("Pastas"),
					new Category("Burgers"),
					new Category("Pizza"),
					new Category("Desserts"),
				}
			};

			scroll1.Content = categories;
			
		}

		

		public static void setCategory(string toSet){
			onCategory = toSet;
			test.Content = toSet;
		}
		
	}
}
