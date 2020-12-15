using System;
using System.Linq;
using System.Collections.Generic;
using password_manager.Data;
using password_manager.Entities;

namespace password_manager.Controllers
{
    public class LoginController
    {
        private DataContext _context { get; set; }

        public LoginController(DataContext context)
        {
            this._context = context;
        }

        public async void AddNewLogin(Login login)
        {
            try
            {
                this._context.Logins.Add(login);
                await this._context.SaveChangesAsync();
                Console.WriteLine($"New login: {login.UserName} saved on the database");
            }
            catch (Exception error)
            {
                Console.WriteLine($"An error has ocurred while trying to save the login on the database! {error}");
                throw new Exception("Database Error");
            }
        }

        public List<Login> ListAllLogins()
        {
            var logins = new List<Login>();

            logins = _context.Logins.ToList();

            return logins;
        }

        public Login FindUserByConnName(string connName)
        {
            try
            {
                var login = _context.Logins.Where(login => login.ConnectionName == connName).First();
                return login;
            }
            catch (Exception error)
            {
                Console.WriteLine($"An error has ocurred {error.Message}");
                throw new Exception("Can't find the user");
            }
        }

        



    }
}