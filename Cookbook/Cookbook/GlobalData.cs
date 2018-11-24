using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Controls;


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


        //Main Pages!
        public SearchPage1 search = new SearchPage1();
        //public CookbookPage1 cookbookPage = new CookbookPage1();
        public CurrentRecipePage1 currentRecipePage = new CurrentRecipePage1();
        public ProfilePage1 profilePage = new ProfilePage1();

        //Cookbook subpages..Might not want this? We'll see if we run into any trouble...
        public CookbookFavouritePage ckbkFave = new CookbookFavouritePage();
        public CookbookRecentPage ckbkPersonal = new CookbookRecentPage();
        public CookbookPersonalPage ckbkRecent = new CookbookPersonalPage();

        //Edit subpage
        public Mod modification = new Mod();

        //Profile subpages


        private GlobalData()
        {
            // init fields of each recipe here
            // init fields of each page here
            //Page page = GlobalData.Instance.page1;
            //search = new SearchPage1();
            
            //Console.Write("TEST");
        }



        







    }
}
