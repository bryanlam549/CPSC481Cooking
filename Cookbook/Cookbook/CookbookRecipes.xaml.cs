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
    /// Interaction logic for CookbookRecipes.xaml
    /// </summary>
    public partial class CookbookRecipes : UserControl
    {
        public List<Recipe> _recipeList = GlobalData.Instance.recipeList;
        public List<Recipe> _recentList = GlobalData.Instance.recentList;
        public List<Recipe> _modrecipeList = GlobalData.Instance.modRecipeList;
        public Dictionary<String, RecipeProfilePage> _recipePageList = GlobalData.Instance.recipePageList;
        public List<RecipeProfilePage> _modrecipePageList = GlobalData.Instance.modrecipePageList;

        //if it's a modified recipe. Not really shown on this page but is a hidde value that will be used to determine if it shows up
        //in personal,recent or favourites
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

        //Food description
        private string description;
        /*public string Description
        {
            get { return description; }
            set
            {
                description = value;
                this.desc.Text= this.description;
            }
        }*/

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


        //Need to do ratings too...
        public CookbookRecipes()
        {
            InitializeComponent();
        }

        //public event RoutedEventHandler Click;
        private void onButtonClickEdit(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            MainWindow x = parentWindow as MainWindow;
            Page y = x.Main.Content as Page;
            GlobalData.Instance.prevPage = y;

            //((MainWindow)App.Current.MainWindow).Test.Text = "This is simply a test";
            if (this.Modified == false)
            {
                for (int i = 0; i < _recipeList.Count; i++)
                {
                    if (this.Title == _recipeList[i]._name)
                    {
                        Mod mod = new Mod(_recipeList[i], i);
                        ((MainWindow)App.Current.MainWindow).Main.Content = mod;
                        break;
                    }
                }
            }
            else
            {
                int k = Int32.Parse(this.Number) - 1;

                Mod mod1 = new Mod(_modrecipeList[k], k);
                ((MainWindow)App.Current.MainWindow).Main.Content = mod1;


                
            }
            
            /*
            if (this.Click != null)
            {
                this.Click(this, e);
            }*/
        }

        
        private void foodProfileButton_Click(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(this.Number) - 1;
            //IF recipe is not modified: Open the profile page and add it to recent page
            if (this.Modified == false)
            {
                for (int j = 0; j < _recipeList.Count; j++)
                {
                    if (this.Title == _recipeList[j]._name)
                    {
                        if (!_recentList.Contains(_recipeList[j]))
                            _recentList.Add(_recipeList[j]);
                        else if (_recentList.Contains(_recipeList[j]))
                        {
                            _recentList.Remove(_recipeList[j]);
                            _recentList.Add(_recipeList[j]);
                        }
                        RecipeProfilePage profile = _recipePageList[_recipeList[j]._name];//new RecipeProfilePage(GlobalData.Instance.recipeList[i]);
                        profile.backPage = RecipeProfilePage.BackPage.COOKBOOK;

                        //Maybe set a flag? Also need to set something as current recipe
                        GlobalData.Instance.currentRecipe = _recipeList[j];

                        //resetting the start button to "START" since its changed to continue during navigation bak from steps
                        profile._startButton.initAppearance(TransitionPageButton.Orientation.FORWARD, "START");
                        //resetting current step to zero when accessed from favourites page
                        profile._currentStep = 0;
                        profile._completionPage = null;

                        ((MainWindow)App.Current.MainWindow).currentRecipePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["currentRecipeButtonDarkIcon"];
                        ((MainWindow)App.Current.MainWindow).cookbookPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["cookbookButtonIcon"];
                        ((MainWindow)App.Current.MainWindow).Main.Content = profile;
                        break;
                    }
                    
                }

            }
            //If you are a modified recipe: Dont add it to recently viewed tab
            //And Open page using page list (mod version)
            else
            {
                RecipeProfilePage modprofile = _modrecipePageList[i];//new RecipeProfilePage(GlobalData.Instance.recipeList[i]);
                //Maybe set a flag. Also need to set something as current recipe
                GlobalData.Instance.currentRecipe = _modrecipeList[i];
                ((MainWindow)App.Current.MainWindow).currentRecipePageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["currentRecipeButtonDarkIcon"];
                ((MainWindow)App.Current.MainWindow).cookbookPageButtonImageBrush.ImageSource = (BitmapImage)Application.Current.Resources["cookbookButtonIcon"];
                ((MainWindow)App.Current.MainWindow).Main.Content = modprofile;
            }
        }
            /*
            private void onButtonClickProfile(object sender, RoutedEventArgs e)
            {
                //((MainWindow)App.Current.MainWindow).Test.Text = "This is simply a test";

                /*if (this.Click != null)
                {
                    this.Click(this, e);
                }*/
            //}



/*
        private Page getPage()
        {
            var parent = VisualTreeHelper.GetParent(this);
            while (!(parent is Page))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return (parent as Page);
        }
*/

    }

}

