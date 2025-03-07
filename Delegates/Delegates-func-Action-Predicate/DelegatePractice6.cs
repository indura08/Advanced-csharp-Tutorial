using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_c__tutorial.Delegates.Delegates_func_Action_Predicate
{
    public class DelegatePractice6
    {
        //*********practicle example: action

        public static Action<int, string, string, decimal, char> DisplayEmployeeDetails = (arg1, arg2, arg3, arg4, arg5) => Console.WriteLine($"Id: {arg1} {Environment.NewLine}FirstName: {arg2}{Environment.NewLine}LastName:{Environment.NewLine}{arg3}Annual Salary: {arg4}{Environment.NewLine}Gender: {arg5}");

        //*******Predicate
        public List<Employee> employees = new List<Employee>();

        public List<Employee> FilterEmployee(List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> newList = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    newList.Add(employee);
                }
            }

            return newList;
        }

    }

    public class MathClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    public class Employee 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
    }
}
