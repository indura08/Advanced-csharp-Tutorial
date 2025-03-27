namespace LINQExample_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeLIst = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartment();

            //mke ithuru tika balnna 9:59:47n nwattuwe- code tika ghngnna hariytm me wlewatm tune krla
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
                    Id = 1,
                    ShortName = "FN",
                    LongName = "Finance"
                };

                departments.Add(department);

                return departments;
            }
        }
    }
}
