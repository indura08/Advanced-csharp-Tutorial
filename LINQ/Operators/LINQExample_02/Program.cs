using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

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
                                }).OrderByDescending(o => o.DepartmentId).ThenByDescending(o => o.AnnualSalary);  //OrderBy dammama ascending order descening order onnm exmaple eke thiyna widiyai

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

            //group by operators - group by
            Console.WriteLine();
            Console.WriteLine($"GroupBy operations - query syntax example {Environment.NewLine}{new string('-', 43)}");

            var resultGroupByQuerySyntax = from emp in employeeList
                                           orderby emp.DepartmentId
                                           group emp by emp.DepartmentId;
            // query syntax ekk iwar krnwa nm hodt mathk thiygnna one sleect ekakin ho gropuby ekakin thami iwar krnna one , wena wena ewain iwar krnna bah onnm try krla blnna 

            foreach (var empGroup in resultGroupByQuerySyntax)
            {
                Console.WriteLine($"Department ID : {empGroup.Key}");
                //Console.WriteLine(empGroup.GetType());
                foreach (var emp in empGroup)
                {
                    Console.WriteLine($"\tEmployee Name : {emp.FirstName} {emp.LastName}");
                }
            }


            //Group by - Method syntax
            Console.WriteLine();
            Console.WriteLine($"GroupBy operations - query syntax example {Environment.NewLine}{new string('-', 43)}");

            var resultGroupByMethodSyntax = employeeList.OrderBy(o => o.DepartmentId).ToLookup(k => k.DepartmentId);

            foreach (var empGroup in resultGroupByQuerySyntax)
            {
                Console.WriteLine($"Department ID : {empGroup.Key}");
                //Console.WriteLine(empGroup.GetType());
                foreach (var emp in empGroup)
                {
                    Console.WriteLine($"\tEmployee Name : {emp.FirstName} {emp.LastName}");
                }
            }

            //G///All, Any, Contains Quantifier Operators - (all,any deka liwwe nah ewa saraliu therumgnna puluwan nisa)
            Console.WriteLine();
            Console.WriteLine($"Quantifier operations - Method syntax example {Environment.NewLine}{new string('-', 43)}");

            //contains operator
            var searchEmployee = new Employee
            {
                Id = 1,
                FirstName = "Indura",
                LastName = "perera",
                Annualsalary = 220000.00m,
                IsManager = false,
                DepartmentId = 1
            };

            //me example eke wenama comparere class ekk hdla thiynne contains ekedi check wenne c# build in types withri employee types check krnna bha , employee wage api implmenet krpu type check krnwa adalal comparer interface ek extend krla comparer class ekk hdgnna one 
            bool isEmployeeContains = employeeList.Contains(searchEmployee, new EmployeeComparer());
            if (isEmployeeContains)
            {
                Console.WriteLine($"Employee found with Name: {searchEmployee.FirstName}");
            }
            else 
            {
                Console.WriteLine($"Employee not found with Name: {searchEmployee.FirstName}");
            }

            //Filter opeartors Where, OfType
            Console.WriteLine();
            Console.WriteLine($"filter operators (of type) - Method syntax example {Environment.NewLine}{new string('-', 43)}");

            //ofType operator
            ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

            var stringResult = mixedCollection.OfType<string>();
            var employeeResult = mixedCollection.OfType<Employee>();
            foreach (var item in employeeResult)
            {
                Console.WriteLine(item.FirstName);
            }

            //element operators code implment kale nah idea ek gtta , passe onnm try krnna time madi hinda kale natte 2025-04-02
        }
    }

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            if (x.Id == y.Id && x.FirstName.ToLower() == y.FirstName.ToLower() && x.LastName.ToLower() == y.LastName.ToLower())
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
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

        public static ArrayList GetHeterogeneousDataCollection()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(100);
            arrayList.Add("Bob Jones");
            arrayList.Add(2000);
            arrayList.Add(3000);
            arrayList.Add("Bill Henderson");
            arrayList.Add(new Employee { Id = 6, FirstName = "Jennifer", LastName = "Dale", Annualsalary = 90000, IsManager = true, DepartmentId = 1 });
            arrayList.Add(new Employee { Id = 7, FirstName = "Dane", LastName = "Hughes", Annualsalary = 60000, IsManager = false, DepartmentId = 2 });
            arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" });
            arrayList.Add(new Department { Id = 5, ShortName = "R&D", LongName = "Research and Development" });
            arrayList.Add(new Department { Id = 6, ShortName = "PRD", LongName = "Production" });

            return arrayList;
        }
    }
}
