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
        public SearchPage1()
        {
            InitializeComponent();
			GlobalData.Instance.selectedCategory.setPressed();

			// Creating the list of categories
			var categories = new StackPanel()
			{
				Orientation = Orientation.Horizontal,

				Children = {
					GlobalData.Instance.allCat,
					GlobalData.Instance.beefCat,
					GlobalData.Instance.chickCat,
					GlobalData.Instance.pastaCat,
					GlobalData.Instance.fishCat,
					GlobalData.Instance.chineseCat,
					GlobalData.Instance.vegCat,
				}
			};

			scroll1.Content = categories;
			
		}

		public static void setCategory(Category newSelected){
			GlobalData.Instance.selectedCategory.setUnpressed();
			GlobalData.Instance.selectedCategory = newSelected;
		}

		
		private void Search_Click(object sender, RoutedEventArgs e)
		{
			// Get results from recipes
			List<Recipe> recipes = GlobalData.Instance.recipeList;
			// TODO filter recipes

			// Display recipes resulting from search
			SearchPageResults results = new SearchPageResults(recipes);
			this.NavigationService.Navigate(results);
		}
		
	}
}
