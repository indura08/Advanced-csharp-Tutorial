using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_c__tutorial.Delegates
{
    public class DelegateExample4
    {
        // how delegate canbe passed as a argument to a method

        public delegate void DelegateAsArgument(string message);

        public static void Method1(DelegateAsArgument arg1, string message)
        {
            arg1(message);
        }

        public static void HelperMethod(string message)
        {
            Console.WriteLine($"your message is : {message}");
        }
    }
}
