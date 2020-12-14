using System;
using password_manager.Data;
using password_manager.Entities;
using password_manager.Utils;

namespace password_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Password Manager!!! Version: 1.0");

            try
            {
                var context = new DataContext();
                Menu();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error has ocurred: {exception}");
                Menu();
            }


        }

        static async void addNewLogin(DataContext context, Login login)
        {
            context.Logins.Add(login);
            await context.SaveChangesAsync();
            Console.WriteLine("Novo login salvo no banco");
        }

        static void Menu()
        {
            try
            {
                Console.WriteLine("What do you want to do?\n1 - List all logins\n2 - Search for the password for a given login\n3 - Exit the application");
                var opt = Console.ReadLine();

                Console.WriteLine(opt);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error has ocurred: {exception}");
                Menu();
            }
        }
    }
}
