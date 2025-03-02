using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplicationPracticeProject.Data;
using FieldValidationAPIClassLIbrary;

namespace ClubMembershipApplicationPracticeProject.FieldValidators
{
    public class UserRegistrationValidator : IFieldValidators
    {
        const int FirstName_min_length = 2;
        const int FirstName_max_length = 50;
        const int LastName_min_length = 2;
        const int LasdtName_max_length = 50;

        delegate bool EmailExistsDelgate(string emailAddress);

        FieldValidatorDel _fieldValidatorDel = null;

        RequiredValidationDelegate _requiredValidationDelegate = null;
        StringLengthValidationDelegate _stringLengthValidationDelegate = null;
        DateValidationDelegate _dateValidationDelegate = null;
        PatternMatchingDelegate _patternMatchingdelegate = null;
        ComparefieldsValidationDelegate _compareFieldsdValidationDelegate = null;

        EmailExistsDelgate _emailExisitDelegate = null;

        string[] _fieldArray = null;
        IRegister _register = null;

        public string[] FieldArray
        {
            get 
            {
                if (_fieldArray == null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                }
                return _fieldArray;
            }
        }

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

        public UserRegistrationValidator(IRegister register)
        {
            _register = register;
        }

        public FieldValidatorDel validatorDel => throw new NotImplementedException();

        public void InitialseValidatorDelegates()
        {
            throw new NotImplementedException();
        }

        private bool ValidateFields(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = "";

            FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;
            //me uda code ekn wenne fieldConstantClass eke thiyna enum type ekk hold krna variable ekk thami userRegistrationField kiynne
            //ethkot meka enum class eke value ekk hold krnwa , e value ek denne casting widiyt
            //casting kiynne : (FieldConstants.UserRegistrationField)fieldIndex; This is casting((type)value) fieldIndex to FieldConstants.UserRegistrationField. It means fieldIndex is an integer, and we are converting it into an enum value

            switch(userRegistrationField)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    fieldInvalidMessage = (!_requiredValidationDelegate(fieldValue)) ? $"You Must entera value for field : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchingdelegate(fieldValue, CommonRegularExpressionValidationPatterns.Email_Address_RegEx_Pattern)) ? $"You must enter a valid email address{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = (fieldInvalidMessage == "" && _emailExisitDelegate(fieldValue)) ? $"this email address already exists. Please try again {Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!_requiredValidationDelegate(fieldValue)) ? $"Youe must enter a value to : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && _stringLengthValidationDelegate(fieldValue, FirstName_min_length, FirstName_max_length)) ? $"The length for field : {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {FirstName_min_length} and {FirstName_max_length}{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!_requiredValidationDelegate(fieldValue)) ? $"you must enter a value for {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidationDelegate(fieldValue, LastName_min_length, LasdtName_max_length)) ? $"The length of the field {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)} must be between {LastName_min_length} and {LasdtName_max_length}{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = (!_requiredValidationDelegate(fieldValue)) ? $"You must enter a value for {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchingdelegate(fieldValue, CommonRegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern)) ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6 - 10 characters{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldConstants.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = (!_requiredValidationDelegate(fieldValue)) ? $"You must enter a value for the field {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareFieldsdValidationDelegate(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationField.Password])) ? $"Your entry did not match your password{Environment.NewLine}" : fieldInvalidMessage;
                    break;


                    //methna idla blnna heta 


            }
        }
    }
}
