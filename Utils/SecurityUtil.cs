using System;
using System.Collections.Generic;
namespace password_manager.Utils
{
    public class SecurityUtil
    {
        public static Dictionary<string, string> securityDictionary = new Dictionary<string, string>()
        {
            {"max_security","abcdefghijklmnopqrstuvxyzw0123456789!@#$%*()" },
            {"no_symbols", "abcdefghijklmnopqrstuvxyzw0123456789"},
            {"letters_only", "abcdefghijklmnopqrstuvxyz"},
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
            //FIXME: Fix how the string shows up on the terminal 
            Console.WriteLine(@"Which Security Level do you want ?\n
            1 - Max Security: Letters, Numbers and Special Symbols\n
            2 - No Special Symbols: Letters and Number\n
            3 - Letters Only: Only Letters\n
            4 - Numbers Only: Only Numbers\n
            Choose one of the options: 1,2,3 or 4");

            var optSecurity = Console.ReadLine();

            return GetSecurityString((HashOptionsUtil) int.Parse(optSecurity));
        }
    }
}