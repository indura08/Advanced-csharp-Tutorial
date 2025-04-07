using Advanced_c__tutorial.Generics._1_Introduction.GenericsBasics;
using System.Collections;

namespace GenericsBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Salaries salaries = new Salaries();
            ArrayList salaryList = salaries.Getsalaries();

            float salary = (float)salaryList[1]!;
            //dan methandi arralist ekn salalryList[1] dunnama retunr krnne object type ekk , eki arraylist walal thiyna wasiay attama 
            //namuth eka magaharwa gnna puluwan type casting use krla , mehm krnwat wada attama lesi more generic type ekke wechcha List<T> use krnwa nm 

            salary = salary + (salary * 0.02f);
            Console.WriteLine("Salary: " + salary);

            //sort function, class ekt adlawa / generics lesson ekt adlawa
            Console.WriteLine();
            Console.WriteLine($"Sort lesson {Environment.NewLine}{new string('-', 12)}");

            //me example ekedi wenen egeric s use nokara sort algortihm eka use krna ek , blnna ekekdi apit aone type eken arry ek hdnna bha , obj type ekn hdnna one , mekn godak runtime errors walt lead wenna puluwan, elagata pahala thiyna exmaple ekn generic use krla kohomad wade lesiyen krganne kiyna eka thiynwa exmaple ekak ekkala objects apit aone krna type walin ehma hdla 
            SortArray sortarray1 = new SortArray();
            object[] arr = new object[] { 3, 2, 4, 1 };

            sortarray1.BubbleSort(arr);

            foreach (int item in arr)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            //example 2 

            Employee[] arr2 = new Employee[] { new Employee { Id = 1, Name = "Sandra"},
                                               new Employee { Id = 2, Name = "Piyumi"},
                                               new Employee { Id = 3, Name = "Arnold"},
                                               new Employee { Id = 4, Name = "Trent"},};
            sortarray1.BubbleSort(arr2);

            foreach (var item in arr2)
            {
                Console.WriteLine($"{item.Id}, {item.Name}");
            }

            //exmaple 2 - with generic Types

            Console.WriteLine();
            Console.WriteLine($"Sort lesson(Generic type) {Environment.NewLine}{new string('-', 25)}");

            //employee type example
            Employee2[] arr3Employee2 = new Employee2[] { new Employee2 { Id = 1},
                                                 new Employee2 { Id = 20},
                                                 new Employee2 { Id = 39},
                                                 new Employee2 { Id = 4}};

            SortArrayGenericClass<Employee2> sortArrayEmployee = new SortArrayGenericClass<Employee2>();
            sortArrayEmployee.BubbbleSort(arr3Employee2);

            foreach (Employee2 item in arr3Employee2)
            {
                Console.WriteLine($"{item.Id}, {item.CreatedAt}");
            }

            //integer type exmaple
            Console.WriteLine();

            int[] intArr = new int[] { 3, 2, 4, 1 };

            SortArrayGenericClass<int> sortArrayIneteger = new SortArrayGenericClass<int>();
            sortArrayIneteger.BubbbleSort(intArr);

            foreach (int n in intArr)
            {
                Console.Write($"{n}, ");
            }
        }
    }

    public class Employee : IComparable
    {
        //api ai Icompareble daanne?
        //mona property (attribute ekath ekkalada api compare krna dewal waldi compare krnne object dekk? methandi api deela thiynne Id deka compare krnna kiyla , eki mehma Icompareble interface ek daala eka setup krgnne s)
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int CompareTo(Object obj)
        {
            return this.Id.CompareTo(((Employee)obj).Id);
        }
    }

    public class Employee2 : IComparable<Employee2>  //menna meka thami ap[i sortarraygeneric class eke where T : Icomparable<T> kiyl damme, methna employee type ek dunnma meka compare rknne thwath employee type ekak ekkala withri, ekat support wenna one sortarraygerics class eke type eka 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CompareTo(Employee2? other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }

    public class Salaries
    {
        ArrayList _salaryList = new ArrayList();

        public Salaries()
        {
            _salaryList.Add(10000.34f);
            _salaryList.Add(20000.23f);
            _salaryList.Add(30000.57f);
        }

        public ArrayList Getsalaries()
        {
            return _salaryList;
        }
    }
}
