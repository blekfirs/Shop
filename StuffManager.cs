using information_system.Data_Types;
using information_system.General;
using information_system.ICRUD_Interface;
using MainProg;

namespace information_system.Roles
{

    internal class StuffManager
    {
        private List<Employee> employees = null;
        private string filePathEmployees = Environment.CurrentDirectory + "\\employees.json";

        public StuffManager()
        {
            employees = SerializationDeserialization.Deserialize<Employee>(filePathEmployees);
        }

        ~StuffManager()
        {
            SerializationDeserialization.Serialize(employees, filePathEmployees);
        }

        public void ShowEmployees()
        {
            Console.WriteLine("Employee List:");
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, employees[i].ToString());
            }
        }

        public void ViewEmployeeDetails(int index)
        {
            Console.WriteLine("Employee Details:");
            Console.WriteLine(employees[index].ToString());
        }

        public void CreateEmployee(User user)
        {
            Console.WriteLine("Enter employee details:");

            Console.Write("login: ");
            string login = Console.ReadLine();

            Console.Write("password: ");
            string password = Console.ReadLine();

            Console.Write("LastName: ");
            string lname = Console.ReadLine();

            Console.Write("FirstName: ");
            string fname = Console.ReadLine();

            Console.Write("Possition: ");
            string possition = Console.ReadLine();

            Console.Write("DateOfBirth: ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());

            Console.Write("PassportSeriesNumber: ");
            string passport = Console.ReadLine();

            Employee employee = new Employee(employees[employees.Count - 1].ID + 1,
                                             lname, fname, dateOfBirth, passport, possition,
                                             salary, employees[employees.Count - 1].UserID + 1);
            employees.Add(employee);
        }

        public void DeleteEmployee(int index)
        {
            employees.RemoveAt(index);
        }

        public void SearchEmployee()
        {
            Console.WriteLine("Enter the search term: ");
            string searchTerm = Console.ReadLine();

            Console.WriteLine("Enter the field to search by: ");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. FirstName");
            Console.WriteLine("3. LastName");
            Console.WriteLine("4. DateOfBirth");
            Console.WriteLine("5. MiddleName");
            Console.WriteLine("6. PassportSeriesNumber");
            Console.WriteLine("7. Position");
            Console.WriteLine("8. UserID");
            Console.WriteLine("9. Salary");

            int fieldToSearchBy = Convert.ToInt32(Console.ReadLine());

            List<Employee> employeesList = new List<Employee>();

            switch (fieldToSearchBy)
            {
                case 1:
                    employeesList = employees.Where(x => x.ID.ToString().Contains(searchTerm)).ToList();
                    break;
                case 2:
                    employeesList = employees.Where(x => x.FirstName.ToLower().Contains(searchTerm.ToLower())).ToList();
                    break;
                case 3:
                    employeesList = employees.Where(x => x.LastName.ToLower().ToString().Contains(searchTerm.ToLower())).ToList();
                    break;
                case 4:
                    employeesList = employees.Where(x => x.DateOfBirth.ToString().Contains(searchTerm)).ToList();
                    break;
                case 5:
                    employeesList = employees.Where(x => x.MiddleName.ToLower().Contains(searchTerm.ToLower())).ToList();
                    break;
                case 6:
                    employeesList = employees.Where(x => x.PassportSeriesNumber.ToLower().Contains(searchTerm.ToLower())).ToList();
                    break;
                case 7:
                    employeesList = employees.Where(x => x.Position.ToLower().Contains(searchTerm.ToLower())).ToList();
                    break;
                case 8:
                    employeesList = employees.Where(x => x.UserID.ToString().Contains(searchTerm)).ToList();
                    break;
                case 9:
                    employeesList = employees.Where(x => x.Salary.ToString().Contains(searchTerm)).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid search option");
                    break;
            }

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (Employee employee in employees)
            {
                Console.WriteLine("ID: " + employee.ID);
                Console.WriteLine("FirstName: " + employee.FirstName);
                Console.WriteLine("LastName: " + employee.LastName);
                Console.WriteLine("MiddleName: " + employee.MiddleName);
                Console.WriteLine("PassportSeriesNumber: " + employee.PassportSeriesNumber);
                Console.WriteLine("Position: " + employee.Position);
                Console.WriteLine("Salary: " + employee.Salary);
                Console.WriteLine("UserID: " + employee.UserID);
                Console.WriteLine("---------------");
            }
        }
    }
}
