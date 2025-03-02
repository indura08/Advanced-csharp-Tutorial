using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.FieldValidators
{
    public class FieldConstants
    {
        public enum UserRegistrationField
        {
            EmailAddress,       //0
            FirstName,          //1
            LastName,           //2
            Password,           //3
            PasswordCompare,    //4
            DateOfBirth,        //5
            PhoneNumber,        //6
            Address,            //7
            PostCode            //8

        }
    }
}
