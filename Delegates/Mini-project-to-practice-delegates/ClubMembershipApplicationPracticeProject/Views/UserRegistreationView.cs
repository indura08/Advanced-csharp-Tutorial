using ClubMembershipApplicationPracticeProject.Data;
using ClubMembershipApplicationPracticeProject.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.Views
{
    public class UserRegistreationView : IView
    {
        IFieldValidators _fieldValidators = null;

        IRegister _register = null;

        public IFieldValidators FieldValidators { get => _fieldValidators; }

        public UserRegistreationView(IRegister register, IFieldValidators fieldValidators)
        {
            _fieldValidators = fieldValidators;
            _register = register;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteRegistrationheading();

            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.EmailAddress] = GetInputFromUser(FieldConstants.UserRegistrationField.EmailAddress, "Please enter your email address: ");
            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.FirstName] = GetInputFromUser(FieldConstants.UserRegistrationField.FirstName, "Please enter your firstName : ");
            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.LastName] = GetInputFromUser(FieldConstants.UserRegistrationField.LastName, "Please enter your LastName : ");
            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.Password] = GetInputFromUser(FieldConstants.UserRegistrationField.Password, $"Please enter your Password : {Environment.NewLine}(Your password must be containing at least 1 small-case, lettter, {Environment.NewLine}1 Capitalletter , 1 digit , a special charcters{Environment.NewLine} and the length should be between 6-10 characters )");
            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.PasswordCompare] = GetInputFromUser(FieldConstants.UserRegistrationField.PasswordCompare, "Please reenter your password: ");
            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.DateOfBirth] = GetInputFromUser(FieldConstants.UserRegistrationField.DateOfBirth, "Please enter your Date of birth: ");
            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.PhoneNumber] = GetInputFromUser(FieldConstants.UserRegistrationField.PhoneNumber, "Please enter your Phone number: ");
            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.Address] = GetInputFromUser(FieldConstants.UserRegistrationField.Address, "Please enter your address: ");
            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.PostCode] = GetInputFromUser(FieldConstants.UserRegistrationField.PostCode, "Please enter your Postal code: ");

            RegisterUser();
        
        }

        private void RegisterUser()
        {
            _register.Register(_fieldValidators.FieldArray);

            CommonOutputformat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine("You have successfully regsitered. PLease press any key to login");
            CommonOutputformat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
            //Console.ReadKey() pauses the program and waits for the user to press any key. When a key is pressed, the program continues execution.
        }

        private string GetInputFromUser(FieldConstants.UserRegistrationField field, string promptText)
        {
            string fieldVal = "";

            do
            {
                Console.Write(promptText);
                fieldVal = Console.ReadLine();
            } while (!FieldValid(field, fieldVal));

            return fieldVal;
        }

        private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue)
        {
            if (!_fieldValidators.validatorDel((int)field, fieldValue, _fieldValidators.FieldArray, out string invalidMessage))
            {
                CommonOutputformat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine(invalidMessage);
                CommonOutputformat.ChangeFontColor(FontTheme.Default);

                return false;
            }
            return true;
        }
    }
}
