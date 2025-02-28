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


            //multicast delegate testing
            //------------------------------------

            DelegateExample3.MulticastDelgate multiMethodDelgate = new DelegateExample3.MulticastDelgate(DelegateExample3.MulticastDelegateMethod1);
            multiMethodDelgate += DelegateExample3.MulticastDelegateMethod2;

            multiMethodDelgate("Indura perera");

            //e wagemawena wena delegate dekk hdla e deka ekathu krla aluth delagte ekkt dennath puluwan

            DelegateExample3.MulticastDelgate delagte1 = new DelegateExample3.MulticastDelgate(DelegateExample3.MulticastDelegateMethod1);
            DelegateExample3.MulticastDelgate delagte2 = new DelegateExample3.MulticastDelgate(DelegateExample3.MulticastDelegateMethod2);

            DelegateExample3.MulticastDelgate multiDelegateDelegate = delagte1 + delagte2;

            multiDelegateDelegate("Eliana Vivienne");

            //Passing delegate as an argument for another method
            //------------------------------------------------------

            DelegateExample4.DelegateAsArgument delegateAsArguement = new DelegateExample4.DelegateAsArgument(DelegateExample4.HelperMethod);

            DelegateExample4.Method1(delegateAsArguement, "Hello there 'Delegate as arguement class :)");

        }
    }
}
