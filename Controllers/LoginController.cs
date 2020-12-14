using System;
using System.Linq;
using System.Collections.Generic;
using password_manager.Data;
using password_manager.Entities;

namespace password_manager.Controllers
{
    public class LoginController
    {
        public DataContext context { get; set; }

        public LoginController(DataContext context)
        {
            this.context = context;
        }

        public async void AddNewLogin(Login login)
        {
            try
            {
                this.context.Logins.Add(login);
                await this.context.SaveChangesAsync();
                Console.WriteLine($"New login: {login.UserName} saved on the database");
            }
            catch(Exception error)
            {
                Console.WriteLine($"An error has ocurred while trying to save the login on the database! {error}");
                throw new Exception("Database Error");
            }
        }

        public List<Login> ListAllLogins()
        {
            var logins = new List<Login>();

            logins = context.Logins.ToList();

            return logins;
        }



    }
}