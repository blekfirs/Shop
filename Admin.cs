using information_system.Data_Types;
using information_system.ICRUD_Interface;
using information_system.SystemKeyEnum;

namespace information_system.Roles
{
    public class Admin : ICRUD
    {
        public enum Attr
        {
            ID,
            LOGIN,
            PASSWORD,
            ROLE
        }

        public List<User> Users { get; set; }

        public Admin() => Users = new List<User>();

        public void Create(User user) => Users.Add(user);

        public User Read(int id) => Users.Find(u => u.ID == id);

        public void Update(User user)
        {
            var userToUpdate = Users.FirstOrDefault(u => u.ID == user.ID);

            if (userToUpdate != null)
                userToUpdate = user;
        }

        public void Delete(int id) => Users.RemoveAll(u => u.ID == id);

        public List<User> Search(string term, Attr attr)
        {
            switch (attr)
            {
                case Attr.ID:
                    return Users.Where(u => u.ID.ToString().Contains(term)).ToList();
                case Attr.LOGIN:
                    return Users.Where(u => u.Login.Contains(term)).ToList();
                case Attr.PASSWORD:
                    return Users.Where(u => u.Password.Contains(term)).ToList();
                case Attr.ROLE:
                    return Users.Where(u => u.Role.ToString().Contains(term)).ToList();
                default:
                    return null;
            }
        }

        enum MenuState
        {
            SIMPLE,
            SEARCH,
            CREATE,
            CHOOSE
        };

        public void Interaction()
        {
            var menuStates = Enum.GetNames(typeof(MenuState));
            MenuState menuState = MenuState.SIMPLE;
            int selectedIndex = 1;
            var options = new List<string> { "Find user", "Create user", "Select user" };
            var filteredUsers = Users;
            List<User> users = new List<User>();

            ConsoleKeyInfo keyInfo;

            while (true)
            {
                Console.Clear();

                switch (menuState)
                {
                    case MenuState.SIMPLE:
                        SimpleMenu(selectedIndex);
                        break;
                    case MenuState.SEARCH:
                        if (!SearchMenu(selectedIndex))
                            menuState = MenuState.SIMPLE;
                        break;
                    case MenuState.CREATE:
                        break;
                    case MenuState.CHOOSE:
                        break;
                    default:
                        break;
                }

                keyInfo = Console.ReadKey();

                switch ((SystemKey)keyInfo.Key)
                {
                    case SystemKey.Down:
                        selectedIndex = Math.Min(++selectedIndex, menuStates.Count() - 1);
                        break;

                    case SystemKey.Up:
                        selectedIndex = Math.Max(--selectedIndex, 1);
                        break;

                    case SystemKey.Enter:
                        menuState = (MenuState)Enum.Parse(typeof(MenuState), menuStates[selectedIndex]);
                        break;
                }
            }
        }

        void SimpleMenu(int index)
        {
            List<string> menu = new List<string>() { "Main Menu:", 
                "User Search", 
                "Create User", 
                "Select User" };

            for (int i = 0; i < menu.Count; i++)
            {
                if (i == index)
                    Console.BackgroundColor = ConsoleColor.Blue;

                Console.WriteLine(menu[i]);

                if (i == index)
                    Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        bool SearchMenu(int index)
        {
            // define the list of main menu
            List<string> menu = new List<string>() { "Main Menu:",
                "User Search",
                "Create User",
                "Select User" };

            // define the attr params
            var attrs = Enum.GetNames(typeof(Attr));
            bool selectedAttr = true;
            int attrIndex = 0;

            ConsoleKeyInfo keyInfo;

            // cycle for search
            do
            {
                Console.Clear();

                // outputs the attr
                Console.WriteLine("Select the attr (or press esc):");
                for (int i = 0; i < attrs.Count(); i++)
                {
                    if (i == attrIndex)
                        Console.BackgroundColor = ConsoleColor.Blue;

                    Console.WriteLine(attrs[i]);

                    if (i == attrIndex)
                        Console.BackgroundColor = ConsoleColor.Black;
                }

                // choosing the attr
                if (selectedAttr)
                {
                    keyInfo = Console.ReadKey();

                    switch ((SystemKey)keyInfo.Key)
                    {
                        case SystemKey.Up:
                            attrIndex = Math.Max(--attrIndex, 0);
                            continue;
                        case SystemKey.Down:
                            attrIndex = Math.Min(++attrIndex, attrs.Count() - 1);
                            continue;
                        case SystemKey.Enter:
                            selectedAttr = false;
                            break;
                        case SystemKey.Escape:
                            return false;
                        default:
                            continue;
                    }
                }

                string param = string.Empty;
                // entering the param
                while (param == string.Empty || param == "" || param == null)
                {
                    Console.Write("Enter the param: ");
                    param = Console.ReadLine();
                }

                // search
                Attr choosenAttr = (Attr)Enum.Parse(typeof(Attr), attrs[attrIndex]);
                List<User> result = Search(param, choosenAttr);

                Console.WriteLine("Result of search: ");
                foreach (var item in result)
                    Console.WriteLine(item);

                return true;

            } while (true);

        }

        
    }
}
