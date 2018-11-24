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

        public Recipe recipe1 = new Recipe(); // something like this, then each component like a HeartButton could have a field set to 1 recipe.
        public Recipe recipe2 = new Recipe();

        public Page page1 = new Page();
        public SearchPage1 search;

        
        
        private GlobalData()
        {
            // init fields of each recipe here
            // init fields of each page here

            
            
            Page page = GlobalData.Instance.page1;
            search = new SearchPage1();
            
            //Console.Write("TEST");
        }



        







    }
}
