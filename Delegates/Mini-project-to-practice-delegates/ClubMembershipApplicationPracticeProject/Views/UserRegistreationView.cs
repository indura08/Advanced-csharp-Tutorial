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

            _fieldValidators.FieldArray[(int)FieldConstants.UserRegistrationField.EmailAddress] = GetInputFromUser();
        
            //todo - meka completed nah , complete krnna 
            //meka 2 weniyt krnna 1 thiynne pahala
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

        private bool FieldValid(FieldConstants.UserRegistrationField, string fieldValue)
        {
            //mewa implement krnna thiynwa 
            //mekan patan ganna meka 1 
            return true;
        }
    }
}
