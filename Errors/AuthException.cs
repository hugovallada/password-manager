using System;
namespace password_manager.Errors
{
    public class AuthException : Exception
    {
        public AuthException(string message) : base(message)
        {
        }
    }
}