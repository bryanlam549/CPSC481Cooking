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
        /*
        // cache global resources here...
        private BitmapImage searchButtonImage = (BitmapImage)Application.Current.Resources["searchButtonIcon"];
        private BitmapImage searchButtonDarkImage = (BitmapImage)Application.Current.Resources["searchButtonDarkIcon"];

        private BitmapImage cookbookButtonImage = (BitmapImage)Application.Current.Resources["cookbookButtonIcon"];
        private BitmapImage cookbookButtonDarkImage = (BitmapImage)Application.Current.Resources["cookbookButtonDarkIcon"];

        private BitmapImage currentRecipeButtonImage = (BitmapImage)Application.Current.Resources["currentRecipeButtonIcon"];
        private BitmapImage currentRecipeButtonDarkImage = (BitmapImage)Application.Current.Resources["currentRecipeButtonDarkIcon"];

        private BitmapImage profileButtonImage = (BitmapImage)Application.Current.Resources["profileButtonIcon"];
        private BitmapImage profileButtonDarkImage = (BitmapImage)Application.Current.Resources["profileButtonDarkIcon"];
        */

        public SearchPage1 searchPage1 = new SearchPage1(); // always use these instances if we want to remember the state
        //private CookbookPage1 cookbookPage1 = new CookbookPage1();
        private CurrentRecipePage1 currentRecipePage1 = new CurrentRecipePage1();
        private ProfilePage1 profilePage1 = new ProfilePage1();

        public static Boolean burgerFave = true;

        
        //Also initialize sub pages??
        //private CookbookRecentPage cookbookRecentPage = new CookbookRecentPage();

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

        //heartButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["unfillHeartIcon"];
        private void SearchPageButton_Click(object sender, RoutedEventArgs e)
        {

            searchPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["searchButtonDarkIcon"]; // dark

            cookbookPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["cookbookButtonIcon"]; // light
            currentRecipePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["currentRecipeButtonIcon"];
            profilePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["profileButtonIcon"];



            //Main.Content = GlobalData.Instance.search;
            Main.Content = searchPage1;
        }

        private void CookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            CookbookPage1 cookbookPage1 = new CookbookPage1();
            cookbookPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["cookbookButtonDarkIcon"]; // dark

            searchPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["searchButtonIcon"]; // light
            currentRecipePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["currentRecipeButtonIcon"];
            profilePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["profileButtonIcon"];

            Main.Content = cookbookPage1;
        }

        private void CurrentRecipePageButton_Click(object sender, RoutedEventArgs e)
        {
            currentRecipePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["currentRecipeButtonDarkIcon"]; // dark

            searchPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["searchButtonIcon"]; // light
            cookbookPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["cookbookButtonIcon"];
            profilePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["profileButtonIcon"];

            Main.Content = currentRecipePage1;
        }

        private void ProfilePageButton_Click(object sender, RoutedEventArgs e)
        {
            profilePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["profileButtonDarkIcon"]; // dark

            currentRecipePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["currentRecipeButtonIcon"]; // ligh
            searchPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["searchButtonIcon"];
            cookbookPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["cookbookButtonIcon"];

            Main.Content = profilePage1;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
