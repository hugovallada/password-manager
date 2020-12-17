using System.Net.Mime;
using System.IO;
using System.Diagnostics;
using System;
using password_manager.Controllers;
using password_manager.Entities;
using System.Linq;
using System.Threading.Tasks;
using password_manager.Extensions;

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
            Console.WriteLine("How do you want display your login ?\n1 - Data on the console\n2 - Text File\n");
            var opt = Console.ReadLine();

            if (authController != null)
            {
                Console.WriteLine("Please, insert your master info to display sensitive data");
                AuthUtil.CheckIfAuth(authController);
            }


            if (opt == "1")
            {
                Console.WriteLine();
                Console.WriteLine(login);
            }
            else if (opt == "2")
            {
                CreateTempLoginFile(login);
            }
            //FIXME: There's bugs on the TextCopy library right now... DISABLED UNTIL FIX
            else if (opt == "3")
            {
                // Console.WriteLine("iniciando...");
                // var data = $"{login.UserName} - {login.Password}";
                // var arguments = "xclip -selection < /home/hugovallada/Data/PasswordTemp.txt";
                // var process = new Process
                // {
                //     StartInfo = new ProcessStartInfo
                //     {
                //         FileName = "bash",
                //         Arguments = arguments,
                //         RedirectStandardOutput = true,
                //         RedirectStandardError = true,
                //         UseShellExecute = false,
                //         CreateNoWindow = false,
                //     }
                // };

                // process.Start();
                // process.WaitForExit();
                Console.WriteLine("This option is currently disabled");
                Console.WriteLine(login);
                //login.CopyToClipboard();         
            }
        }


        public static void FindSpecificLogin(LoginController controller, AuthController authController)
        {
            Console.WriteLine("What's the connection name ?");
            var connName = Console.ReadLine();
            ShowLogin(controller.FindUserByConnName(connName), authController);
        }

        private static void CreateTempLoginFile(Login login)
        {
            try
            {

                using (var file = File.Create("/home/hugovallada/Data/loginTemp.txt")) { }

                using (var sw = new StreamWriter("/home/hugovallada/Data/loginTemp.txt"))
                {
                    sw.WriteLine(login);
                }


                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "gedit",
                        Arguments = "/home/hugovallada/Data/loginTemp.txt",
                        WindowStyle = ProcessWindowStyle.Hidden,
                    }
                };

                process.Start();
                process.WaitForExit();

                File.Delete("/home/hugovallada/Data/loginTemp.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}