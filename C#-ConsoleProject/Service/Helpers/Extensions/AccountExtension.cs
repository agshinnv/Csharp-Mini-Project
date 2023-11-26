using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class AccountExtension
    {
        public static bool ConfirmPass(this string password, string confirmPassword)
        {
            if(password != confirmPassword)
            {
                ConsoleColor.Red.WriteConsole("The information you typed doesn't match, please add password again");
                return false;
            }

            return true;
        }


        public static bool CheckEmail(this string email)
        {
            string reg = (@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return Regex.IsMatch(email, reg);
        }

        
    }

    
}
