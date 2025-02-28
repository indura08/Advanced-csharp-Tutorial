using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_c__tutorial.Delegates
{
    public class DelegateExample3
    {
        //multiclass deligate creation

        public delegate void MulticastDelgate(string message);

        public static void MulticastDelegateMethod1(string message)
        {
            Console.WriteLine($"This is method 1 and your message is {message}");
        }

        public static void MulticastDelegateMethod2(string message)
        {
            Console.WriteLine($"This is method 2 and your message is {message}");
        }
    }
}
