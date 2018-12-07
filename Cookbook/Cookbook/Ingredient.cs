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
            NONE, VOLUME, MASS, LENGTH
        }

        /*
        public enum VolumeUnits
        {
            NONE, TSP, TBSP, FLOZ, CUP, ML, L
        }

        public enum MassUnits
        {
            NONE, LB, OZ, MG, G, KG
        }

        public enum LengthUnits
        {
            NONE, MM, CM, M, INCH
        }
        */
        

        // ~~~~~~~~NOTE: say scaling ends up with something like 1.73682, just use 1.7 if it cant be converted into fractional string form

        public double _measurement; // e.g. 1.5

        public string _measurementStr; // e.g. 1/2

        public UnitType _unitType;

        public string _unitStr; // starting unit text can be hardcoded

        public string _mainText;

        //public VolumeUnits _volUnit = VolumeUnits.NONE;

        //public MassUnits _massUnit = MassUnits.NONE;

        //public LengthUnits _lengthUnit = LengthUnits.NONE;



        //public Units _standardUnit;

        //public string _otherUnit; // e.g. 'head' of cabbage

        //public bool _isUnitStandard = true;


        

        public bool _isChecked = false;

        public bool _hasUnit = false; // if true, then the unitChanger will be visible...

        public string _primaryStr;

        public string _secondaryStr; // won't display if _hasUnit == false

        public Ingredient()
        {

        }


        public Ingredient(double measurement, string measurementStr, UnitType unitType, string unitStr, string mainText)
        {
            _measurement = measurement;
            _measurementStr = measurementStr;
            _unitType = unitType;
            _unitStr = unitStr;
            _mainText = mainText;

            // make sure this gets called after the constructor initialization list
            if (_unitType != UnitType.NONE)
            {
                _hasUnit = true;
            }
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

            // 2. now convert from kg to desired new unit...
            double newMeasurement = 0;

            switch (newUnitStr) // lookup new units by string
            {
                case G:
                    interMeasurement = 1000 * _measurement;
                    break;
                case KG:
                    interMeasurement = _measurement;
                    break;
                case LBS:
                    interMeasurement = 2.20462 * _measurement;
                    break;
                case MG:
                    interMeasurement = 1000000 * _measurement;
                    break;
                case OZ:
                    interMeasurement = 35.274 * _measurement;
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
                    interMeasurement = _measurement;
                    break;
                case IN:
                    interMeasurement = 0.393701 * _measurement;
                    break;
                case M:
                    interMeasurement = 0.01 * _measurement;
                    break;
                case MM:
                    interMeasurement = 10 * _measurement;
                    break;
            }

            // 3. update measurement value
            _measurement = newMeasurement;

            // update unitStr

            _unitStr = newUnitStr;

            // 4. update measurementStr

            updateMeasurementStr();

        }

        private void updateMeasurementStr()
        {
            // take new _measurement value, convert to either fractional form (or decimal form if small)

            double threshold = 1 / 16;

            if (_measurement >= threshold)
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

            Debug.WriteLine(value);


            string unitTerm;
            string fracTerm;

            int unitPart = (int) Math.Floor(value);

            Debug.WriteLine(unitPart);

            double fracPart = value - unitPart;

            Debug.WriteLine(fracPart);


            // now see which fraction value the fracPart is closest to...


            // 15/16, 7/8, 13/16, 3/4, 11/16, 5/8, 9/16, 1/2, 7/16, 3/8, 5/16, 1/4, 3/16, 1/8, 1/16

            double _15_16 = (double) 15 / 16;
            double _7_8 = (double) 7 / 8;
            double _13_16 = (double) 13 / 16;
            double _3_4 = (double) 3 / 4;
            double _11_16 = (double) 11 / 16;
            double _5_8 = (double) 5 / 8;
            double _9_16 = (double) 9 / 16;
            double _1_2 = (double) 1 / 2;
            double _7_16 = (double) 7 / 16;
            double _3_8 = (double) 3 / 8;
            double _5_16 = (double) 5 / 16;
            double _1_4 = (double) 1 / 4;
            double _3_16 = (double) 3 / 16;
            double _1_8 = (double) 1 / 8;
            double _1_16 = (double) 1 / 16;

            double _1_32 = (double) 1 / 32; // for rounding...

            if (fracPart > _15_16 + _1_32) // rounds up to next int (no frac term)
            {

                Debug.WriteLine("HERE");

                unitPart++;
                fracTerm = "";
            }
            else if (fracPart > _7_8 + _1_32)
            {
                fracTerm = "15/16";
            }
            else if (fracPart > _13_16 + _1_32)
            {
                fracTerm = "7/8";
            }
            else if (fracPart > _3_4 + _1_32)
            {
                fracTerm = "13/16";
            }
            else if (fracPart > _11_16 + _1_32)
            {
                fracTerm = "3/4";
            }
            else if (fracPart > _5_8 + _1_32)
            {
                fracTerm = "11/16";
            }
            else if (fracPart > _9_16 + _1_32)
            {
                fracTerm = "5/8";
            }
            else if (fracPart > _1_2 + _1_32)
            {
                fracTerm = "9/16";
            }
            else if (fracPart > _7_16 + _1_32)
            {
                fracTerm = "1/2";
            }
            else if (fracPart > _3_8 + _1_32)
            {
                fracTerm = "7/16";
            }
            else if (fracPart > _5_16 + _1_32)
            {
                fracTerm = "3/8";
            }
            else if (fracPart > _1_4 + _1_32)
            {
                fracTerm = "5/16";
            }
            else if (fracPart > _3_16 + _1_32)
            {
                fracTerm = "1/4";
            }
            else if (fracPart > _1_8 + _1_32)
            {
                fracTerm = "3/16";
            }
            else if (fracPart > _1_16 + _1_32)
            {
                fracTerm = "1/8";
            }
            else if (fracPart > _1_32)
            {
                fracTerm = "1/16";
            }
            else
            {
                fracTerm = "";
            }

            // BUG: unitPart being set to 2...

            Debug.WriteLine(unitPart);

            //Debug.WriteLine(unitPart.ToString());

            unitTerm = unitPart >= 1 ? unitPart.ToString() : "";

            //Debug.WriteLine(unitTerm);

            string fullTerm = unitTerm + " " + fracTerm;

            return fullTerm;

        }


    }

}
