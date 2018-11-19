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
    /// Interaction logic for CookbookPersonalPage.xaml
    /// </summary>
    public partial class CookbookPersonalPage : Page
    {
        public CookbookPersonalPage()
        {
            InitializeComponent();

            //Just creating stuff
            /*for (int i = 0; i < 20; i++)
            {
                CookbookRecipes recipe = new CookbookRecipes();
                recipe.Number = i.ToString();
                recipe.Title= "Burgers";
                recipe.Description = "This is the food description";
                this.Recipes.Children.Add(recipe);

            }*/

            //IF burger is favourited

            /*
            CookbookRecipes burger = new CookbookRecipes();
            burger.Number = 1.ToString();
            burger.Title = "Burgers";
            burger.Description = "This is the food description";
            this.Recipes.Children.Add(burger);
            */
        }
    }
}
