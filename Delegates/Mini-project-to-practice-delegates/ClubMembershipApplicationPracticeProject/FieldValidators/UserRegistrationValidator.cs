using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.FieldValidators
{
    public class UserRegistrationValidator : IFieldValidators
    {
        const int FirstName_min_length = 2;
        const int FirstName_max_length = 50;
        const int LastName_min_length = 2;
        const int LasdtName_max_length = 50;

        delegate bool EmailExistsDelgate(string emailAddress);

        FieldValidatorDel _feildValidatorDel = null;
        
        public string FieldArray => throw new NotImplementedException();

        public FieldValidatorDel validatorDel => throw new NotImplementedException();

        public void InitialseValidatorDelegates()
        {
            throw new NotImplementedException();
        }
    }
}
