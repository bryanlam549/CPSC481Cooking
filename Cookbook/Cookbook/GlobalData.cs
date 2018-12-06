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
        #region //You can collapse these
        // ~~~~~~init the ingredients and fill ingredients list here
        #region //Ingredients
        public static Ingredient darksoysauce = new Ingredient()
        {
            _name = "Dark Soy Sauce",
            _measurement = 1 / 3,
            _standardUnit = Ingredient.Units.CUP,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient oystersauce = new Ingredient()
        {
            _name = "Oyster Sauce",
            _measurement = 1 / 4,
            _standardUnit = Ingredient.Units.CUP,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient sugar = new Ingredient()
        {
            _name = "Sugar",
            _measurement = 2,
            _standardUnit = Ingredient.Units.TBSP,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient ginger = new Ingredient()
        {
            _name = "Fresh Ginger",
            _measurement = 1.5,
            _standardUnit = Ingredient.Units.TBSP,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient pork = new Ingredient()
        {
            _name = "Pork Tenderloin",
            _measurement = 1,
            _standardUnit = Ingredient.Units.LB,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient eggnoodles = new Ingredient()
        {
            _name = "Chinese Egg Noodles",
            _measurement = 1,
            _standardUnit = Ingredient.Units.LB,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient cookingoil = new Ingredient()
        {
            _name = "Cooking Oil",
            _measurement = 2,
            _standardUnit = Ingredient.Units.TBSP,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient garlic = new Ingredient()
        {
            _name = "garlic",
            _measurement = 2,
            _standardUnit = Ingredient.Units.CUP, //??? 
            _otherUnit = "Cloves"  
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient greenonions = new Ingredient()
        {
            _name = "Green Onions",
            _measurement = 6,
            _standardUnit = Ingredient.Units.CUP, //???
            _otherUnit = "Whole"    //???
            //Don't you need a list of substitutions here? empty if none?
        };

        public static Ingredient napacabbage = new Ingredient()
        {
            _name = "Napa Cabbage",
            _measurement = 1/2,
            _standardUnit = Ingredient.Units.CUP, //???
            _otherUnit = "Head"  
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient chickenstock = new Ingredient()
        {
            _name = "Chicken Stock",
            _measurement = 1,
            _standardUnit = Ingredient.Units.CUP,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient cornstarch= new Ingredient()
        {
            _name = "Corn Starch",
            _measurement = 1.5,
            _standardUnit = Ingredient.Units.TBSP,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient seasameoil = new Ingredient()
        {
            _name = "Seasame Oil",
            _measurement = 1.5,
            _standardUnit = Ingredient.Units.TBSP,
            _otherUnit = ""  //I don't know what to put here
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient whitepepper = new Ingredient()
        {
            _name = "Ground White Pepper",
            _measurement = 1,
            _standardUnit = Ingredient.Units.CUP,
            _otherUnit = ""  //???
            //Don't you need a list of substitutions here? empty if none?
        };
        #endregion
        public Recipe _shanghaiNoodlesRecipe = new Recipe()
        {
            _isFavourite = true,
            _name = "Shanghai Noodles",
            _image = (BitmapImage)Application.Current.Resources["shanghaiNoodlesIcon"],
            _difficulty = Recipe.Difficulties.EASY,
            _rating = 0,
            _duration = 15,
            _description = "\"Easy, quick and incredibly delicious, these Chinese fried noodles are street food at its best!\"",
            _servings = 4,
            _ingredientCount = 14,
            _category = Recipe.Categories.CHINESE,
            _ingredients = new List<Ingredient> {darksoysauce, oystersauce, sugar, ginger, pork, eggnoodles, cookingoil, garlic, greenonions,
                napacabbage, cornstarch, seasameoil, whitepepper},
            _equipment = new List<string> { "1 wok or heavy skillet", "stirring utensils" },
            _steps = new List<string> { @"To make the <hyperLink>marinade</hyperLink>, combine the soy sauce, oyster sauce, sugar and ginger and stir until the sugar is dissolved."
                                        +"Place the pork in the marinade and let sit for 10 minutes",
                                        @"Heat the oil in a wok or heavy skillet on high heat and fry the pork for one minute or until done (set the reserved aside)."
                                        +"Remove the pork and set aside." +
                                        "Next fry the white parts of the cabbage and green onions along with the garlic for 30 seconds or until tender." +
                                        "Return the pork to the pan along with the reserved marinade, the sesame oil, chicken/cornstarch mixture and the green parts of the cabbage and green onions." +
                                        "Cook for 30 seconds."+
                                        "Add the noodles and stir until combined."+
                                        "Add white pepper to taste."+
                                        "Serve immediately.hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh"+ 
                "ihaknkjhkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"}
    };
        #endregion

        // 2.)Burger:
        #region
        // ~~~~~~init the ingredients and fill ingredients list here
        #region //Ingredients
        public static Ingredient hambuns = new Ingredient()
        {
            _name = "Hamburger Buns",
            _measurement = 2,
            _standardUnit = Ingredient.Units.CUP,
            _otherUnit = "Whole"
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient hampatty = new Ingredient()
        {
            _name = "Ham Patty",
            _measurement = 1,
            _standardUnit = Ingredient.Units.CUP,
            _otherUnit = "Whole"
            //Don't you need a list of substitutions here? empty if none?
        };
        public static Ingredient ketchup = new Ingredient()
        {
            _name = "Ketchup",
            _measurement = 5,
            _standardUnit = Ingredient.Units.CUP,
            _otherUnit = ""
            //Don't you need a list of substitutions here? empty if none?
        };

        #endregion
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
            _ingredients = new List<Ingredient> { hambuns, hampatty, ketchup },
            _equipment = new List<string> { "Frying Pan", "Grill", "Oven" },
            _steps = new List<string> { @"Grill Patty",
                                        @"Fry Patty", @"Steam Patty for 10 minutes", @"Delicately Place on buns", @"Pour your entire 5 cups of ketchup"
                                        +"all over for the finish!" }
        };
        #endregion
        

        public List<Recipe> recentList = new List<Recipe>(); //List of recently viewed recipe
        public List<Recipe> recipeList = new List<Recipe>(); //List of recipes
        public List<Recipe> modRecipeList = new List<Recipe>(); //List of MODIFIED recipes
        public List<RecipeProfilePage> recipePageList = new List<RecipeProfilePage>(); //Used to access profile pages
        public List<RecipeProfilePage> modrecipePageList = new List<RecipeProfilePage>(); //Used to access modified profile pages

        //Main page
        public SearchPage1 search = new SearchPage1();
        //public CookbookPage1 cookbookPage = new CookbookPage1();
        public CurrentRecipePage1 currentRecipePage = new CurrentRecipePage1();
        public ProfilePage1 profilePage = new ProfilePage1();

        //Current recipe
        public Recipe currentRecipe;

        //Store previous page...using this for back button for now. Unless better solution comes up
        public Page prevPage;

        private GlobalData()
        {
            recipeList.Add(_shanghaiNoodlesRecipe);
            recipeList.Add(_burger);
            
            for (int i = 0; i < recipeList.Count; i++)
            {
                RecipeProfilePage recipeProfilePage = new RecipeProfilePage(recipeList[i]);
                recipePageList.Add(recipeProfilePage);
            }

        }

    }
}
