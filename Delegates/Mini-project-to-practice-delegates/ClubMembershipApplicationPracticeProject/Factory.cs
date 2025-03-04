using ClubMembershipApplicationPracticeProject.Data;
using ClubMembershipApplicationPracticeProject.Views;
using ClubMembershipApplicationPracticeProject.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject
{
    public static class Factory
    {
        public static IView GetMainViewObject()
        {
            ILogin login = new LoginUser();
            IRegister register = new RegisterUser();

            IFieldValidators userRegistrationValidator = new UserRegistrationValidator(register);
            userRegistrationValidator.InitialseValidatorDelegates();

            IView registerView = new UserRegistreationView(register, userRegistrationValidator);
            IView loginView = new UserLoginView(login);
            IView mainView = new MainView(registerView, loginView);

            return mainView;
        }
    }
}
