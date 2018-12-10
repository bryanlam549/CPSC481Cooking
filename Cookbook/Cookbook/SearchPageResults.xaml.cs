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
	/// Interaction logic for SearchPageResults.xaml
	/// </summary>
	public partial class SearchPageResults : Page
	{
		List<Recipe> recipes;

		public SearchPageResults(List<Recipe> recipes, FilterBar filterBar)
		{
			InitializeComponent();

			this.recipes = recipes;
			populateRecipes(recipes);

            sortBar.resultsPage = this;

		}

		private void populateRecipes(List<Recipe> recipes){
			Recipes.Children.Clear();
			
			if (recipes.Count == 0)
			{
				errorMsg.Visibility = System.Windows.Visibility.Visible;
			}
			else
			{

				errorMsg.Visibility = System.Windows.Visibility.Hidden;
				// Set content 
				foreach (Recipe recip in recipes)
				{
					Recipes.Children.Add(new ResultsRecipe(recip));
				}
			}
		}

		private void EditSearch_Click(object sender, RoutedEventArgs e)
		{
			// Return to the search page
			GlobalData.Instance.isOnResults = false;
			this.NavigationService.Navigate(GlobalData.Instance.search);
		}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //GlobalData.Instance.savedMainWindowContent = ((MainWindow)App.Current.MainWindow).Main.Content;
            //GlobalData.Instance.backPageTag = RecipeProfilePage.BackPage.SEARCH;
        }

		public void sort()
		{

			System.Diagnostics.Debug.WriteLine(GlobalData.Instance.sortBy);

			// Sort
			if (GlobalData.Instance.sortBy.Equals("Difficulty"))
				recipes = recipes.OrderBy(r => r._difficulty).ToList();
			if (GlobalData.Instance.sortBy.Equals("Rating"))
				recipes = recipes.OrderBy(r => r._rating).ToList();
			if (GlobalData.Instance.sortBy.Equals("Ingredient Count"))
				recipes = recipes.OrderBy(r => r._ingredientCount).ToList();
			if (GlobalData.Instance.sortBy.Equals("Time"))
				recipes = recipes.OrderBy(r => r._duration).ToList();

			if (!GlobalData.Instance.sortAsc)
				recipes.Reverse();

			populateRecipes(recipes);
				
			
		}

	}
}
