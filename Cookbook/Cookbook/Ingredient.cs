using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook
{
    public class Ingredient
    {

        public enum Units // ~~~~~~~~NOTE: can remove some rare ones, could also group into 3 categories (Volume, Mass, Length)
        {
            TSP, TBSP, FLOZ, CUP, PINT, QUART, GALLON, ML, L, LB, OZ, MG, G, KG, MM, CM, M, IN
        }

        public string _name; 

        public double _measurement; // e.g. 1.5 cups would get converted into 1 1/2 cups (by a future function to add, double to string)

        public Units _standardUnit;

        public string _otherUnit; // e.g. 'head' of cabbage

        public bool _isUnitStandard = true;

        public bool _isChecked = false;


        public Ingredient()
        {
        }
    }
}
