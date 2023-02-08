using information_system.RoleEnum;

namespace information_system.Data_Types
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public User(int id, string login, string password, Role role)
        {
            ID = id;
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
