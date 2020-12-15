using System;
using password_manager.Controllers;
using password_manager.Entities;

namespace password_manager.Utils
{
    public class AuthUtil
    {
        public static Auth CreateAuth(AuthController controller)
        {
            Console.WriteLine("What's the username?");
            var username = Console.ReadLine();

            Console.WriteLine("What's the password ?");
            var password = Console.ReadLine();

            var auth = new Auth
            {
                UserName = username,
                Password = SecurityUtil.GenerateHash(password)
            };

            controller.AddNewAuth(auth);

            return auth;
        }

        public static bool CheckIfAuth(AuthController controller)
        {
            Console.WriteLine("What's your username? ");
            var username = Console.ReadLine();

            Console.WriteLine("What's your password ?");
            var password = Console.ReadLine();

            var auth = controller.FindAuth(username);

            if (username == auth.UserName && SecurityUtil.GenerateHash(password) == auth.Password) return true;

            return false;
            
        }
    }
}