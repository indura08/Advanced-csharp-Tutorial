namespace LINQExample_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartment();

            // Sorting Operations OrderBy, OrderByDescending, ThenBy, ThenByDescending

            Console.WriteLine($"Sorting operations - method syntax example {Environment.NewLine}{new string('-', 43)}");
            var resultOredrBy = employeeList.Join(departmentList, e => e.DepartmentId, d => d.Id,
                                (emp, dept) => new
                                {
                                    Id = emp.Id,
                                    FirstName = emp.FirstName,
                                    LastName = emp.LastName,
                                    AnnualSalary = emp.Annualsalary,
                                    DepartmentId = emp.DepartmentId,
                                    DepartmentName = dept.LongName
                                }).OrderByDescending(o => o.DepartmentId);  //OrderBy dammama ascending order descening order onnm exmaple eke thiyna widiyai

            foreach (var item in resultOredrBy)
            {
                Console.WriteLine($"First Name : {item.FirstName,-10} Last Name {item.LastName,-10} Annual Salary {item.AnnualSalary,10}\t Department Name: {item.DepartmentName}");
            }

            Console.WriteLine();
            Console.WriteLine($"Sorting operations - query syntax example {Environment.NewLine}{new string('-', 43)}");

            var resultOrderByQuerySyntax = from emp in employeeList
                                           join dept in departmentList
                                           on emp.DepartmentId equals dept.Id
                                           orderby dept.Id descending, emp.Annualsalary
                                           select new
                                           {
                                               Id = emp.Id,
                                               FirstName = emp.FirstName,
                                               AnnualSalary = emp.Annualsalary,
                                               DepartmentID = emp.DepartmentId,
                                               DepartmentName = dept.LongName
                                           };

            foreach (var item in resultOrderByQuerySyntax)
            {
                Console.WriteLine($"First Name : {item.FirstName,-10} Annual Salary {item.AnnualSalary,10}\t Department Name: {item.DepartmentName}");
            }
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal Annualsalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string LongName { get; set; } = null!;

    }

    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Indura",
                LastName = "perera",
                Annualsalary = 220000.00m,
                IsManager = false,
                DepartmentId = 1
            };

            employees.Add(employee);

            employee = new Employee
            {
                Id = 2,
                FirstName = "Rashmi",
                LastName = "perera",
                Annualsalary = 20000.00m,
                IsManager = false,
                DepartmentId = 4
            };

            employees.Add(employee);

            employee = new Employee
            {
                Id = 3,
                FirstName = "Eliana",
                LastName = "Vivienne",
                Annualsalary = 60000.00m,
                IsManager = true,
                DepartmentId = 4
            };

            employees.Add(employee);

            employee = new Employee
            {
                Id = 4,
                FirstName = "Melina",
                LastName = "De silva",
                Annualsalary = 40000.00m,
                IsManager = true,
                DepartmentId = 3
            };

            employees.Add(employee);

            employee = new Employee
            {
                Id = 5,
                FirstName = "Kumaraguptha",
                LastName = "Sandakelum",
                Annualsalary = 20000.00m,
                IsManager = true,
                DepartmentId = 2
            };

            employees.Add(employee);

            return employees;
        }

        public static List<Department> GetDepartment()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "IT",
                LongName = "Information Technology"
            };

            departments.Add(department);

            department = new Department
            {
                Id = 2,
                ShortName = "HR",
                LongName = "Human Resource"
            };

            departments.Add(department);

            department = new Department
            {
                Id = 3,
                ShortName = "FN",
                LongName = "Finance"
            };

            departments.Add(department);

            department = new Department
            {
                Id = 4,
                ShortName = "MK",
                LongName = "Marketing"
            };

            departments.Add(department);

            return departments;
        }
    }
}
