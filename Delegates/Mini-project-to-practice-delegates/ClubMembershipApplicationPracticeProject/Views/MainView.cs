using ClubMembershipApplicationPracticeProject.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.Views
{
    public class MainView : IView
    {
        public IFieldValidators FieldValidators => throw new NotImplementedException();

        IView _registerView = null;
        IView _loginView = null;

        public MainView(IView registerView, IView loginView)
        {
            _registerView = registerView;
            _loginView = loginView;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            Console.WriteLine("Please press 'l' to login or if you are not yet registred please press 'r'");

            ConsoleKey key =Console.ReadKey().Key;

            if (key == ConsoleKey.R)
            {
                RunUserRegistartionView();
                RunLoginView();
            } else if(key == ConsoleKey.L)
            {
                RunLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("GoodBye Dan Palayan");
                Console.ReadKey();
            } 
        }

        private void RunUserRegistartionView()
        {
            _registerView.RunView();
        }

        private void RunLoginView()
        {
            _loginView.RunView();
        }
    }
}
