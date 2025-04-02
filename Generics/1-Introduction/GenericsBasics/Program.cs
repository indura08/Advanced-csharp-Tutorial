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
