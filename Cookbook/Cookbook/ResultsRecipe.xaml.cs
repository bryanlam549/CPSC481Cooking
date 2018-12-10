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
	/// Interaction logic for ResultsRecipe.xaml
	/// </summary>
	public partial class ResultsRecipe : UserControl
	{
		//public List<Recipe> _recipeList;
		private BitmapImage fillStarImage = (BitmapImage)Application.Current.Resources["fillStarIcon"];
		private BitmapImage unfillStarImage = (BitmapImage)Application.Current.Resources["unfillStarIcon"];

		//Title of recipe
		private string title;
		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				this.TitleText.Text = this.title;
			}
		}

		//Duration time
		private string dur;
		public string Dur
		{
			get { return dur; }
			set
			{
				dur = value;
				this.durationLabel.Content = this.dur;
			}
		}

		//Food image
		private ImageSource foodimage;
		public ImageSource FoodImage
		{
			get { return foodimage; }
			set
			{
				foodimage = value;
				this.foodPic.ImageSource = this.foodimage;
			}
		}

		//Difficulty image
		private ImageSource diffimage;
		public ImageSource DiffImage
		{
			get { return diffimage; }
			set
			{
				diffimage = value;
				this.difficulty.Source = this.diffimage;
			}
		}

		//Ratings
		private ImageSource rate1image;
		public ImageSource Rate1Image
		{
			get { return rate1image; }
			set
			{
				rate1image = value;
				this.rating1.Source = this.rate1image;
			}
		}
		private ImageSource rate2image;
		public ImageSource Rate2Image
		{
			get { return rate2image; }
			set
			{
				rate2image = value;
				this.rating2.Source = this.rate2image;
			}
		}
		private ImageSource rate3image;
		public ImageSource Rate3Image
		{
			get { return rate3image; }
			set
			{
				rate3image = value;
				this.rating3.Source = this.rate3image;
			}
		}
		private ImageSource rate4image;
		public ImageSource Rate4Image
		{
			get { return rate4image; }
			set
			{
				rate4image = value;
				this.rating4.Source = this.rate4image;
			}
		}
		private ImageSource rate5image;
		public ImageSource Rate5Image
		{
			get { return rate5image; }
			set
			{
				rate5image = value;
				this.rating5.Source = this.rate5image;
			}
		}


		private Recipe recipe;
		public Recipe Recipe
		{
			get { return recipe; }
			set
			{
				recipe = value;
			}
		}

		public ResultsRecipe(Recipe recip)
		{
			InitializeComponent();

			Title = recip._name;
			FoodImage = recip._image;
			Dur = recip._duration.ToString() + "m";
			ingNum.Content = recip._ingredients.Count.ToString() + " Ingredients";
			Recipe = recip;

			if (recip._difficulty == Recipe.Difficulties.EASY)
				DiffImage = (BitmapImage)Application.Current.Resources["easyIconIcon"];
			else if (recip._difficulty == Recipe.Difficulties.MEDIUM)
				DiffImage = (BitmapImage)Application.Current.Resources["medIconIcon"];
			else if (recip._difficulty == Recipe.Difficulties.HARD)
				DiffImage = (BitmapImage)Application.Current.Resources["hardIconIcon"];
			
			
			if (recip._rating == 1)
			{
				Rate1Image = fillStarImage;
				Rate2Image = unfillStarImage;
				Rate3Image = unfillStarImage;
				Rate4Image = unfillStarImage;
				Rate5Image = unfillStarImage;
			}
			else if (recip._rating == 2)
			{
				Rate1Image = fillStarImage;
				Rate2Image = fillStarImage;
				Rate3Image = unfillStarImage;
				Rate4Image = unfillStarImage;
				Rate5Image = unfillStarImage;
			}
			else if (recip._rating == 3)
			{
				Rate1Image = fillStarImage;
				Rate2Image = fillStarImage;
				Rate3Image = fillStarImage;
				Rate4Image = unfillStarImage;
				Rate5Image = unfillStarImage;
			}
			else if (recip._rating == 4)
			{
				Rate1Image = fillStarImage;
				Rate2Image = fillStarImage;
				Rate3Image = fillStarImage;
				Rate4Image = fillStarImage;
				Rate5Image = unfillStarImage;
			}
			else if (recip._rating == 5)
			{
				Rate1Image = fillStarImage;
				Rate2Image = fillStarImage;
				Rate3Image = fillStarImage;
				Rate4Image = fillStarImage;
				Rate5Image = fillStarImage;
			}

		}

		private void foodProfileButton_Click(object sender, RoutedEventArgs e)
		{
			if (!GlobalData.Instance.recentList.Contains(recipe))
				GlobalData.Instance.recentList.Add(recipe);
			else if (GlobalData.Instance.recentList.Contains(recipe))
			{
				GlobalData.Instance.recentList.Remove(recipe);
				GlobalData.Instance.recentList.Add(recipe);
			}
			RecipeProfilePage profile = GlobalData.Instance.recipePageList[Title];
			//profile.backPage = RecipeProfilePage.BackPage.SEARCH;


			//Maybe set a flag? Also need to set something as current recipe
			GlobalData.Instance.currentRecipe = recipe;

			//resetting the start button to "START" since its changed to continue during navigation bak from steps
			profile._startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "START");
			//resetting current step to zero when accessed from favourites page
			profile._currentStep = 0;
			profile._completionPage = null;

			((MainWindow)App.Current.MainWindow).currentRecipePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["currentRecipeButtonDarkIcon"];
			((MainWindow)App.Current.MainWindow).searchPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["searchButtonIcon"];
            GlobalData.Instance.savedMainWindowContent = ((MainWindow)App.Current.MainWindow).Main.Content;
            GlobalData.Instance.backPageTag = RecipeProfilePage.BackPage.SEARCH;
			((MainWindow)App.Current.MainWindow).Main.Content = profile;

		}
		
	}
}
