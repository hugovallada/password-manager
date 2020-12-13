using System;
using password_manager.Entities;

namespace password_manager.Utils
{
    public class LoginUtil
    {
        public static Login CreateNewLogin()
        {
            var login = new Login();

            Console.WriteLine("What's the name of the connection ?");
            login.ConnectionName = Console.ReadLine();

            Console.WriteLine("What's the url of the site you want to connect?");
            login.Url = Console.ReadLine();

            Console.WriteLine("What's your username?");
            login.UserName = Console.ReadLine();

            Console.WriteLine("What's the length of your password?");
            var passwordLength = Console.ReadLine();

            login.GeneratePassword(int.Parse(passwordLength));

            return login;
        }
    }
}