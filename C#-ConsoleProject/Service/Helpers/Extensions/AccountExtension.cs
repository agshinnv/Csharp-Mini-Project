using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class AccountExtension
    {
        public static bool ConfirmPass(this string password, string confirmPassword)
        {
            if(password != confirmPassword)
            {
                ConsoleColor.Red.WriteConsole("The information you typed doesn't match");
                return false;
            }

            return true;
        }


        public static bool CheckEmail(this string email)
        {
            if (!email.Contains("@"))
            {
                ConsoleColor.Red.WriteConsole("@ is required");
                return false;
            }
            return true;
        }
    }

    
}
