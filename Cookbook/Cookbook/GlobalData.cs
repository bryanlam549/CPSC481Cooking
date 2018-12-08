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
        // 1.) Shanghai Noodles:
        #region SHANGAI NOODLES
        // ~~~~~~init the ingredients and fill ingredients list here
        #region //Ingredients
            /*
        public static Ingredient darksoysauce = new Ingredient()
        {
            //_name = "Dark Soy Sauce",
            //_measurement = 1 / 3,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient oystersauce = new Ingredient()
        {
            //_name = "Oyster Sauce",
            //_measurement = 1 / 4,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient sugar = new Ingredient()
        {
            //_name = "Sugar",
            //_measurement = 2,
            //_standardUnit = Ingredient.Units.TBSP,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient ginger = new Ingredient()
        {
            //_name = "Fresh Ginger",
            //_measurement = 1.5,
            //_standardUnit = Ingredient.Units.TBSP,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient pork = new Ingredient()
        {
            //_name = "Pork Tenderloin",
            //_measurement = 1,
            //_standardUnit = Ingredient.Units.LB,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient eggnoodles = new Ingredient()
        {
            //_name = "Chinese Egg Noodles",
            //_measurement = 1,
            //_standardUnit = Ingredient.Units.LB,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient cookingoil = new Ingredient()
        {
            //_name = "Cooking Oil",
            //_measurement = 2,
            //_standardUnit = Ingredient.Units.TBSP,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient garlic = new Ingredient()
        {
            //_name = "garlic",
            //_measurement = 2,
            //_standardUnit = Ingredient.Units.CUP, //??? 
            //_otherUnit = "Cloves"  
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient greenonions = new Ingredient()
        {
            //_name = "Green Onions",
            //_measurement = 6,
            //_standardUnit = Ingredient.Units.CUP, //???
            //_otherUnit = "Whole"    //???
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient napacabbage = new Ingredient()
        {
            //_name = "Napa Cabbage",
            //_measurement = 1/2,
            //_standardUnit = Ingredient.Units.CUP, //???
            //_otherUnit = "Head"  
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient chickenstock = new Ingredient()
        {
            //_name = "Chicken Stock",
            //_measurement = 1,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient cornstarch= new Ingredient()
        {
            //_name = "Corn Starch",
            //_measurement = 1.5,
            //_standardUnit = Ingredient.Units.TBSP,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient seasameoil = new Ingredient()
        {
            //_name = "Seasame Oil",
            //_measurement = 1.5,
            //_standardUnit = Ingredient.Units.TBSP,
            //_otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient whitepepper = new Ingredient()
        {
            //_name = "Ground White Pepper",
            //_measurement = 1,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = ""  //???
            //Don't you need a list of substitutions here? empty if none?
        };
        */
        #endregion
        public Recipe _shanghaiNoodlesRecipe = new Recipe()
        {
            _isFavourite = true,
            _name = "Shanghai Noodles",
            _image = (BitmapImage)Application.Current.Resources["shanghaiNoodlesIcon"],
            _difficulty = Recipe.Difficulties.HARD,
            _rating = 0,
            _duration = 15,
            _description = "\"Easy, quick and incredibly delicious, these Chinese fried noodles are street food at its best!\"",
            _servings = 4,
            _ingredientCount = 14,
            _category = Recipe.Categories.CHINESE,
            //_ingredients = new List<Ingredient> {darksoysauce, oystersauce, sugar, ginger, pork, eggnoodles, cookingoil, garlic, greenonions,
            //  napacabbage, cornstarch, seasameoil, whitepepper},
            _ingredients = new List<Ingredient>
            {
                new Ingredient((double)1/3, "1/3", Ingredient.UnitType.VOLUME, Ingredient.CUPS, "dark soy sauce"),
                new Ingredient(0.25, "1/4", Ingredient.UnitType.VOLUME, Ingredient.CUPS, "oyster sauce"),
                new Ingredient(2.0, "2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "sugar"),
                new Ingredient(1.5, "1 1/2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "fresh ginger"),
                new Ingredient(1.0, "1", Ingredient.UnitType.MASS, Ingredient.LBS, "pork tenderloin"),
                new Ingredient(1.0, "1", Ingredient.UnitType.MASS, Ingredient.LBS, "Chinese egg noodles"),
                new Ingredient(2.0, "2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "cooking oil"),
                new Ingredient(2.0, "2", Ingredient.UnitType.SPECIAL, "cloves", "garlic"),
                new Ingredient(6.0, "6", Ingredient.UnitType.NONE, "NO UNIT", "green onions"),
                new Ingredient(0.5, "1/2", Ingredient.UnitType.SPECIAL, "head", "Napa cabbage"),
                new Ingredient(1.0, "1", Ingredient.UnitType.VOLUME, Ingredient.CUPS, "chicken stock"),
                new Ingredient(1.5, "1 1/2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "cornstarch"),
                new Ingredient(1.5, "1 1/2", Ingredient.UnitType.VOLUME, Ingredient.TBSP, "sesame oil"),
                new Ingredient(0, "", Ingredient.UnitType.NONE, "NO UNIT", "ground white pepper"),


            },


            _equipment = new List<string> { "1 wok or heavy skillet", "stirring utensils" },
            _steps = new List<string> { @"To make the marinade, combine the soy sauce, oyster sauce, sugar and ginger and stir until the sugar is dissolved."
                                        +"Place the pork in the marinade and let sit for 10 minutes",
                                        @"Heat the oil in a wok or heavy skillet on high heat and fry the pork for one minute or until done (set the reserved aside)."
                                        +"Remove the pork and set aside.",
                                        @"Next fry the white parts of the cabbage and green onions along with the garlic for 30 seconds or until tender.",
                                        @"Return the pork to the pan along with the reserved marinade, the sesame oil, chicken/cornstarch mixture and the green parts of the cabbage and green onions." +
                                        "Cook for 30 seconds."+
                                        "Add the noodles and stir until combined."+
                                        "Add white pepper to taste."+
                                        "Serve immediately."},
            _timerValuesForSteps = new List<int> { 600, 60, 30, 30}
        };
        #endregion

        // 2.) Burger:
        #region BURGER
        // ~~~~~~init the ingredients and fill ingredients list here
        #region //Ingredients
            /*
        public static Ingredient hambuns = new Ingredient()
        {
            //_name = "Hamburger Buns",
            //_measurement = 2,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = "Whole"
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient hampatty = new Ingredient()
        {
            //_name = "Ham Patty",
            //_measurement = 1,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = "Whole"
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient ketchup = new Ingredient()
        {
            //_name = "Ketchup",
            //_measurement = 5,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = ""
            //Don't you need a list of substitutions here? empty if none?
        };
        */
        #endregion
        public Recipe _burger = new Recipe()
        {
            _isFavourite = true,
            _name = "Steamed Hams",
            _image = (BitmapImage)Application.Current.Resources["burgerIcon"],
            _difficulty = Recipe.Difficulties.EASY,
            _rating = 2,
            _duration = 20,
            _description = "\"Blah blah blah!\"",
            _servings = 1,
            _ingredientCount = 3,
            _category = Recipe.Categories.BEEF,
            //_ingredients = new List<Ingredient> { hambuns, hampatty, ketchup },
            _equipment = new List<string> { "Frying Pan", "Grill", "Oven" },
            _steps = new List<string> { @"Grill Patty",
                                        @"Fry Patty", @"Steam Patty for 10 minutes", @"Delicately Place on buns", @"Pour your entire 5 cups of ketchup"
                                        +"all over for the finish!" }
        };
        #endregion 

        // 3.) Holy Mackeral
        #region HOLY MACKERAL
        #region Ingredients
        //Will reuse cooking oil and cloves from Shanghai noodle recipe
        /*
        public static Ingredient mackeral = new Ingredient()
        {
            //_name = "Mackeral",
            //_measurement = 1,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = "Whole"
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient sage = new Ingredient()
        {
            //_name = "Sage",
            //_measurement = 1,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = "Sprig"
            //Don't you need a list of substitutions here? empty if none?
        };
        */
        #endregion
        public Recipe _holymackeral = new Recipe()
        {
            _isFavourite = true,
            _name = "Holy Mackeral",
            _image = (BitmapImage)Application.Current.Resources["holymackeralIcon"],
            _difficulty = Recipe.Difficulties.MEDIUM,
            _rating = 4,
            _duration = 50,
            _description = "\"A divine fish... a divine dish!\"",
            _servings = 4,
            _ingredientCount = 4,
            _category = Recipe.Categories.FISH,
            //_ingredients = new List<Ingredient> {mackeral, sage, garlic, cookingoil},
            _equipment = new List<string> { "Oven", "4\" Chef Knife","Baking tray", "Blender" },
            _steps = new List<string> { @"Gut the Mackeral, if not already gutted", @"Chop some 2 cloves of garlic", @"Heat 2 TBSP of cooking oil and briefly,"
                                        + "fry with the garlic, sprig of sage and the fish", @"Place fish in the baking tray and cook at 350F",
                                        @"Once done, put the whole thing in the blender"}
        };
        #endregion

        // 4.)
        #region
        #region Ingredients
            /*
        //Will reuse cooking oil and cloves from Shanghai noodle recipe
        public static Ingredient chowmeinNoodles = new Ingredient()
        {
            //_name = "Chow Mein Noodles",
            //_measurement = 170,
            //_standardUnit = Ingredient.Units.G,
            //_otherUnit = ""
            //Don't you need a list of substitutions here? empty if none?
        };
        //Will reuse cooking oil and cloves from Shanghai noodle recipe
        public static Ingredient chickenthighs = new Ingredient()
        {
            //_name = "ChickenThighs",
            //_measurement = 454,
            //_standardUnit = Ingredient.Units.G,
            //_otherUnit = ""
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient bonelesschickenthighs = new Ingredient()
        {
            //_name = "ChickenThighs",
            //_measurement = 454,
            //_standardUnit = Ingredient.Units.G,
            //_otherUnit = ""
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient broth = new Ingredient()
        {
            //_name = "Broth",
            //_measurement = 2,
            //_standardUnit = Ingredient.Units.CUP,
            //_otherUnit = ""
            //Don't you need a list of substitutions here? empty if none?
        };
        */
        #endregion

        public Recipe _chowmein = new Recipe()
        {
            _isFavourite = true,
            _name = "Chicken Chow Mein",
            _image = (BitmapImage)Application.Current.Resources["chowmeinIcon"],
            _difficulty = Recipe.Difficulties.MEDIUM,
            _rating = 3,
            _duration = 25,
            _description = "\"A traditional Chinese dish.\"",
            _servings = 4,
            _ingredientCount = 6,
            _category = Recipe.Categories.CHINESE,
            //_ingredients = new List<Ingredient> { chowmeinNoodles, bonelesschickenthighs, broth, seasameoil, darksoysauce, cornstarch },
            _equipment = new List<string> { "Whisk", "Non-Stick-Skillet" },
            _steps = new List<string> { @"In a small bowl, whisk together dark soy sauce, cornstarch and broth. Set aside.", @"Cook chow mein noodles according to package instructions",
                                        @"In a large non-stick skillet, heat oil over medium high heat. Add chicken and cook until chicken is browned. Stir in the carrots and cook for 2 minutes",
                                        @"Pour in broth mixture and bring to a boil. Cook until sauce is slightly thickened. Stir in seasame oil.",
                                        @"Spread noodles onto a platter and pour chicken mixture over top. Serve immediately."}
        };


        #endregion

        // 5.)
        #region
        #region Ingredients
            /*
        public static Ingredient lettuce = new Ingredient()
        {
            //_name = "Lettece",
            //_measurement = 1,
            //_standardUnit = Ingredient.Units.CUP, //???
            //_otherUnit = "Head"
            //Don't you need a list of substitutions here? empty if none?
        };
        */
        #endregion
        public Recipe _salad = new Recipe()
        {
            _isFavourite = true,
            _name = "Head of Lettece",
            _image = (BitmapImage)Application.Current.Resources["saladIcon"],
            _difficulty = Recipe.Difficulties.EASY,
            _rating = 1,
            _duration = 5,
            _description = "\"Literally a head of lettece\"",
            _servings = 2,
            _ingredientCount = 1,
            _category = Recipe.Categories.VEGETARIAN,
            //_ingredients = new List<Ingredient> { lettuce },
            _equipment = new List<string> { },
            _steps = new List<string> { @"Wash head of lettece", @"Enjoy" }
        };
        #endregion

        public List<Recipe> recentList = new List<Recipe>(); //List of recently viewed recipe
        public List<Recipe> recipeList = new List<Recipe>(); //List of recipes
        public List<Recipe> modRecipeList = new List<Recipe>(); //List of MODIFIED recipes
        public Dictionary<String, RecipeProfilePage> recipePageList = new Dictionary<string, RecipeProfilePage>(); //Used to access profile pages
        public List<RecipeProfilePage> modrecipePageList = new List<RecipeProfilePage>(); //Used to access modified profile pages

        public  Dictionary<String, String> lookUpTerms = new Dictionary<String, String>(); //map of dictionary words

        public RecipeCompletionPage completionPage;

        //Main page
        public SearchPage1 search = new SearchPage1();
        //public CookbookPage1 cookbookPage = new CookbookPage1();
        public CurrentRecipePage1 currentRecipePage = new CurrentRecipePage1();
        public ProfilePage1 profilePage = new ProfilePage1();

        public bool signedIn = false;

        //Current recipe
        public Recipe currentRecipe;

        public List<string> accountList = new List<string>();

        //Store previous page...using this for back button for now. Unless better solution comes up
        public Page prevPage;

        private GlobalData()
        {
            recipeList.Add(_shanghaiNoodlesRecipe);
            recipeList.Add(_burger);
            recipeList.Add(_holymackeral);
            recipeList.Add(_chowmein);
            recipeList.Add(_salad);
            //Adds a profile page for each recipe
            for (int i = 0; i < recipeList.Count; i++)
            {
                RecipeProfilePage recipeProfilePage = new RecipeProfilePage(recipeList[i]);
                recipePageList.Add(recipeProfilePage._recipe._name, recipeProfilePage);
            }

            lookUpTerms.Add("marinade", "A marinade is a sauce, typically made of oil, vinegar, spices, and herbs, in which meat, fish, or other food is soaked before cooking in order to flavor or soften it.");
            lookUpTerms.Add("Chop", "cut into small pieces with repeated sharp blows a knife.");

            accountList.Add("foodluver123");
            accountList.Add("ilovefood456@food.com");
            accountList.Add("123456789");
            accountList.Add("1");
            accountList.Add("2");

            accountList.Add("foodisLIFE");
            accountList.Add("burgers@food.com");
            accountList.Add("123456789123456789123456789");
            accountList.Add("2");
            accountList.Add("2");
        }

    }
}
