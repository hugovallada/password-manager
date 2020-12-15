using System.Diagnostics;
using System;
using password_manager.Controllers;
using password_manager.Entities;
using System.Linq;

namespace password_manager.Utils
{
    public class LoginUtil
    {
        public static void CreateNewLogin(LoginController controller)
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

            controller.AddNewLogin(login);

            ShowLogin(login);
        }

        public static void ListAllLogins(LoginController controller)
        {
            try
            {
                var logins = controller.ListAllLogins();
                Console.WriteLine("Logins: \n");
                logins.ForEach(login =>
                {
                    Console.WriteLine(
                        $"Connection Name: {login.ConnectionName} -->  " +
                        $"Username: {login.UserName}  -->  " +
                        $"Url: {login.Url}  "
                        );
                });

            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                throw new Exception(error.Message);
            }
        }

        private static void ShowLogin(Login login, AuthController authController = null)
        {
            Console.WriteLine("How do you want display your login ?\n1 - Data on the console\n2 - Text File\n3 - Copy Password to the clipboard(NOT IMPLEMENTED YET)");
            var opt = Console.ReadLine();

            if(authController != null)
            {
                Console.WriteLine("Please, insert your master info to display sensitive data");
                AuthUtil.CheckIfAuth(authController);
            }
            

            if (opt == "1")
            {
                Console.WriteLine();
                Console.WriteLine(login);
            }
            // TODO: Create a file, open on gedit and then delete
            else if (opt == "2")
            {
                // show in text file
            }
            //FIXME
            else if (opt == "3")
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "xclip  -selection clipboard < ",
                        Arguments = "/home/hugovallada/Documents/tempPassword.txt"
                    }
                };

                process.Start();
                process.WaitForExit();
            }
        }

        public static void FindSpecificLogin(LoginController controller, AuthController authController)
        {
            Console.WriteLine("What's the connection name ?");
            var connName = Console.ReadLine();
            ShowLogin(controller.FindUserByConnName(connName), authController);
        }
    }
}