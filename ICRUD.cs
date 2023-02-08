using information_system.Data_Types;
using static information_system.Roles.Admin;

namespace information_system.ICRUD_Interface
{
    public interface ICRUD
    {
        void Create(User user);
        User Read(int id);
        void Update(User user);
        void Delete(int id);
        List<User> Search(string term, Attr attr);
    }
}