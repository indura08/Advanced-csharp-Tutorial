using System;
using System.Text.RegularExpressions;

namespace LINQExample_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeLIst = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartment();

            //LINQ-using method syntax
            //var resultMethodSyntax = employeeLIst.Select(e => new
            //{
            //    FullName = e.FirstName + " " + e.LastName,
            //    AnnualSalary = e.Annualsalary
            //}).Where(e => e.AnnualSalary > 50000);

            //foreach (var item in resultMethodSyntax)
            //{
            //    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
            //}

            //Console.WriteLine($"{new string('-', 40)}");
                
            ////LINQ- using query syntax
            //var resultQuerySyntax = from emp in employeeLIst
            //             where emp.Annualsalary > 50000     //where eka daalath puluwan nodath puluwan
            //             select new
            //             {
            //                 FullName = emp.FirstName + " " + emp.LastName,
            //                 AnnualSalary = emp.Annualsalary
            //             };

            //foreach (var item in resultQuerySyntax)
            //{
            //    Console.WriteLine($"{item.FullName, -10} {item.AnnualSalary, 20}");
            //}

            Console.WriteLine();
            Console.WriteLine($"Defered execution example {Environment.NewLine}{new string('-', 40)}");

            //Defered execution example
            var results = from emp in employeeLIst.GetHighSalariedemployees()
                         select new
                         {
                             FullName = emp.FirstName,
                             AnnualSalary = emp.Annualsalary
                         };

            employeeLIst.Add(new Employee
            {
                Id = 5,
                FirstName = "Dulyana",
                LastName = "Perera",
                Annualsalary = 9600,
                IsManager = false,
                DepartmentId = 1
            }); 

            foreach (var item in results)
            {
                Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
            }

            Console.WriteLine();
            Console.WriteLine($"Immediate execution example {Environment.NewLine}{new string('-', 40)}");

            //Immediate execution
            var resultImmediateexecutionEample = (from emp in employeeLIst.GetHighSalariedemployees()
                                                 select new
                                                 {
                                                     FullName = emp.FirstName + " " + emp.LastName,
                                                     AnnualSalary = emp.Annualsalary
                                                 }).ToList();

            employeeLIst.Add(new Employee
            {
                Id = 5,
                FirstName = "Upasith",
                LastName = "Perera",
                Annualsalary = 6000000,
                IsManager = false,
                DepartmentId = 1
            });

            foreach (var item in resultImmediateexecutionEample)
            {
                Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
            }

            Console.WriteLine();
            Console.WriteLine($"Join Method example {Environment.NewLine}{new string('-', 40)}");

            //Join operation example - Method syntax
            var resultJoinMethodSyntax = departmentList.Join(employeeLIst,
                    department => department.Id,
                    employee => employee.DepartmentId,
                    (department, employee) => new
                    {
                        FullName = employee.FirstName + " " + employee.LastName,
                        Annualsalary = employee.Annualsalary,
                        DepartmentName = department.LongName
                    }
                    
                    );
            //nikna join ghuwoth enne inner join withri

            foreach (var item in resultJoinMethodSyntax)
            {
                Console.WriteLine($"{item.FullName,-20} {item.Annualsalary,10}\t{item.DepartmentName}");
            }

            Console.WriteLine();
            Console.WriteLine($"Join Query example {Environment.NewLine}{new string('-', 40)}");

            //Join operation example - Query syntax
            var resultJoinQuerySyntax = from dept in departmentList
                                        join emp in employeeLIst
                                        on dept.Id equals emp.DepartmentId
                                        select new
                                        {
                                            FullName = emp.FirstName + " " + emp.LastName,
                                            AnnualSalary = emp.Annualsalary,
                                            DepartmentName = dept.LongName,
                                        };

            foreach (var item in resultJoinQuerySyntax)
            {
                Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");
            }

            Console.WriteLine();
            Console.WriteLine($"Group Join Method syntax example {Environment.NewLine}{new string('-', 40)}");

            //Group Join operation example - Method syntax
            var resultGropuJoinMethodSyntax = departmentList.GroupJoin(employeeLIst,
                    dept => dept.Id,
                    emp => emp.DepartmentId,
                    (dept, employeesGroup) => new
                    {
                        Employees = employeesGroup,
                        DepartmentName = dept.LongName
                    });

            foreach (var item in resultGropuJoinMethodSyntax)
            {
                Console.WriteLine($"Department Name: {item.DepartmentName}");
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Group Join Query syntax example {Environment.NewLine}{new string('-', 40)}");

            // Group Join operation example - Query syntax
            var resultGropuJoinQuerSyntax = from dept in departmentList
                                            join emp in employeeLIst
                                            on dept.Id equals emp.DepartmentId
                                            into employeeGroup
                                            select new
                                            {
                                                Employees = employeeGroup,
                                                DepartmentName = dept.LongName
                                            };

            foreach (var item in resultGropuJoinQuerSyntax)
            {
                Console.WriteLine($"Department Name: {item.DepartmentName}");
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine($"\t{emp.FirstName} {emp.LastName}");
                }
            }
        }
    }

    public static class EnumerableCollectionExtensionMethods
    {
        public static IEnumerable<Employee> GetHighSalariedemployees(this IEnumerable<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"Accessing employee: {emp.FirstName + " " + emp.LastName}");

                if (emp.Annualsalary >= 50000)
                {
                    yield return emp;
                }

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
                DepartmentId = 2
            };

            employees.Add(employee);

            employee = new Employee
            {
                Id = 3,
                FirstName = "Eliana",
                LastName = "Vivienne",
                Annualsalary = 60000.00m,
                IsManager = true,
                DepartmentId = 2
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
                DepartmentId = 0
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
