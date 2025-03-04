using ClubMembershipApplicationPracticeProject.Data;
using ClubMembershipApplicationPracticeProject.FieldValidators;
using ClubMembershipApplicationPracticeProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.Views
{
    public class UserLoginView : IView
    {
        ILogin _loginUser = null;

        public IFieldValidators FieldValidators => null;

        public UserLoginView(ILogin login)
        {
            _loginUser = login;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email address");
            string emailAddress = Console.ReadLine()!;

            Console.WriteLine("Please eneter your password");
            string password = Console.ReadLine()!;
            User user = _loginUser.Login(emailAddress, password);

            if (user != null)
            {
                WelcomeUserView welcomeUserView = new WelcomeUserView(user);
                welcomeUserView.RunView();
            }
            else 
            {
                Console.Clear();
                CommonOutputformat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credential that you have entered are either invalid or unavailable. Try again");
                Console.ReadKey();
            }
        }
    }
}
