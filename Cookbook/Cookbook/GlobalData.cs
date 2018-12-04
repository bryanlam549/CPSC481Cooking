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
            _equipment = new List<string> { "1 wok or heavy skillet", "stirring utensils" },
            _steps = new List<string> { @"1. To make the <hyperLink>marinade</hyperLink>, combine the soy sauce, oyster sauce, sugar and ginger and stir until the sugar is dissolved."
                                        +"Place the pork in the marinade and let sit for 10 minutes",
                                        @"2. Heat the oil in a wok or heavy skillet on high heat and fry the pork for one minute or until done (set the reserved aside)."
                                        +"Remove the pork and set aside." +
                                        "Next fry the white parts of the cabbage and green onions along with the garlic for 30 seconds or until tender." +
                                        "Return the pork to the pan along with the reserved marinade, the sesame oil, chicken/cornstarch mixture and the green parts of the cabbage and green onions." +
                                        "Cook for 30 seconds."+
                                        "Add the noodles and stir until combined."+
                                        "Add white pepper to taste."+
                                        "Serve immediately.hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh"+ 
                "ihaknkjhkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk"}
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
                                        @"Fry Patty", @"Place on buns", @"POUR KETCHUP!!!" }
        };

        public List<Recipe> recentList = new List<Recipe>(); //List of recently viewed recipe
        public List<Recipe> recipeList = new List<Recipe>(); //List of recipes
        public List<Recipe> modRecipeList = new List<Recipe>(); //List of MODIFIED recipes
        public List<RecipeProfilePage> recipePageList = new List<RecipeProfilePage>(); //Used to access profile pages

        //Main page
        public SearchPage1 search = new SearchPage1();
        //public CookbookPage1 cookbookPage = new CookbookPage1();
        public CurrentRecipePage1 currentRecipePage = new CurrentRecipePage1();
        public ProfilePage1 profilePage = new ProfilePage1();




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
