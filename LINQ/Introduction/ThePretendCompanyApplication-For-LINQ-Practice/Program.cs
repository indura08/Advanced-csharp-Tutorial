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

            Console.ReadKey();
        
        }
    }
}
