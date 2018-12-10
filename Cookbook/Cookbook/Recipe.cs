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

        public enum Difficulties {
            NONE, EASY, MEDIUM, HARD
        }

        public enum Categories // ~~~~~KEEP ADDING MORE WHEN NEEDED
        {
            ALL, BEEF, CHICKEN, FISH, PASTA, CHINESE, VEGETARIAN
        }

        // FIELDS...

        public bool _isFavourite;

        public string _name;

        public BitmapImage _image;

        public Difficulties _difficulty;

        public int _rating; // 0 rating is unrated

        public int _duration; // in minutes?

        public string _description;

        public int _servings;

        public int _ingredientCount; // init based on ingredients list size

        public Categories _category; // ~~~~~~~~~~~NOTE: maybe we want to have a list of categories (e.g. a dish can have multiple categories?)

        public List<Ingredient> _ingredients = new List<Ingredient>(); // each ingredient will have text, current unit, possible units, substitutions..., _isChecked, etc.

        public List<string> _equipment = new List<string>();

        public List<string> _steps = new List<string>();

        public bool modified = false;    //Set true if this is a modified recipe. Modified will NOT have substitutions, won't have favourites and won't be shown on recent.

        public List<int> _timerValuesForSteps = new List<int>();

        public Recipe()
        {

        }

        public Recipe(Recipe template)
        {
            _isFavourite = template._isFavourite;
            _name = template._name;
            _image = template._image;
            _difficulty = template._difficulty;
            _rating = template._rating;
            _duration = template._duration;
            _description = template._description;
            _servings = template._servings;
            _ingredientCount = template._ingredientCount;
            _category = template._category;
            modified = template.modified;

            // ~~~~~~~BE CAREFUL, if an ingredient instance changes somewhere then ill have to write a copy constructor for ingredient as well... 

            List<Ingredient> tempIngredients = new List<Ingredient>();
            for (int i = 0; i < template._ingredients.Count; i++)
            {
                tempIngredients.Add(template._ingredients[i]);
            }
            _ingredients = tempIngredients;

            List<string> tempEquip = new List<string>();
            for (int i = 0; i < template._equipment.Count; i++)
            {
                tempEquip.Add(template._equipment[i]);
            }
            _equipment = tempEquip;

            List<string> tempSteps = new List<string>();
            for (int i = 0; i < template._steps.Count; i++)
            {
                tempSteps.Add(template._steps[i]);
            }
            _steps = tempSteps;

            // adding the same time values as the template
            List<int> timeValuesForStep = new List<int>();
            for (int i = 0; i < template._timerValuesForSteps.Count; i++)
            {
                timeValuesForStep.Add(template._timerValuesForSteps[i]);
            }

            _timerValuesForSteps = timeValuesForStep;
        }





        public List<string> GetSteps()
        {
            return _steps;
        }

        public string getName()
        {
            return _name;
        }
    }
}
