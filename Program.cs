using Advanced_c__tutorial.Delegates;
using Advanced_c__tutorial.Delegates.Delegate_Asynchronous_method_calls;
using Advanced_c__tutorial.Delegates.Delegate_Covariance_and_Contravariance;
using Advanced_c__tutorial.Delegates.Delegates_func_Action_Predicate;
using System.Net;

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
            Console.WriteLine();

            //Convariance and contravariance lesson
          //---------------------------------------------

            Console.WriteLine($"Covariance and Contravariance{Environment.NewLine}{new string('-', 30)}");

            DelegateExample5.CarFactorydelegate carFactoryDelegate = CarFactory.ReturnEVCar;
            Car iceCar = carFactoryDelegate(1, "Porsche");

            Console.WriteLine($"Object Type : {iceCar.GetType}");
            Console.WriteLine($"Car details: {iceCar.GetCarDetails()}");

            Console.WriteLine();

            //func-Action-Predicate
        //-----------------------------

            Console.WriteLine($"Func-Action-Predicate{Environment.NewLine}{new string('-', 30)}");

            //******** func

            MathClass mathclass = new MathClass();

            Func<int, int, int> calculate = mathclass.Sum;
            //methna int 3 k thiynne palaweni int deka parameter type ekt , anthima 3 weni int ek awilla return type ek 
            
            int result = calculate(3, 11);
            Console.WriteLine($"result is : {result}");
            
            Func<int , int , int> cal2 = (a, b) => a + b;
            //mehma anonymous function ekak define krnnath puluwan

            Console.WriteLine();

            //********Action

            DelegatePractice6.DisplayEmployeeDetails(1, "Eliana", "Vivienne", 75000, 'M');

            //******Predicate
            Console.WriteLine();

            DelegatePractice6 employeeScene = new DelegatePractice6();

            employeeScene.employees.Add(new Employee { Id = 1, FirstName = "Eliana vivienne", LastName = "Pererra", AnnualSalary = 60000, IsManager = false });
            employeeScene.employees.Add(new Employee { Id = 2, FirstName = "Eliana vivienne", LastName = "Auntie", AnnualSalary = 80000, IsManager = true });
            employeeScene.employees.Add(new Employee { Id = 3, FirstName = "Eliana vivienne", LastName = "Mom", AnnualSalary = 450000, IsManager = true });
            employeeScene.employees.Add(new Employee { Id = 4, FirstName = "Eliana vivienne", LastName = "Cousin Sister", AnnualSalary = 6000, IsManager = false });

            List<Employee> EmployeeFilter = employeeScene.FilterEmployee(employeeScene.employees, e => e.AnnualSalary > 75000);

            foreach (Employee employee1 in EmployeeFilter)
            {
                Console.WriteLine($"Id: {employee1.Id}{Environment.NewLine}First Name: {employee1.FirstName}{Environment.NewLine}Last name:{employee1.LastName}{Environment.NewLine}Annual Salary: {employee1.AnnualSalary}{Environment.NewLine}IsManager: {employee1.IsManager}");
            }

            //delagte example-7 async operations with delegates
            Console.WriteLine($"Delegate example: 7 async operations with delegates{Environment.NewLine}{new string('-', 30)}");

            // Create the delegate that will process the results of the
            // asynchronous request.
            AsyncCallback callBack = new AsyncCallback(DelegateExample7.ProcessDnsInformation);
            string host;

            do
            {
                Console.WriteLine(" Enter the name of a computer or <enter> to finish");
                host = Console.ReadLine();

                if (host.Length > 0)
                {
                    //increment request counter in theradsafe manner
                    Interlocked.Increment(ref DelegateExample7.requestCounter);
                    //start the asyncchronous request for dns information
                    Dns.BeginGetHostEntry(host, callBack, host);
                }
            } while (host.Length > 0);

            //// The user has entered all of the host names for lookup.
            // Now wait until the threads complete.

            while (DelegateExample7.requestCounter > 0)
            {
                DelegateExample7.UpdateUserInterface();
            }

            //display the results
            for (int i = 0; i < DelegateExample7.hostNames.Count; i++)
            {
                object data = DelegateExample7.hostData[i];
                string message = data as string;

                if (message != null)
                {
                    Console.WriteLine($"Request for {DelegateExample7.hostNames[i]} returned message: {message}");
                    continue;
                }

                // Get the results.
                IPHostEntry h = (IPHostEntry)data;
                string[] aliases = h.Aliases;
                IPAddress[] addresses = h.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine($"Aliases for {DelegateExample7.hostNames[i]}");
                    for (int j = 0; j < aliases.Length; j++)
                    {
                        Console.WriteLine($"{aliases[j]}");
                    }
                }
                if (addresses.Length > 0)
                {
                    Console.WriteLine($"Addresses for {DelegateExample7.hostNames[i]}");
                    for (int k = 0; k < addresses.Length; k++)
                    {
                        Console.WriteLine("{0}", addresses[k].ToString());
                    }
                }
            }

        }
    }
}
