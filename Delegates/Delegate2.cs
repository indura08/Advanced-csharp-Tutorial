using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_c__tutorial.Delegates
{
    internal class Delegate2
    {
        delegate int MathFunctions(int x, int y);

        public int SumFunction(int n1, int n2)
        {
            return n1+n2;
        }
    }
}
