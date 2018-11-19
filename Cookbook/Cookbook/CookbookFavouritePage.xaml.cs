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
    /// Interaction logic for CookbookFavouritePage.xaml
    /// </summary>
    public partial class CookbookFavouritePage : Page
    {
        public CookbookFavouritePage()
        {
            InitializeComponent();

            //IF burger is favourited
            CookbookRecipes burger = new CookbookRecipes();
            burger.Number = 1.ToString();
            burger.Title = "Burgers";
            burger.Description = "This is the food description";
            //burger.Image = new Uri("Images/editIcon.png");
            this.Recipes.Children.Add(burger);
        }
    }
}
