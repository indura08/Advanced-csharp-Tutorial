using ClubMembershipApplicationPracticeProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject.Data
{
    public interface ILogin
    {
        User Login(string emailAddress, string password);
    }
}
