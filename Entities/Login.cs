using System.Security.Cryptography;
using System.Web;
using password_manager.Utils;

namespace password_manager.Entities
{
    public class Login
    {
        public int Id { get; set; }

        public string ConnectionName {get; set;}

        public string Url {get; set;}
        public string UserName { get; set; }

        public string Password {get; set;}

        
        public void GeneratePassword(int length)
        {
            var valid = SecurityUtil.DefineSecurity();

            var password = "";
            using(var provider = new RNGCryptoServiceProvider())
            {
                while(password.Length != length)
                {
                    byte[] oneByte = new byte[1];
                    provider.GetBytes(oneByte);

                    var character = (char)oneByte[0];
                    if(valid.Contains(character)) password += character;
                }
            }
            this.Password = password;
        }
    }
}