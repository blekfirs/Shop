// See https://aka.ms/new-console-template for more information
using information_system.Data_Types;
using information_system.General;
using information_system.Roles;

namespace MainProg
{
    internal class Program
    {
        public static List<User> users = null;
        public static List<AccountingRecord> accountingRecords = null;
        public static List<SelectedItem> selectedItems = null;

        private static void Main(string[] args)
        {
            LoadData();

            var mainUser = UserAuthorization.Start(users);

            mainUser.Role = information_system.RoleEnum.Role.Administrator;
            var myadmin = new Admin();
            myadmin.Interaction();
        }

        static void LoadData()
        {
            string filePathUsers = Environment.CurrentDirectory;
            users = SerializationDeserialization.Deserialize<User>(filePathUsers + "\\users.json");

            accountingRecords = SerializationDeserialization.Deserialize<AccountingRecord>
                (filePathUsers + "\\accountingRecords.json");

            selectedItems = SerializationDeserialization.Deserialize<SelectedItem>
                (filePathUsers + "\\selectedItems.json");
        }
    }
}