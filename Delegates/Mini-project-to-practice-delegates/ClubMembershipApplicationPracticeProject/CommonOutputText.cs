using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplicationPracticeProject
{
    public class CommonOutputText
    {
        private static string MainHeading
        {
            get
            {
                string heading = "Cycle Club";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length+1)}";
            }
        }

        private static string RegistrationHeading
        {
            get 
            {
                string heading = "Register";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        private static string LoginHeading
        {
            get 
            {
                string heading = "Login";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        public static void WriteMainHeading()
        {
            Console.Clear();
            //Before calling Console.Clear(): The console might display some text or output from previous operations.
            //After calling Console.Clear(): The console window becomes empty, and any previous text or data is removed.

            Console.WriteLine(MainHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteLoginHeading()
        {
            Console.WriteLine(LoginHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteRegistrationheading()
        {
            Console.WriteLine(RegistrationHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
