using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidationAPIClassLIbrary
{
    public delegate bool RequiredValidationDelegate(string fieldValue);
    public delegate bool StringLengthValidationDelegate(string fieldValue, int min, int max);
    public delegate bool DateValidationDelegate(string fieldValue, out DateTime validDateTime); //🔹 Normally, a method can return only one value. With out, you can return multiple values through method parameters.
    public delegate bool PatternMatchingDelegate(string fieldValue, string pattern);
    public delegate bool ComparefieldsValidationDelegate(string feildValue, string fieldValueCompare);
    public class CommonFieldValidatorFunction
    {
        private static RequiredValidationDelegate _requiredValidationdel = null;
        private static StringLengthValidationDelegate _stringLengthValidationdel = null;
        private static DateValidationDelegate _dateValidationdel = null;
        private static PatternMatchingDelegate _patternMatchindel = null;
        private static ComparefieldsValidationDelegate _compareFieldsValidationdel = null;


        //singleton pattern ek use krla api ensure krgnnwa me delegates walin hariytm eka instance eki hdnna puluwan kiyla
        public static RequiredValidationDelegate RequiredFieldValidationDelegate
        {
            get 
            {
                if (_requiredValidationdel == null)
                {
                    _requiredValidationdel = new RequiredValidationDelegate(RequiredFieldValidationDelegate);

                }

                return _requiredValidationdel;
            }
        }

        public static StringLengthValidationDelegate StringValidationDelegate
        {
            get
            {
                if (_stringLengthValidationdel == null)
                {
                    _stringLengthValidationdel = new StringLengthValidationDelegate(StringValidationDelegate);
                }
                return _stringLengthValidationdel;
            }
        
        }

        public static DateValidationDelegate DateValidationDelegate
        {
            get 
            {
                if (_dateValidationdel == null)
                {
                    _dateValidationdel = new DateValidationDelegate(DateValidationDelegate);
                }
                return _dateValidationdel;
            }
        }

        public static PatternMatchingDelegate PatternMatchingDelegate
        {
            get
            {
                if (_patternMatchindel == null)
                {
                    _patternMatchindel = new PatternMatchingDelegate(PatternMatchingDelegate);
                }
                return _patternMatchindel;
            }
        }

        public static ComparefieldsValidationDelegate ComparefieldValidationDelegate
        {
            get
            {
                if (_compareFieldsValidationdel == null)
                {
                    _compareFieldsValidationdel = new ComparefieldsValidationDelegate(ComparefieldValidationDelegate);
                }
                return _compareFieldsValidationdel;
            }
        }

        //method implementations

        private static bool RequiredFiedlValidatorMethod(string fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldValue))
            {
                return true;
            }
            else 
            {
                return false;
            }
                
        }

        private static bool StringFieldLengthValidationMethod(string fieldValue, int min, int max)
        {
            if (fieldValue.Length >= min && fieldValue.Length <= max)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private static bool DatefieldValidationMehtod(string dateTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(dateTime, out validDateTime)) return true;
            else return false;
        }

        private static bool FieldPatternMatchingMethod(string fielValue, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);

            if (regex.IsMatch(fielValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool fieldComparisionValidationMethod(string field1, string field2)
        {
            if (field1.Equals(field2))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
