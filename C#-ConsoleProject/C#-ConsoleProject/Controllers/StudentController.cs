using Domain.Models;
using Repository.Data;
using Service.Helpers.Extensions;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ConsoleProject.Controllers
{
    public class StudentController
    {
        private readonly StudentService _service;
        private readonly GroupService _groupService;

        public StudentController()
        {
            _service = new StudentService();
            _groupService = new GroupService();
        }

        public void Create()
        {
            Console.WriteLine("Please add student name and surname:");
            Name: string fullName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                ConsoleColor.Red.WriteConsole("Can't be empty");
                goto Name;
            }            
            

            Console.WriteLine("Enter the student address,please:");
            Address: string address = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(address))
            {
                ConsoleColor.Red.WriteConsole("Address can't be empty");
                goto Address;
            }

            Console.WriteLine("Enter the student age:");
            Age: string ageStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ageStr))
            {
                ConsoleColor.Red.WriteConsole("Can't be empty");
                goto Age;
            }

            bool isFormatAge = int.TryParse(ageStr, out int age);

            if(!isFormatAge)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Age;
            }

            Console.WriteLine("Enter the student phone number:");
            Phone: string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone))
            {
                ConsoleColor.Red.WriteConsole("Can't be empty");
                goto Phone;
            }
                       

            Console.WriteLine("Please enter group ID for change student group:");
            Group: string groupStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(groupStr))
            {
                ConsoleColor.Red.WriteConsole("Can't be empty");
                goto Group;
            }
            
            bool isFormatId = int.TryParse(groupStr, out int id);
            if(!isFormatId)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Group;
            }
            
            var group = _groupService.GetbyId(id);

            if(group == null)
            {
                Console.WriteLine("Group not found");
                goto Group;
            }




            Student student = new Student()
            {
                FullName = fullName,
                Phone = phone,
                Address = address.Trim().ToLower(),
                Age = age,
                Group = group
            };

                      


            _service.Create(student);


        }

        public void Edit()
        {

        }


        public void Delete()
        {
            var students = _service.GetAll();

            foreach (var item in students)
            {
                Console.WriteLine(item.Id + "-" + item.FullName + "-" + item.Age + "-" + item.Address);
            }

            ConsoleColor.Blue.WriteConsole("Please write Id of student which you want delete:");
            Del: string idStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Write something, please");
                goto Del;
            }
            
            bool isFormatId = int.TryParse(idStr, out int id);

            if (!isFormatId)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto Del;
            }
            
            var student = students.FirstOrDefault(m => m.Id == id);

            _service.Delete(student);


        }

        public void GetById()
        {
            ConsoleColor.Blue.WriteConsole("Please enter the ID of the student you want to display:");
            StudentId: string idStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Write something, please");
                goto StudentId;
            }

            bool isFormatId = int.TryParse(idStr, out int id);

            var result = _service.GetbyId(id);

            Console.WriteLine($"{result.Id} - {result.FullName} - {result.Address} - {result.Age}");

        }

        public void GetAll()
        {
            Console.WriteLine("All students:");
            var result = _service.GetAll();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id} - {item.FullName} - {item.Address} - {item.Age} - {item.Group.Name}");
            }
        }


        public void Search()
        {
            Console.WriteLine("Please write student Fullname:");
            Text: string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole("Write something, please");

                goto Text;
            }

            var res = _service.Search(text);

            foreach (var item in res)
            {
                Console.WriteLine($"{item.Id} - {item.FullName} - {item.Address} - {item.Age}");
            }
        }

        public void Sorting()
        {
            Console.WriteLine("Please select one to sort students by age: asc or desc");

            string sortText = Console.ReadLine();

            foreach(var student in _service.Sorting(sortText))
            {
                Console.WriteLine(student.Id + "-" + student.FullName + "-" + student.Age + "-" + student.Address);
            }

            
        }
    }
}
