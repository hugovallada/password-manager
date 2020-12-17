using System;
using System.Collections.Generic;
using password_manager.Data;
using password_manager.Entities;
using password_manager.Utils;
using System.Linq;

namespace password_manager.Controllers
{
    public class AuthController
    {
        private readonly DataContext _context;
        public AuthController(DataContext context)
        {
            _context = context;
        }

        public async void AddNewAuth(Auth auth)
        {
            try{

            
            var auths = FindAllAuth();

            if (auths != null)
            {
                auths.ForEach(authDB =>
                {
                    if (authDB.UserName == auth.UserName)
                    {
                        throw new Exception("This username has been taken already");
                    }
                });
            }

            _context.Auths.Add(auth);
            await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception($"An error has ocurred: {e.Message}");
            }
        }


        public Auth FindAuth(string username)
        {
            var auth = _context.Auths.Where(auth => auth.UserName == username).FirstOrDefault();
            return auth;
        }

        private List<Auth> FindAllAuth()
        {
            var auths = _context.Auths.ToList();
            return auths;
        }
    }
}