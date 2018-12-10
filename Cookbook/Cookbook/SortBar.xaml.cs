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
	/// Interaction logic for SortBar.xaml
	/// </summary>
	public partial class SortBar : UserControl
	{
		private bool ascSort = false;

        public SearchPageResults resultsPage;

		public SortBar()
		{
			InitializeComponent();
			
		}

		private void Direction_Click(object sender, RoutedEventArgs e)
		{
			if (ascSort){
				ascSort = false;

				arrowHeadUp.Fill = Brushes.IndianRed;
				arrowUp.Fill = Brushes.IndianRed;

				arrowHeadDown.Fill = Brushes.DarkRed;
				arrowDown.Fill = Brushes.DarkRed;

				GlobalData.Instance.sortAsc = false;

			} else{
				ascSort = true;

				arrowHeadUp.Fill = Brushes.DarkRed;
				arrowUp.Fill = Brushes.DarkRed;

				arrowHeadDown.Fill = Brushes.IndianRed;
				arrowDown.Fill = Brushes.IndianRed;

				GlobalData.Instance.sortAsc = true;
				
			}

			if (resultsPage != null)
				resultsPage.sort();
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (comboBox.Text.Equals("Sort by NONE")){
				GlobalData.Instance.sortBy = "None";
			}
			else if (comboBox.Text.Equals("Sort by DIFFICULTY"))
			{
				GlobalData.Instance.sortBy = "Difficulty";
			}
			else if (comboBox.Text.Equals("Sort by RATING"))
			{
				GlobalData.Instance.sortBy = "Rating";
			}
			else if (comboBox.Text.Equals("Sort by INGREDIENT COUNT"))
			{
				GlobalData.Instance.sortBy = "Ingredient";
			}
			else if (comboBox.Text.Equals("Sort by TIME"))
			{
				GlobalData.Instance.sortBy = "Time";
			}

			if (resultsPage != null)
				resultsPage.sort();

		}
	}
}
