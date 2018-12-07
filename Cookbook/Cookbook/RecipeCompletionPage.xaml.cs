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
    /// Interaction logic for RecipeCompletionPage.xaml
    /// </summary>
    /// 

    public partial class RecipeCompletionPage : Page
    {

        Recipe currentRecipe;

        public RecipeCompletionPage(Recipe recipe)
        {
            InitializeComponent();
            this.currentRecipe = recipe;
            _back.transitionPageButton.Click += Back_Click;
            _next.transitionPageButton.Click += Next_Click;
            _recipeImageBrush.ImageSource = recipe._image;
            _recipeName.Text = recipe._name;

            _back.initAppearance(TransitionPageButton.Orientation.BACK, "BACK TO STEPS");
            _next.initAppearance(TransitionPageButton.Orientation.FORWARD, "GO TO RECIPE PAGE");

            favHeart._recipe = currentRecipe;
            if (recipe._isFavourite)
            {
                favHeart.HeartIconImage = (BitmapImage)Application.Current.Resources["heartIcon"];
                favHeart._isFilled = true;
            }

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            RecipeProfilePage recipeProfile = new RecipeProfilePage(currentRecipe);
            this.NavigationService.Navigate(recipeProfile);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void _close_Click(object sender, RoutedEventArgs e)
        {
            this.signInBox.Visibility = System.Windows.Visibility.Hidden;
            favHeart.Visibility = System.Windows.Visibility.Visible;
            rating.Visibility = System.Windows.Visibility.Visible;
            completionMain.IsEnabled = true;
        }

        private bool modified;
        public bool Modified
        {
            get { return modified; }
            set
            {
                modified = value;
            }
        }


        //Number in list
        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                //this.NumberText.Content = this.number + ".";
            }
        }

        private void onEdit(object sender, RoutedEventArgs e)
        {

            Mod mod = new Mod(currentRecipe, 0);
            ((MainWindow)App.Current.MainWindow).Main.Content = mod;

        }
    }

}
