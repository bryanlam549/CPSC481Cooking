using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;




namespace Cookbook
{
    public class GlobalData
    {
        private static GlobalData instance = new GlobalData();

        public static GlobalData Instance
        {
            get { return instance; }
        }

        //public Recipe recipe1 = new Recipe(); // something like this, then each component like a HeartButton could have a field set to 1 recipe.
        //public Recipe recipe2 = new Recipe();

        //public Page page1 = new Page();
        //public SearchPage1 search;


        // RECIPES:

        // Shanghai Noodles:

        public Recipe _shanghaiNoodlesRecipe = new Recipe()
        {
            _isFavourite = false,
            _name = "Shanghai Noodles",
            _image = (BitmapImage)Application.Current.Resources["shanghaiNoodlesIcon"],
            _difficulty = Recipe.Difficulties.EASY,
            _rating = 0,
            _duration = 15,
            _description = "\"Easy, quick and incredibly delicious, these Chinese fried noodles are street food at its best!\"",
            _servings = 4,
            _ingredientCount = 14,
            _category = Recipe.Categories.CHINESE,
            _equipment = new List<string> { "1 wok or heavy skillet", "stirring utensils" },
            _steps = new List<string> { @"1. To make the marinade, combine the soy sauce, oyster sauce, sugar and ginger and stir until the sugar is dissolved. 
                                        Place the pork in the marinade and let sit for 10 minutes",
                                        @"2. Heat the oil in a wok or heavy skillet on high heat and fry the pork for one minute or until done (set the reserved aside).
                                        Remove the pork and set aside.
                                        Next fry the white parts of the cabbage and green onions along with the garlic for 30 seconds or until tender.
                                        Return the pork to the pan along with the reserved marinade, the sesame oil, chicken/cornstarch mixture and the green parts of the cabbage and green onions.
                                        Cook for 30 seconds.
                                        Add the noodles and stir until combined.
                                        Add white pepper to taste.
                                        Serve immediately."}
    };
        // ~~~~~~init the ingredients and fill ingredients list here
        public Recipe _burger = new Recipe()
        {
            _isFavourite = true,
            _name = "Steamed Hams",
            _image = (BitmapImage)Application.Current.Resources["burgerIcon"],
            _difficulty = Recipe.Difficulties.MEDIUM,
            _rating = 2,
            _duration = 20,
            _description = "\"Blah blah blah!\"",
            _servings = 2,
            _ingredientCount = 3,
            _category = Recipe.Categories.BEEF,
            _equipment = new List<string> { "Frying Pan", "Grill", "Propane" },
            _steps = new List<string> { @"Grill Patty",
                                        @"Fry Patty", @"Place on buns", "@POUR KETCHUP" }
        };

        public List<Recipe> favouriteList = new List<Recipe>();
        public List<Recipe> recentList = new List<Recipe>();
        public List<Recipe> recipeList = new List<Recipe>();
        public List<RecipeProfilePage> recipePageList = new List<RecipeProfilePage>();

        //Main page
        public SearchPage1 search = new SearchPage1();
        //public CookbookPage1 cookbookPage = new CookbookPage1();
        public CurrentRecipePage1 currentRecipePage = new CurrentRecipePage1();
        public ProfilePage1 profilePage = new ProfilePage1();

        //Cookbook subpages..Might not want this? We'll see if we run into any trouble...
        //public CookbookFavouritePage ckbkFave = new CookbookFavouritePage();
        //public CookbookRecentPage ckbkPersonal = new CookbookRecentPage();
        //public CookbookPersonalPage ckbkRecent = new CookbookPersonalPage();

        //major subpages
        //public RecipeProfilePage recProfile = new RecipeProfilePage();

        //Other subpages
        public Mod modification = new Mod();
        //Profile subpages


        private GlobalData()
        {
            favouriteList.Add(_burger);
            favouriteList.Add(_shanghaiNoodlesRecipe);
            recipeList.Add(_burger);
            recipeList.Add(_shanghaiNoodlesRecipe);
            for (int i = 0; i < recipeList.Count; i++)
            {
                RecipeProfilePage recipeProfilePage = new RecipeProfilePage(recipeList[i]);
                recipePageList.Add(recipeProfilePage);
            }
                // init fields of each recipe here
                // init fields of each page here
                //Page page = GlobalData.Instance.page1;
                //search = new SearchPage1();

                //Console.Write("TEST");

                /*
                //BRYAN'S poor attempt at initializing a recipe
                _burger._name = "Steamed Ham";
                _burger._isFavourite = true;
                _burger._image = (BitmapImage)Application.Current.Resources["burgerIcon"];
                _burger._difficulty = Recipe.Difficulties.MEDIUM;
                _burger._rating = 2;
                _burger._duration = 20;
                _burger._description = "Blah blah blah";
                _burger._servings = 1;
                _burger._category = Recipe.Categories.BEEF;

                burgerIng1._name = "Patty";
                burgerIng1._measurement = 1;
                burgerIng1._otherUnit = null;
                burgerIng1._standardUnit = Ingredient.Units.KG;

                burgerIng1._name = "Buns";
                burgerIng1._measurement = 2;
                burgerIng1._otherUnit = null;
                burgerIng1._standardUnit = Ingredient.Units.TSP;

                burgerIng1._name = "Ketchup";
                burgerIng1._measurement = 5;
                burgerIng1._otherUnit = null;
                burgerIng1._standardUnit = Ingredient.Units.L;

                _burger._ingredients.Add(burgerIng1);
                _burger._ingredients.Add(burgerIng2);
                _burger._ingredients.Add(burgerIng3);
                _burger._ingredientCount = _burger._ingredients.Count();
                _burger._equipment.Add("Propane");
                _burger._equipment.Add("Grill");
                _burger._equipment.Add("Spatula");
                _burger._steps.Add("Preheat your propane thingy");
                _burger._steps.Add("Put patty on grill");
                _burger._steps.Add("Flip patty after 1 minute");
                _burger._steps.Add("Put patty on Bun");
                */
            }

    }
}
