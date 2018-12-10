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
	/// Interaction logic for FilterBar.xaml
	/// </summary>
	public partial class FilterBar : UserControl
	{
	
		private StackPanel showing;

		public FilterBar()
		{
			InitializeComponent();

			showing = null;


			ingrCountChoice.Visibility = Visibility.Hidden;
			timeChoice.Visibility = Visibility.Hidden;
		}

		private void Diffculty_Click(object sender, RoutedEventArgs e)
		{
			// Close if showing these options already, otherwise switch to/open
			if (showing == difficultyOptions)
			{
				options.Visibility = Visibility.Hidden;
				difficultyOptions.Visibility = Visibility.Hidden;
				showing = null;
				difficultyButton.Background = Brushes.IndianRed;
			}
			else
			{
				options.Visibility = Visibility.Visible;
				if (showing != null)
				{
					showing.Visibility = Visibility.Hidden;

					ratingButton.Background = Brushes.IndianRed;
					ingrCountButton.Background = Brushes.IndianRed;
					timeButton.Background = Brushes.IndianRed;

				}
				difficultyOptions.Visibility = Visibility.Visible;
				showing = difficultyOptions;
				difficultyButton.Background = Brushes.DarkRed;
			}
		}

		private void Rating_Click(object sender, RoutedEventArgs e)
		{
			// Close if showing these options already, otherwise switch to/open
			if (showing == ratingOptions)
			{
				options.Visibility = Visibility.Hidden;
				ratingOptions.Visibility = Visibility.Hidden;
				showing = null;
				ratingButton.Background = Brushes.IndianRed;
			}
			else
			{
				options.Visibility = Visibility.Visible;
				if (showing != null)
				{
					showing.Visibility = Visibility.Hidden;

					difficultyButton.Background = Brushes.IndianRed;
					ingrCountButton.Background = Brushes.IndianRed;
					timeButton.Background = Brushes.IndianRed;
				}
				ratingOptions.Visibility = Visibility.Visible;
				showing = ratingOptions;
				ratingButton.Background = Brushes.DarkRed;
			}
		}

		private void IngredCount_Click(object sender, RoutedEventArgs e)
		{
			// Close if showing these options already, otherwise switch to/open
			if (showing == ingrCountOptions)
			{
				options.Visibility = Visibility.Hidden;
				ingrCountOptions.Visibility = Visibility.Hidden;
				showing = null;
				ingrCountButton.Background = Brushes.IndianRed;
			}
			else
			{
				options.Visibility = Visibility.Visible;
				if (showing != null)
				{
					showing.Visibility = Visibility.Hidden;

					ratingButton.Background = Brushes.IndianRed;
					difficultyButton.Background = Brushes.IndianRed;
					timeButton.Background = Brushes.IndianRed;

				}
				ingrCountOptions.Visibility = Visibility.Visible;
				showing = ingrCountOptions;
				ingrCountButton.Background = Brushes.DarkRed;
			}
		}

		private void Time_Click(object sender, RoutedEventArgs e)
		{
			// Close if showing these options already, otherwise switch to/open
			if (showing == timeOptions)
			{
				options.Visibility = Visibility.Hidden;
				timeOptions.Visibility = Visibility.Hidden;
				showing = null;
				timeButton.Background = Brushes.IndianRed;
			}
			else
			{
				options.Visibility = Visibility.Visible;
				if (showing != null)
				{
					showing.Visibility = Visibility.Hidden;

					ratingButton.Background = Brushes.IndianRed;
					difficultyButton.Background = Brushes.IndianRed;
					ingrCountButton.Background = Brushes.IndianRed;

				}
				timeOptions.Visibility = Visibility.Visible;
				showing = timeOptions;
				timeButton.Background = Brushes.DarkRed;
			}
		}

		private void oneStar_Click(object sender, RoutedEventArgs e)
		{
			if (GlobalData.Instance.ratingFilter != 1)
			{
				oneStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				twoStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				threeStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				fourStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				fiveStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

				GlobalData.Instance.ratingFilter = 1;
				ratingNum.Content = "1";
				ratingChoice.Visibility = Visibility.Visible;
			}
			else{
				oneStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

				GlobalData.Instance.ratingFilter = -1;
				ratingNum.Content = "";
				ratingChoice.Visibility = Visibility.Hidden;
			}
		}
		private void twoStar_Click(object sender, RoutedEventArgs e)
		{
			if (GlobalData.Instance.ratingFilter != 2)
			{
				oneStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				twoStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				threeStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				fourStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				fiveStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

				GlobalData.Instance.ratingFilter = 2;
				ratingNum.Content = "2";
				ratingChoice.Visibility = Visibility.Visible;
			}
			else
			{
				oneStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				twoStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

				GlobalData.Instance.ratingFilter = -1;
				ratingNum.Content = "";
				ratingChoice.Visibility = Visibility.Hidden;
			}
		}
		private void threeStar_Click(object sender, RoutedEventArgs e)
		{
			if (GlobalData.Instance.ratingFilter != 3)
			{
				oneStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				twoStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				threeStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				fourStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				fiveStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

				GlobalData.Instance.ratingFilter = 3;
				ratingNum.Content = "3";
				ratingChoice.Visibility = Visibility.Visible;
			}
			else
			{
				oneStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				twoStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				threeStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

				GlobalData.Instance.ratingFilter = -1;
				ratingNum.Content = "";
				ratingChoice.Visibility = Visibility.Hidden;
			}
		}
		private void fourStar_Click(object sender, RoutedEventArgs e)
		{
			if (GlobalData.Instance.ratingFilter != 4)
			{
				oneStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				twoStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				threeStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				fourStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				fiveStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

				GlobalData.Instance.ratingFilter = 4;
				ratingNum.Content = "4";
				ratingChoice.Visibility = Visibility.Visible;
			}
			else
			{
				oneStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				twoStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				threeStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				fourStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

				GlobalData.Instance.ratingFilter = -1;
				ratingNum.Content = "";
				ratingChoice.Visibility = Visibility.Hidden;
			}
		}
		private void fiveStar_Click(object sender, RoutedEventArgs e)
		{
			if (GlobalData.Instance.ratingFilter != 5)
			{
				oneStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				twoStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				threeStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				fourStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];
				fiveStar.Source = (BitmapImage)Application.Current.Resources["fillStarIcon"];

				GlobalData.Instance.ratingFilter = 5;
				ratingNum.Content = "5";
				ratingChoice.Visibility = Visibility.Visible;
			}
			else
			{
				oneStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				twoStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				threeStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				fourStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
				fiveStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

				GlobalData.Instance.ratingFilter = -1;
				ratingNum.Content = "";
				ratingChoice.Visibility = Visibility.Hidden;
			}
		}

		private void easySelect_Click(object sender, RoutedEventArgs e)
		{
			if (GlobalData.Instance.difficultyFilter != Recipe.Difficulties.EASY)
			{
				difficultyChoice.Source = (BitmapImage)Application.Current.Resources["easyIconIcon"];
				GlobalData.Instance.difficultyFilter = Recipe.Difficulties.EASY;
			}
			else {
				difficultyChoice.Source = null;
				GlobalData.Instance.difficultyFilter = Recipe.Difficulties.NONE;
			}
		}

		private void medSelect_Click(object sender, RoutedEventArgs e)
		{
			if (GlobalData.Instance.difficultyFilter != Recipe.Difficulties.MEDIUM)
			{
				difficultyChoice.Source = (BitmapImage)Application.Current.Resources["medIconIcon"];
				GlobalData.Instance.difficultyFilter = Recipe.Difficulties.MEDIUM;
			}
			else
			{
				difficultyChoice.Source = null;
				GlobalData.Instance.difficultyFilter = Recipe.Difficulties.NONE;
			}
		}

		private void hardSelect_Click(object sender, RoutedEventArgs e)
		{
			if (GlobalData.Instance.difficultyFilter != Recipe.Difficulties.HARD)
			{
				difficultyChoice.Source = (BitmapImage)Application.Current.Resources["hardIconIcon"];
				GlobalData.Instance.difficultyFilter = Recipe.Difficulties.HARD;
			}
			else
			{
				difficultyChoice.Source = null;
				GlobalData.Instance.difficultyFilter = Recipe.Difficulties.NONE;
			}
		}

		private void clearDifficulty_Click(object sender, RoutedEventArgs e)
		{
			difficultyChoice.Source = null;
			GlobalData.Instance.difficultyFilter = Recipe.Difficulties.NONE;
		}

		private void clearRating_Click(object sender, RoutedEventArgs e)
		{
			oneStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
			twoStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
			threeStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
			fourStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];
			fiveStar.Source = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

			GlobalData.Instance.ratingFilter = -1;
			ratingNum.Content = "";
			ratingChoice.Visibility = Visibility.Hidden;
		}

		private void clearIngrCount_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Instance.ingredCountFilter = -1;
			ingrCountChoice.Visibility = Visibility.Hidden;
		}

		private void clearTime_Click(object sender, RoutedEventArgs e)
		{
			GlobalData.Instance.durationFilter = -1;
			timeChoice.Visibility = Visibility.Hidden;
		}

		private void timeSlider_Change(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			timeChoice.Visibility = Visibility.Visible;
			timeChoice.Content = "≤ " + timeSlider.Value + " mins";
		}

		private void ingrCountSlider_Change(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			ingrCountChoice.Visibility = Visibility.Visible;
			ingrCountChoice.Content = "≤ " + ingrCountSlider.Value;
		}
	}
}
