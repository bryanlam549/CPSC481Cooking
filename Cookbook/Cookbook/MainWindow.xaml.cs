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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public BitmapImage searchButtonImage = new BitmapImage(new Uri("pack://application:,,,/Images/searchButton.png")); // only need to load the images once
        public BitmapImage searchButtonDarkImage = new BitmapImage(new Uri("pack://application:,,,/Images/searchButtonDark.png"));

        public BitmapImage cookbookButtonImage = new BitmapImage(new Uri("pack://application:,,,/Images/cookbookButton.png")); 
        public BitmapImage cookbookButtonDarkImage = new BitmapImage(new Uri("pack://application:,,,/Images/cookbookButtonDark.png"));

        public BitmapImage currentRecipeButtonImage = new BitmapImage(new Uri("pack://application:,,,/Images/currentRecipeButton.png")); 
        public BitmapImage currentRecipeButtonDarkImage = new BitmapImage(new Uri("pack://application:,,,/Images/currentRecipeButtonDark.png"));

        public BitmapImage profileButtonImage = new BitmapImage(new Uri("pack://application:,,,/Images/profileButton.png")); 
        public BitmapImage profileButtonDarkImage = new BitmapImage(new Uri("pack://application:,,,/Images/profileButtonDark.png"));


        private SearchPage1 searchPage1 = new SearchPage1(); // always use these instances if we want to remember the state
        private CookbookPage1 cookbookPage1 = new CookbookPage1();
        private CurrentRecipePage1 currentRecipePage1 = new CurrentRecipePage1();
        private ProfilePage1 profilePage1 = new ProfilePage1();


        public MainWindow()
        {
            InitializeComponent();

            this.Top = 0;
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;

            Main.Content = searchPage1; // start app at search page 1

        }



        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void SearchPageButton_Click(object sender, RoutedEventArgs e)
        {
            searchPageButtonImageBrush.ImageSource = searchButtonDarkImage; // dark

            cookbookPageButtonImageBrush.ImageSource = cookbookButtonImage; // light
            currentRecipePageButtonImageBrush.ImageSource = currentRecipeButtonImage;
            profilePageButtonImageBrush.ImageSource = profileButtonImage; 

            Main.Content = searchPage1;
        }

        private void CookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            cookbookPageButtonImageBrush.ImageSource = cookbookButtonDarkImage; // dark

            searchPageButtonImageBrush.ImageSource = searchButtonImage; // light
            currentRecipePageButtonImageBrush.ImageSource = currentRecipeButtonImage;
            profilePageButtonImageBrush.ImageSource = profileButtonImage;

            Main.Content = cookbookPage1;
        }

        private void CurrentRecipePageButton_Click(object sender, RoutedEventArgs e)
        {
            currentRecipePageButtonImageBrush.ImageSource = currentRecipeButtonDarkImage; // dark

            searchPageButtonImageBrush.ImageSource = searchButtonImage; // light
            cookbookPageButtonImageBrush.ImageSource = cookbookButtonImage;
            profilePageButtonImageBrush.ImageSource = profileButtonImage;

            Main.Content = currentRecipePage1;
        }

        private void ProfilePageButton_Click(object sender, RoutedEventArgs e)
        {
            profilePageButtonImageBrush.ImageSource = profileButtonDarkImage; // dark

            searchPageButtonImageBrush.ImageSource = searchButtonImage; // light
            cookbookPageButtonImageBrush.ImageSource = cookbookButtonImage;
            currentRecipePageButtonImageBrush.ImageSource = currentRecipeButtonImage;

            Main.Content = profilePage1;
        }
    }
}
