using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Cookbook
{
    public class Ingredient
    {

        // VOLUME:
        public const string CUPS = "Cups";
        public const string FLOZ = "Fl. oz.";
        public const string ML = "mL";
        public const string L = "L";
        public const string TBSP = "Tbsp.";
        public const string TSP = "tsp.";

        // MASS:
        public const string G = "g";
        public const string KG = "kg";
        public const string LBS = "lbs.";
        public const string MG = "mg";
        public const string OZ = "oz.";

        // LENGTH:
        public const string CM = "cm";
        public const string IN = "in.";
        public const string M = "m";
        public const string MM = "mm";



        public enum UnitType
        {
            NONE, SPECIAL, VOLUME, MASS, LENGTH
        }


        

        public double _measurement; // e.g. 1.5

        public string _measurementStr; // e.g. 1/2

        public UnitType _unitType;

        public string _unitStr; // starting unit text can be hardcoded (this is text that goes in combobox at start or in specialtext)

        public string _mainText;

        public List<string> _substitutions;

       

        // -==-=-=-=-=-=-=-=
        public bool _isChecked = false;

        public bool _hasStandardUnit = false; // if true, then the unitChanger will be visible...

        public bool _hasSpecialUnit = false; // if true then the specialText will be visible...

        //public string _primaryStr;

        //public string _secondaryStr; // won't display if _hasUnit == false

        public Ingredient()
        {

        }


        public Ingredient(double measurement, string measurementStr, UnitType unitType, string unitStr, string mainText, List<string> substitutions)
        {
            _measurement = measurement;
            _measurementStr = measurementStr;
            _unitType = unitType;
            _unitStr = unitStr;
            _mainText = mainText;
            _substitutions = substitutions;

            // make sure this gets called after the constructor initialization list
            if (_unitType == UnitType.VOLUME || _unitType == UnitType.MASS || _unitType == UnitType.LENGTH)
            {
                _hasStandardUnit = true;
            }
            else if (_unitType == UnitType.SPECIAL)
            {
                _hasSpecialUnit = true;
            }


            


            /*
            // ~~~~~~~~init measurementStr from measurement
            if (_hasUnit)
            {
                _primaryStr = _measurementStr;
                _secondaryStr = _mainText;
            }
            else
            {
                _primaryStr = _measurementStr + " " + _mainText;
                _secondaryStr = "";
            }
            */
        }


        public void convertMeasurement(string newUnitStr)
        {
            // 1. convert current unit to cups (if volume)
            // 1. convert current unit to kg (if mass)
            // 1. convert current unit to cm (if length)

            if (_unitType == UnitType.VOLUME)
            {
                convertVolumeMeasurement(newUnitStr);
            }
            else if (_unitType == UnitType.MASS)
            {
                convertMassMeasurement(newUnitStr);
            }
            else if (_unitType == UnitType.LENGTH)
            {
                convertLengthMeasurement(newUnitStr);
            }


        }

        private void convertVolumeMeasurement(string newUnitStr)
        {
            // 1. convert curent measurement value to cups first

            double interMeasurement = 0;

            switch(_unitStr) // lookup current units by string
            {
                case CUPS:
                    interMeasurement = _measurement;
                    break;
                case FLOZ:
                    interMeasurement = 0.125 * _measurement;
                    break;
                case ML:
                    interMeasurement = 0.00422675 * _measurement;
                    break;
                case L:
                    interMeasurement = 4.22675 * _measurement;
                    break;
                case TBSP:
                    interMeasurement = 0.0625 * _measurement;
                    break;
                case TSP:
                    interMeasurement = 0.0208333 * _measurement;
                    break;
            }

            // 2. now convert from cups to desired new unit...
            double newMeasurement = 0;

            switch (newUnitStr) // lookup new units by string
            {
                case CUPS:
                    newMeasurement = interMeasurement;
                    break;
                case FLOZ:
                    newMeasurement = 8 * interMeasurement;
                    break;
                case ML:
                    newMeasurement = 236.588 * interMeasurement;
                    break;
                case L:
                    newMeasurement = 0.236588 * interMeasurement;
                    break;
                case TBSP:
                    newMeasurement = 16 * interMeasurement;
                    break;
                case TSP:
                    newMeasurement = 48 * interMeasurement;
                    break;
            }

            // 3. update measurement value
            _measurement = newMeasurement;

            // update unitStr

            _unitStr = newUnitStr;

            // 4. update measurementStr

            updateMeasurementStr();


        }

        private void convertMassMeasurement(string newUnitStr)
        {
            // 1. convert to kg first

            //Debug.WriteLine("HEREIAM");
            //Debug.WriteLine(_measurement);

            double interMeasurement = 0;

            switch (_unitStr) // lookup current units by string
            {
                case G:
                    interMeasurement = 0.001 * _measurement;
                    break;
                case KG:
                    interMeasurement = _measurement;
                    break;
                case LBS:
                    interMeasurement = 0.453592 * _measurement;
                    break;
                case MG:
                    interMeasurement = 0.000001 * _measurement;
                    break;
                case OZ:
                    interMeasurement = 0.0283495 * _measurement;
                    break;
            }

            //Debug.WriteLine(interMeasurement);

            // 2. now convert from kg to desired new unit...
            double newMeasurement = 0;

            switch (newUnitStr) // lookup new units by string
            {
                case G:
                    newMeasurement = 1000 * interMeasurement;
                    break;
                case KG:
                    newMeasurement = interMeasurement;
                    break;
                case LBS:
                    newMeasurement = 2.20462 * interMeasurement;
                    break;
                case MG:
                    newMeasurement = 1000000 * interMeasurement;
                    break;
                case OZ:
                    newMeasurement = 35.274 * interMeasurement;
                    break;
            }

            // 3. update measurement value
            _measurement = newMeasurement;

            // update unitStr

            _unitStr = newUnitStr;

            // 4. update measurementStr

            updateMeasurementStr();

        }

        private void convertLengthMeasurement(string newUnitStr)
        {

            // 3. convert to cm first

            double interMeasurement = 0;

            switch (_unitStr) // lookup current units by string
            {
                case CM:
                    interMeasurement = _measurement;
                    break;
                case IN:
                    interMeasurement = 2.54 * _measurement;
                    break;
                case M:
                    interMeasurement = 100 * _measurement;
                    break;
                case MM:
                    interMeasurement = 0.1 * _measurement;
                    break;
            }

            // 2. now convert from cm to desired new unit...
            double newMeasurement = 0;

            switch (newUnitStr) // lookup new units by string
            {
                case CM:
                    newMeasurement = interMeasurement;
                    break;
                case IN:
                    newMeasurement = 0.393701 * interMeasurement;
                    break;
                case M:
                    newMeasurement = 0.01 * interMeasurement;
                    break;
                case MM:
                    newMeasurement = 10 * interMeasurement;
                    break;
            }

            // 3. update measurement value
            _measurement = newMeasurement;

            // update unitStr

            _unitStr = newUnitStr;

            // 4. update measurementStr

            updateMeasurementStr();

        }

        public void updateMeasurementStr()
        {

            /*
            if (_unitType == UnitType.NONE)
            {
                _measurementStr = "";
                return;
            }
            */

            if (_measurementStr.Equals(""))
            {
                return;
            }

            // take new _measurement value, convert to either fractional form (or decimal form if small)

            //Debug.WriteLine(_measurement);

            double lowThreshold = (double) 1 / 16;

            double highThreshold = 100.0;

            double superHighThreshold = 10000.0;


            if (_measurement >= superHighThreshold)
            {
                _measurementStr = ">10000";
            }
            else if (_measurement >= highThreshold)
            {
                _measurementStr = Math.Round(_measurement).ToString();
            }
            else if (_measurement >= lowThreshold)
            {
                // convert to fractional form
                _measurementStr = convertDoubleToFraction(_measurement);
            }
            else
            {
                // just round double to 1 sig dig and use its toString
                _measurementStr = "< 1/16";
            }

        }



        // only use this when value >= 1/16
        private string convertDoubleToFraction(double value)
        {
            string unitTerm;
            string fracTerm = "";

            int unitPart = (int) Math.Floor(value);
            double fracPart = value - unitPart;

            // now see which fraction value the fracPart is closest to...

            // WE NEED MORE FRACTIONS! 
            // 1
            // 1/2
            // 1/3, 2/3
            // 1/4, 3/4
            // 1/5, 2/5, 3/5, 4/5
            // 1/6, 5/6
            // 1/8, 3/8, 5/8, 7/8
            // 1/16, 3/16, 5/16, 7/16, 9/16, 11/16, 13/16, 15/16

            double _0 = 0.0; // lower bound
            double _1 = 1.0; // upper bound
            double _1_2 = 0.5;
            double _1_3 = (double)1 / 3;
            double _2_3 = (double)2 / 3;
            double _1_4 = 0.25;
            double _3_4 = 0.75;
            double _1_5 = 0.2;
            double _2_5 = 0.4;
            double _3_5 = 0.6;
            double _4_5 = 0.8;
            double _1_6 = (double)1 / 6;
            double _5_6 = (double)5 / 6;
            double _1_8 = 0.125;
            double _3_8 = 0.375;
            double _5_8 = 0.625;
            double _7_8 = 0.875;
            double _1_16 = 0.0625;
            double _3_16 = 0.1875;
            double _5_16 = 0.3125;
            double _7_16 = 0.4375;
            double _9_16 = 0.5625;
            double _11_16 = 0.6875;
            double _13_16 = 0.8125;
            double _15_16 = 0.9375;

            List<double> fractions = new List<double> { _0, _1, _1_2, _1_3, _2_3, _1_4, _3_4, _1_5, _2_5, _3_5, _4_5, _1_6,_5_6, _1_8, _3_8, _5_8, _7_8, _1_16, _3_16, _5_16, _7_16, _9_16, _11_16, _13_16, _15_16};
            double closest = fractions.Aggregate((x, y) => Math.Abs(x - fracPart) < Math.Abs(y - fracPart) ? x : y);

            if (Math.Abs(closest - _0) < 0.0001) { fracTerm = ""; }
            else if (Math.Abs(closest - _1) < 0.0001) { unitPart++; fracTerm = ""; }
            else if (Math.Abs(closest - _1_2) < 0.0001) { fracTerm = "1/2"; }
            else if (Math.Abs(closest - _1_3) < 0.0001) { fracTerm = "1/3"; }
            else if (Math.Abs(closest - _2_3) < 0.0001) { fracTerm = "2/3"; }
            else if (Math.Abs(closest - _1_4) < 0.0001) { fracTerm = "1/4"; }
            else if (Math.Abs(closest - _3_4) < 0.0001) { fracTerm = "3/4"; }
            else if (Math.Abs(closest - _1_5) < 0.0001) { fracTerm = "1/5"; }
            else if (Math.Abs(closest - _2_5) < 0.0001) { fracTerm = "2/5"; }
            else if (Math.Abs(closest - _3_5) < 0.0001) { fracTerm = "3/5"; }
            else if (Math.Abs(closest - _4_5) < 0.0001) { fracTerm = "4/5"; }
            else if (Math.Abs(closest - _1_6) < 0.0001) { fracTerm = "1/6"; }
            else if (Math.Abs(closest - _5_6) < 0.0001) { fracTerm = "5/6"; }
            else if (Math.Abs(closest - _1_8) < 0.0001) { fracTerm = "1/8"; }
            else if (Math.Abs(closest - _3_8) < 0.0001) { fracTerm = "3/8"; }
            else if (Math.Abs(closest - _5_8) < 0.0001) { fracTerm = "5/8"; }
            else if (Math.Abs(closest - _7_8) < 0.0001) { fracTerm = "7/8"; }
            else if (Math.Abs(closest - _1_16) < 0.0001) { fracTerm = "1/16"; }
            else if (Math.Abs(closest - _3_16) < 0.0001) { fracTerm = "3/16"; }
            else if (Math.Abs(closest - _5_16) < 0.0001) { fracTerm = "5/16"; }
            else if (Math.Abs(closest - _7_16) < 0.0001) { fracTerm = "7/16"; }
            else if (Math.Abs(closest - _9_16) < 0.0001) { fracTerm = "9/16"; }
            else if (Math.Abs(closest - _11_16) < 0.0001) { fracTerm = "11/16"; }
            else if (Math.Abs(closest - _13_16) < 0.0001) { fracTerm = "13/16"; }
            else if (Math.Abs(closest - _15_16) < 0.0001) { fracTerm = "15/16"; }

            unitTerm = unitPart >= 1 ? unitPart.ToString() : "";

            string fullTerm = unitTerm + " " + fracTerm;

            return fullTerm;

        }

        

    }

}
