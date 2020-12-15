using System.Text;
using System;
using System.Collections.Generic;
namespace password_manager.Utils
{
    public class SecurityUtil
    {
        public static Dictionary<string, string> securityDictionary = new Dictionary<string, string>()
        {
            {"max_security","abcdefghijklmnopqrstuvxyzw0123456789!@#$%*()?:;{}[]+-ABCDEFGHIJKLMNOPQRSTUVXYZW" },
            {"no_symbols", "abcdefghijklmnopqrstuvxyzw0123456789ABCDEFGHIJKLMNOPQRSTUVXYZW"},
            {"letters_only", "abcdefghijklmnopqrstuvxyzwABCDEFGHIJKLMNOPQRSTUVXYZW"},
            {"numbers_only", "0123456789"}
        };

        public static string GetSecurityString(HashOptionsUtil hash)
        {

            if(hash == HashOptionsUtil.MaxSecurity)
            {
                return securityDictionary["max_security"];
            }
            else if(hash == HashOptionsUtil.NoSymbols)
            {
                return securityDictionary["no_symbols"];
            }
            else if(hash == HashOptionsUtil.LettersOnly)
            {
                return securityDictionary["letters_only"];
            }
            else if(hash == HashOptionsUtil.NumbersOnly)
            {
                return securityDictionary["numbers_only"];
            }

            return securityDictionary["max_security"];
        }

        public static string DefineSecurity()
        {
            Console.WriteLine("Which Security Level do you want ?\n" +
            "1 - Max Security: Letters, Numbers and Special Symbols\n" +
            "2 - No Special Symbols: Letters and Number\n" +
            "3 - Letters Only: Only Letters\n" +
            "4 - Numbers Only: Only Numbers\n" +
            "Choose one of the options: 1,2,3 or 4");

            var optSecurity = Console.ReadLine();

            return GetSecurityString((HashOptionsUtil) int.Parse(optSecurity));
        }

        public static string GenerateHash(string password)
        {
            var securityHash = new List<string>()
            {
                "a","b","c","d","e","f","g","h","i","j","k","l","m","n" +
                "o","p","q","r","s","t","u","v","x","y","w","z","0","1" +
                "2","3","4","5","6","7","8","9","!","@","#","$","%","&" +
                "*","A","B","C","D","E","F","G","H","I","J","K","L","M" +
                "N","O","P","Q","R","S","T","U","V","X","Y","Z"
            };

            var hash = new StringBuilder();

            //TODO: Put this in a function, and create a begin and end string to be hashed and joined with the hashed password
            foreach(var character in password)
            {
                var counter = 0;
                foreach(var hashChar in securityHash)
                {
                    if(hashChar == character.ToString())
                    {
                        break;
                    }
                    counter++;
                }
                hash.Append(counter > 40 ? securityHash[counter-20] : securityHash[counter+20]);
            }

            return hash.ToString();
        }
    }
}