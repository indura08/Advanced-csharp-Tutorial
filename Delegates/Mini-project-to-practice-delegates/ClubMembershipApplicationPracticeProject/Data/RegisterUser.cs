using ClubMembershipApplicationPracticeProject.FieldValidators;
using ClubMembershipApplicationPracticeProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExists(string emailAddress)
        {
            bool emailExist = false;

            using (var dbContext = new AppDBContext())
            {
                emailExist = dbContext.Users.Any(u => u.EmailAddress.ToLower().Trim() == emailAddress.Trim().ToLower());
            }
            return emailExist;
        }

        public bool Register(string[] fields)
        {
            using (var dbContext = new AppDBContext())
            {
                User user = new User
                {
                    EmailAddress = fields[(int)FieldConstants.UserRegistrationField.EmailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldConstants.UserRegistrationField.Password],
                    
                    DateofBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationField.DateOfBirth]), 
                    //DateTime.Parse is a method used in C# to convert a string (which represents a date and time) into a DateTime object, which can be used to perform date and time operations.
                    
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationField.PhoneNumber],
                    Address = fields[(int)FieldConstants.UserRegistrationField.Address],
                    PostCode = fields[(int)FieldConstants.UserRegistrationField.PostCode],

                };

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            return true;
        }
    }
}
