using System;
using password_manager.Data;
using password_manager.Entities;

namespace password_manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Password Manager!!! Version: 1.0");

            var context = new DataContext();

            var log = new Login();
            log.UserName = "valladahugo@gmail.com";
            log.GeneratePassword(64);
            log.ConnectionName = "udemy";
            log.Url = "www.udemy.com.br";

            Console.WriteLine($"Username: {log.UserName}\nPassword: {log.Password}");

            addNewLogin(context, log);
        }

        static async void addNewLogin(DataContext context, Login login)
        {
            context.Logins.Add(login);
            await context.SaveChangesAsync();
            Console.WriteLine("Novo login salvo no banco");
        }
    }
}
