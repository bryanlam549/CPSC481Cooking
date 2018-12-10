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
		public SearchPageResults(List<Recipe> recipes)
		{
			InitializeComponent();

			// Set content 
			foreach (Recipe recip in recipes){
				Recipes.Children.Add(new ResultsRecipe(recip));
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
            GlobalData.Instance.savedMainWindowContent = ((MainWindow)App.Current.MainWindow).Main.Content;
            GlobalData.Instance.backPageTag = RecipeProfilePage.BackPage.SEARCH;
        }
    }
}
