using information_system.Data_Types;
using System;
using System.Collections.Generic;
using System.IO;

namespace information_system.General
{
    public static class UserAuthorization
    {
        private static string username;
        private static string password;

        public static User Start(List<User> users)
        {
            Console.WriteLine("Welcome to the authorization system.");

            User user = null;

            while (user == null)
            {
                Console.Write("Enter your login: ");
                string username = Console.ReadLine();

                Console.Write("Enter your password: ");
                string password = ReadPassword();

                user = CheckCredentials(username, password, users);
                if (user == null)
                    Console.WriteLine("Incorrect login or password. Try again.");
            }

            return user;
        }

        private static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }

        private static User CheckCredentials(string username, string password, List<User> users)
        {
            if (username == "admin" && password == "admin")
            {
                return new User(0, "admin", "admin", RoleEnum.Role.Administrator);
            }

            foreach (var user in users)
                if (user.Login == username && user.Password == password)
                    return user;

            return null;
        }
    }
}
