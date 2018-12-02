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
        //Number in list
        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                this.NumberText.Content = this.number;
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
                this.foodPic.Source = this.foodimage;
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
            //((MainWindow)App.Current.MainWindow).Test.Text = "This is simply a test";
            Mod mod = GlobalData.Instance.modification;
            ((MainWindow)App.Current.MainWindow).Main.Content = mod;
            /*
            if (this.Click != null)
            {
                this.Click(this, e);
            }*/
        }

        public List<Recipe> _recipeList = GlobalData.Instance.recipeList;
        public List<Recipe> _recentList = GlobalData.Instance.recentList;
        public List<RecipeProfilePage> _recipePageList = GlobalData.Instance.recipePageList;
        private void foodProfileButton_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < _recipeList.Count; i++)
            {
                if (this.Title == _recipeList[i]._name)
                {
                    if (!_recentList.Contains(_recipeList[i]))
                        _recentList.Add(_recipeList[i]);
                    else if (_recentList.Contains(_recipeList[i]))
                    {
                        _recentList.Remove(_recipeList[i]);
                        _recentList.Add(_recipeList[i]);
                    }
                    RecipeProfilePage profile = _recipePageList[i];//new RecipeProfilePage(GlobalData.Instance.recipeList[i]);
                    ((MainWindow)App.Current.MainWindow).Main.Content = profile;
                    break;
                }
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


    }

}

