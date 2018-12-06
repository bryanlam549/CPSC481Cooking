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
        
        // cache global resources here...
        private BitmapImage searchButtonImage = (BitmapImage)Application.Current.Resources["searchButtonIcon"];
        private BitmapImage searchButtonDarkImage = (BitmapImage)Application.Current.Resources["searchButtonDarkIcon"];

        private BitmapImage cookbookButtonImage = (BitmapImage)Application.Current.Resources["cookbookButtonIcon"];
        private BitmapImage cookbookButtonDarkImage = (BitmapImage)Application.Current.Resources["cookbookButtonDarkIcon"];

        private BitmapImage currentRecipeButtonImage = (BitmapImage)Application.Current.Resources["currentRecipeButtonIcon"];
        private BitmapImage currentRecipeButtonDarkImage = (BitmapImage)Application.Current.Resources["currentRecipeButtonDarkIcon"];

        private BitmapImage profileButtonImage = (BitmapImage)Application.Current.Resources["profileButtonIcon"];
        private BitmapImage profileButtonDarkImage = (BitmapImage)Application.Current.Resources["profileButtonDarkIcon"];

        

        //Main pages
        private SearchPage1 searchPage1 = GlobalData.Instance.search; // always use these instances if we want to remember the state
        //private CookbookPage1 cookbookPage1 = new CookbookPage1();
        private CurrentRecipePage1 currentRecipePage1 = GlobalData.Instance.currentRecipePage;
        private ProfilePage1 profilePage1 = GlobalData.Instance.profilePage;

        //Recipes
        public static RecipeProfilePage shanghaiProfile = new RecipeProfilePage(GlobalData.Instance._shanghaiNoodlesRecipe);
        public static RecipeProfilePage burgerprofile = new RecipeProfilePage(GlobalData.Instance._burger);
        //public static Recipe burgerProperties = GlobalData.Instance._burger; //Doesn't work unless I call this in main?!
        //public static Boolean burgerFave = GlobalData.Instance._burger._isFavourite;

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

            searchPageButtonImageBrush.ImageSource = searchButtonDarkImage; // dark

            cookbookPageButtonImageBrush.ImageSource = cookbookButtonImage; // light
            currentRecipePageButtonImageBrush.ImageSource = currentRecipeButtonImage;
            profilePageButtonImageBrush.ImageSource = profileButtonImage;



           // Main.Content = GlobalData.Instance.search;
           Main.Content = searchPage1;
        }

        private void CookbookPageButton_Click(object sender, RoutedEventArgs e)
        {
            CookbookPage1 cookbookPage1 = new CookbookPage1();
            cookbookPageButtonImageBrush.ImageSource = cookbookButtonDarkImage;// dark

            searchPageButtonImageBrush.ImageSource = searchButtonImage; // light
            currentRecipePageButtonImageBrush.ImageSource = currentRecipeButtonImage;
            profilePageButtonImageBrush.ImageSource = profileButtonImage;

            Main.Content = cookbookPage1;
        }

        private void CurrentRecipePageButton_Click(object sender, RoutedEventArgs e)
        {
            currentRecipePageButtonImageBrush.ImageSource = currentRecipeButtonDarkImage;// dark

            searchPageButtonImageBrush.ImageSource = searchButtonImage; // light
            cookbookPageButtonImageBrush.ImageSource = cookbookButtonImage;
            profilePageButtonImageBrush.ImageSource = profileButtonImage;
            if(GlobalData.Instance.currentRecipe == null)
            {
                Main.Content = currentRecipePage1;
            }
            else
            {
                Main.Content = new RecipeProfilePage(GlobalData.Instance.currentRecipe);
            }
            
        }

        private void ProfilePageButton_Click(object sender, RoutedEventArgs e)
        {
            profilePageButtonImageBrush.ImageSource = profileButtonDarkImage; // dark

            currentRecipePageButtonImageBrush.ImageSource = currentRecipeButtonImage; // light
            searchPageButtonImageBrush.ImageSource = searchButtonImage;
            cookbookPageButtonImageBrush.ImageSource = cookbookButtonImage;

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
