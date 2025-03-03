using ClubMembershipApplicationPracticeProject.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.Views
{
    public interface IView
    {
        void RunView();
        IFieldValidators FieldValidators { get; }
    }
}
