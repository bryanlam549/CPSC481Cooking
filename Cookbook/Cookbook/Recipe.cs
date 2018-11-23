using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace Cookbook
{
    public class Recipe
    {

        private enum Difficulties {
            EASY, MEDIUM, HARD
        }

        private enum Categories // ~~~~~KEEP ADDING MORE WHEN NEEDED
        {
            BEEF, CHICKEN, FISH, PASTA
        }

        private bool _isFavourite = false;

        private string _name;

        private BitmapImage _image;

        private Difficulties _difficulty;

        private int _rating;

        private int _duration; // in minutes?

        private string _description;

        private int _servings;

        private int _ingredientCount; // init based on ingredients list size

        private Categories _category; // ~~~~~~~~~~~NOTE: maybe we want to have a list of categories (e.g. a dish can have multiple categories?)

        private List<Ingredient> _ingredients = new List<Ingredient>(); // each ingredient will have text, current unit, possible units, substitutions..., _isChecked, etc.

        private List<string> _equipment = new List<string>();

        private List<string> _steps = new List<string>();


        public Recipe()
        {
            //_ingredientCount = _ingredients.Count; but make sure this happens after we initialize the list
        }


        public void ToggleFavourite()
        {
            _isFavourite = !_isFavourite;
            // update other stuff in future
        }


    }
}
