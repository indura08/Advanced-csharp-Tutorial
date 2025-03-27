using TCPData;
using TCPExtension;

namespace ThePretendCompanyApplication_For_LINQ_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();

            var filteredEmployees = TCPExtension.Extension.Filter(employeeList, emp => emp.IsManager == true);

            foreach (var emp in filteredEmployees)
            {
                Console.WriteLine($"FirstName : {emp.FirstName}");
                Console.WriteLine($"FirstName : {emp.LastName}");
                Console.WriteLine($"FirstName : {emp.Annualsalary}");
                Console.WriteLine($"FirstName : {emp.IsManager}");

                Console.WriteLine();
            }

            //Console.ReadKey();

            //dan methna api krla tiynne apima extension method ekk hdgena eka use krnwa flter krnna enmployee or departments,
            //but with LINQ mewage apita one krna filter extension methods hdlama thiynwa apita ewa use krnna puluwan
            //example ekk widiyt pahatha linq query eka blnna

            List<Employee> employeList2 = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartment();

            var resultList = from emp in employeList2
                             join dept in departmentList
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 Department = dept.LongName
                             };

            foreach (var emp in resultList)
            {
                Console.WriteLine(emp.FirstName);
                Console.WriteLine(emp.Department);

                Console.WriteLine();
            }
        
        }
    }
}
