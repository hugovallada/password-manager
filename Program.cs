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

            var context = new DataContext();

           //addNewLogin(context, LoginUtil.CreateNewLogin());

        }

        static async void addNewLogin(DataContext context, Login login)
        {
            context.Logins.Add(login);
            await context.SaveChangesAsync();
            Console.WriteLine("Novo login salvo no banco");
        }
    }
}
