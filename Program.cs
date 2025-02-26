using Advanced_c__tutorial.Delegates;

namespace Advanced_c__tutorial
{
    internal class Program
    {
        delegate int MathFunction(int x, int y);
        static void Main(string[] args)
        {
            //example to prove that delegates can be applied to static methods
         //----------------------------------------------------------------------

            Delegates1.LogDel logDel = new Delegates1.LogDel(Delegates1.LogTextFile);
            //dan me api delegate1 class eke hdapu delegate ekt apita e delegate ek hdla thiyna widiyt galpena methods denna puluwan , dn methn deela tiynne LOgTxetToFile kiyna method ek
            
            //Console.WriteLine("Please enter your name");
            //var name = Console.ReadLine();
            
            //logDel(name);

            //Below codes are the example for delegates can be applied to instance methods
         //-----------------------------------------------------------------------------------
            Delegate2 delegate2ClassObject = new Delegate2();

            MathFunction mathfuncObject = new MathFunction(delegate2ClassObject.SumFunction);
            Console.WriteLine(mathfuncObject(3,4));

            //object ekk nohada menna mehma implement krnnath puluwan
            MathFunction mathfuncObject2 = delegate2ClassObject.SumFunction;
            Console.WriteLine(mathfuncObject2(50, 49));

        }
    }
}
