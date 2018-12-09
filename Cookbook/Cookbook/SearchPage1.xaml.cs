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
		private static Category selected;
		private SearchPageResults results;

		public SearchPage1()
        {
            InitializeComponent();

			// Creating the list of categories
			Category allCat = new Category("All\nCategories", Recipe.Categories.ALL);
			Category beefCat = new Category("Beef", Recipe.Categories.BEEF);
			Category chickCat = new Category("Chicken", Recipe.Categories.CHICKEN);
			 Category pastaCat = new Category("Pastas", Recipe.Categories.PASTA);
			 Category fishCat = new Category("Fish", Recipe.Categories.FISH);
			 Category chineseCat = new Category("Chinese", Recipe.Categories.CHINESE);
			 Category vegCat = new Category("Vegetarian", Recipe.Categories.VEGETARIAN);

			selected = allCat;


		// Creating the list of categories
		var categories = new StackPanel()
			{
				Orientation = Orientation.Horizontal,

				Children = {
					allCat,
					beefCat,
					chickCat,
					pastaCat,
					fishCat,
					chineseCat,
					vegCat,
				}
			};

			scroll1.Content = categories;
			
		}

		public static void setCategory(Category newSelected){
			selected.setUnpressed();
			selected = newSelected;
		}

		
		private void Search_Click(object sender, RoutedEventArgs e)
		{
			// Get results from recipes
			List<Recipe> recipes = GlobalData.Instance.recipeList;
			// TODO filter recipes

			// Display recipes resulting from search
			GlobalData.Instance.isOnResults = true;
			results = new SearchPageResults(recipes);
			this.NavigationService.Navigate(results);
		}

		public SearchPageResults getResults(){
			// If the results haven't been created yet, just return all recipes
			if (results == null)
				return new SearchPageResults(GlobalData.Instance.recipeList);
			return results;
		}


	}
}
