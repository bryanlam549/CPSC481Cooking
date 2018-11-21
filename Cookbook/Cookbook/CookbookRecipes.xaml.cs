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
                this.TitleText.Content = this.title;
            }
        }

        //Food description
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                this.desc.Text= this.description;
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

        //Need to do ratings too...
        public CookbookRecipes()
        {
            InitializeComponent();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
