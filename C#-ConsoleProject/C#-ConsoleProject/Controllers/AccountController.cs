using Domain.Models;
using Service.Helpers.Extensions;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace C__ConsoleProject.Controllers
{
    public class AccountController
    {
        private readonly AccountService _service;

        public AccountController()
        {
            _service = new AccountService();
        }

        
        public void Register()
        {
            Console.WriteLine("Please add a name:");
            Name: string name = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Name can't be empty");
                goto Name;
            }


            Console.WriteLine("Please add a surname:");
            Surname: string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("Surname can't be empty");
                goto Surname;
            }


            Console.WriteLine("Please add age:");
            Age: string ageStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole("Age can't be empty");
                goto Age;
            }

            bool isFormatAge = int.TryParse(ageStr, out int age);
            if(!isFormatAge)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Age;
            }

            
            Console.WriteLine("Please add email:");
            Email: string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Email can't be empty");
                goto Email;
            }
            else if(!email.CheckEmail())
            {
                goto Email;
            }
            else
            {
                email.CheckEmail();
            }

            Console.WriteLine("Add password:");
            Pass: string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Password can't be empty");
                goto Pass;
            }


            Console.WriteLine("Confirm password:");
            ConfirmPass: string confirmPassword = Console.ReadLine();
            if (!password.ConfirmPass(confirmPassword))
            {
                goto ConfirmPass;
            }
            

            User user = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                Password = password,
                Age = age
            };

            _service.Register(user);

            ConsoleColor.Green.WriteConsole("Register success");

        }

        public void Login()
        {
            Console.WriteLine("Please add email:");
            Email: string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                ConsoleColor.Red.WriteConsole("Email can't be empty");
                goto Email;
            }
            else if (!email.CheckEmail())
            {
                goto Email;
            }
            else
            {
                email.CheckEmail();
            }

            Console.WriteLine("Please add password:");
            Pass: string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                ConsoleColor.Red.WriteConsole("Password can't be empty");
                goto Pass;
            }

            var res = _service.Login(email, password);
            
            if(!res)
            {
                ConsoleColor.Red.WriteConsole("Email or password is wrong");
            }
            else
            {
                ConsoleColor.Green.WriteConsole("Login is successfully");                
            }

            
        }
    }
}
