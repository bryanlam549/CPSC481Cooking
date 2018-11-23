using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public class Ingredient
    {

        private enum Units // ~~~~~~~~NOTE: can remove some rare ones, could also group into 3 categories (Volume, Mass, Length)
        {
            TSP, TBSP, FLOZ, CUP, PINT, QUART, GALLON, ML, L, LB, OZ, MG, G, KG, MM, CM, M, IN
        }

        private string _name; 

        private double _measurement; // e.g. 1.5 cups would get converted into 1 1/2 cups (by a future function to add, double to string)

        private Units _standardUnit;

        private string _otherUnit; // e.g. 'head' of cabbage

        private bool _isUnitStandard = true;

        private bool _isChecked = false;


        public Ingredient()
        {
        }
    }
}
