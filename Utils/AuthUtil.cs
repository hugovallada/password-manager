using System;
using password_manager.Entities;

namespace password_manager.Utils
{
    public class AuthUtil
    {
        public static Auth CreateAuth(string username, string password)
        {
            var auth = new Auth 
            {
                UserName = username,
                Password = SecurityUtil.GenerateHash(password)
            };

            return auth;
        }

        public static bool CheckIfAuth(string username, string password)
        {
            if(username == "hugovallada" && SecurityUtil.GenerateHash(password) == "$V7%C3IJ3EJ%I#%!IJ$EE#wJvE%C3I$3EzEw!I$JDF#w97vE&*EwE")
            {
                Console.WriteLine("Logado");
                return true;
            }

            Console.WriteLine("Não logado");
            return false;
        }
    }
}