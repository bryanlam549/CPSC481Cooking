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
		Category allCat;
		Category beefCat;
		Category chickCat;
		Category pastaCat;
		Category fishCat;
		Category chineseCat;
		Category vegCat;

		public static Category selected;
		private SearchPageResults results;
		private List<String> ingredients;

		public SearchPage1()
        {
            InitializeComponent();

			// Creating the list of categories
			allCat = new Category("All\nCategories", Recipe.Categories.ALL);
			beefCat = new Category("Beef", Recipe.Categories.BEEF);
			chickCat = new Category("Chicken", Recipe.Categories.CHICKEN);
			 pastaCat = new Category("Pastas", Recipe.Categories.PASTA);
			 fishCat = new Category("Fish", Recipe.Categories.FISH);
			 chineseCat = new Category("Chinese", Recipe.Categories.CHINESE);
			 vegCat = new Category("Vegetarian", Recipe.Categories.VEGETARIAN);

			selected = allCat;
			selected.setPressed();

			ingredients = new List<String>();

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
			selected.setPressed();
			GlobalData.Instance.categoryFilter = newSelected.category;
		}

		
		private void Search_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Instance.searchFilter = searchBar.Text.Trim();

			if (filterBar.timeChoice.Visibility == Visibility.Visible)
				GlobalData.Instance.durationFilter = Convert.ToInt32(filterBar.timeSlider.Value);

			if (filterBar.ingrCountChoice.Visibility == Visibility.Visible)
				GlobalData.Instance.ingredCountFilter = Convert.ToInt32(filterBar.ingrCountSlider.Value);

			System.Diagnostics.Debug.WriteLine(GlobalData.Instance.durationFilter);
			System.Diagnostics.Debug.WriteLine(GlobalData.Instance.ingredCountFilter);

			// Get results from recipes
			List<Recipe> recipes = GlobalData.Instance.recipeList;
			List<Recipe> filteredRecipes = new List<Recipe>();

			foreach (Recipe recip in recipes) {
				if (matchesFilter(recip))
					filteredRecipes.Add(recip);
			}
			

			// Display recipes resulting from search
			GlobalData.Instance.isOnResults = true;
			results = new SearchPageResults(filteredRecipes, filterBar);
			this.NavigationService.Navigate(results);
		}

		public SearchPageResults getResults(){
			// If the results haven't been created yet, just return all recipes
			if (results == null)
				return new SearchPageResults(GlobalData.Instance.recipeList, filterBar);
			return results;
		}

		private void Reset_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Instance.searchFilter = "";
			GlobalData.Instance.ingredFilter.Clear();
			GlobalData.Instance.difficultyFilter = Recipe.Difficulties.NONE;
			GlobalData.Instance.ratingFilter = -1;
			GlobalData.Instance.durationFilter = -1;
			GlobalData.Instance.ingredCountFilter = -1;
			GlobalData.Instance.categoryFilter = Recipe.Categories.ALL;

			setCategory(allCat);
			ingredsearchBar.Text = "";
			searchBar.Text = "";
			ingredients.Clear();

			
			filterBar.ratingNum.Content = "";
			filterBar.ratingChoice.Visibility = Visibility.Hidden;

			filterBar.oneStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
			filterBar.twoStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
			filterBar.threeStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
			filterBar.fourStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
			filterBar.fiveStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

			filterBar.difficultyChoice.Source = null;

			filterBar.ingrCountChoice.Visibility = Visibility.Hidden;
			filterBar.timeChoice.Visibility = Visibility.Hidden;

		}

		private void OnKeyDownHandler(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				if (!ingredients.Contains(ingredsearchBar.Text.Trim()) && !ingredsearchBar.Text.Equals("")) {
					ingredients.Add(ingredsearchBar.Text.Trim());
					// Create new ingredient tag
				}

				ingredsearchBar.Text = "";
			}
		}

		public bool matchesFilter(Recipe recip){
			// If any of the following conditions fails to hold, return false, but if they all hold, return true
			if (GlobalData.Instance.durationFilter != -1 && GlobalData.Instance.durationFilter < recip._duration)
				return false;
			if (GlobalData.Instance.ingredCountFilter != -1 && GlobalData.Instance.ingredCountFilter < recip._ingredientCount)
				return false;
			if (GlobalData.Instance.difficultyFilter != Recipe.Difficulties.NONE && GlobalData.Instance.difficultyFilter != recip._difficulty)
				return false;
			if (GlobalData.Instance.ratingFilter != -1 && GlobalData.Instance.ratingFilter < recip._rating)
				return false;
			if (!recip._name.ToLower().Contains(GlobalData.Instance.searchFilter.ToLower()) && !recip._description.ToLower().Contains(GlobalData.Instance.searchFilter.ToLower()))
				return false;
			if (GlobalData.Instance.categoryFilter != Recipe.Categories.ALL && GlobalData.Instance.categoryFilter != recip._category)
				return false;
			if (GlobalData.Instance.ingredFilter.Count != 0)
			{
				if (GlobalData.Instance.ingredFilter.Count > recip._ingredients.Count)
					return false;
				foreach (String ingr in GlobalData.Instance.ingredFilter){
					int index = recip._ingredients.FindIndex(i => i._mainText.Equals(ingr));
					if (index < 0)
						return false;
				}
			}

			return true;
		}

	}
}
