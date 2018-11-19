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
        private ImageSource image;
        public ImageSource Image
        {
            get { return image; }
            set
            {
                image = value;
                this.foodPic.Source = this.image;
            }
        }
        public CookbookRecipes()
        {
            InitializeComponent();
        }
    }
}
