using information_system.RoleEnum;

namespace information_system.Data_Types
{
    public class Employee
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string PassportSeriesNumber { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int UserID { get; set; }

        public Employee(int id, string lastName, string firstName, DateTime dateOfBirth,
            string passportSeriesNumber, string position, decimal salary, int userID)
        {
            ID = id;
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            PassportSeriesNumber = passportSeriesNumber;
            Position = position;
            Salary = salary;
            UserID = userID;
        }
    }

}
