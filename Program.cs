using System;
using password_manager.Controllers;
using password_manager.Data;
using password_manager.Entities;
using password_manager.Utils;
using System.Linq;

namespace password_manager
{
    class Program
    {
        static DataContext context = new DataContext();
        static LoginController controller = new LoginController(context);

        static AuthController authController = new AuthController(context);
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Password Manager!!! Version: 1.0");

            try
            {
                if (!context.Auths.Any())
                {
                    Console.WriteLine("Please, create a new auth account");
                    AuthUtil.CreateAuth(authController);
                }
                //var context = new DataContext();
                Menu();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error has ocurred: {exception.Message}");
                Menu();
            }
        }
        static void Menu()
        {
            try
            {
                Console.WriteLine(
                    "What do you want to do?\n" +
                    "1 - List all logins\n" +
                    "2 - Search for the password for a given login\n" +
                    "3 - Create new Login\n" +
                    "4 - Create new Auth! Be careful with this option\n" +
                    "5 - Exit the application"
                    );
                var opt = Console.ReadLine();

                MenuOption(opt);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error has ocurred: {exception.Message}");
                Menu();
            }
        }

        static void MenuOption(string option)
        {
            try
            {
                if (option == "1")
                {
                    LoginUtil.ListAllLogins(controller);
                }
                else if (option == "2")
                {
                    LoginUtil.FindSpecificLogin(controller, authController);
                }
                else if (option == "3")
                {
                    LoginUtil.CreateNewLogin(controller);
                }
                else if (option == "4")
                {
                    Console.WriteLine("Be careful, the new auth, will be able to see all the passwords!!!");
                    AuthUtil.CheckIfAuth(authController);
                    AuthUtil.CreateAuth(authController);
                }
                else if (option == "5")
                {
                    Console.WriteLine("Thanks for use the app!!!");
                }
                else
                {
                    Menu();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Sorry, an error has ocurred: {exception.Message}");
                Menu();
            }

        }
    }
}
