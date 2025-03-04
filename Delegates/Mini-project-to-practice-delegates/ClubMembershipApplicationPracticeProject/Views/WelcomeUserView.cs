using ClubMembershipApplicationPracticeProject.FieldValidators;
using ClubMembershipApplicationPracticeProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.Views
{
    public class WelcomeUserView : IView
    {
        User _user = null;

        public WelcomeUserView(User user)
        {
            _user = user;
        }
        public IFieldValidators FieldValidators => null;

        public void RunView()
        {
            Console.Clear();
            CommonOutputText.WriteMainHeading();

            CommonOutputformat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"HI {_user.FirstName}!!{Environment.NewLine}Welcome to the Cycling Club!!");
            CommonOutputformat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }
    }
}
