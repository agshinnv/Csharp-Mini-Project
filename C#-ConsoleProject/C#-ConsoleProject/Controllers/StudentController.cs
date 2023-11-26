using Domain.Models;
using Repository.Data;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ConsoleProject.Controllers
{
    public class StudentController
    {
        private readonly IStudentService _service;
        private readonly IGroupService _groupService;

        public StudentController()
        {
            _service = new StudentService();
            _groupService = new GroupService();
        }

        public void Create()
        {
            var result = _groupService.GetAll();
            if(result.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Please create a group, you don't have a group");
                return;
                
            }
            
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
            if (age <= 14 || age > 100) 
            {
                ConsoleColor.Red.WriteConsole("Registration age should be between 15-100");
                goto Age;
            }

            Console.WriteLine("Enter the student phone number:");
            Phone: string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone))
            {
                ConsoleColor.Red.WriteConsole("Can't be empty");
                goto Phone;
            }
            else if (!phone.PhoneFormat())
            {
                ConsoleColor.Red.WriteConsole("Phone format is wrong");
                goto Phone;
            }
            else
            {
                phone.PhoneFormat();
            }

            Console.WriteLine("Please enter Group ID:");
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
                ConsoleColor.Red.WriteConsole("Group not found, first you need to create a group");
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
            Console.WriteLine("Write the ID of the student you want change:");
            Id: string idStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Can't be empty");
                goto Id;
            }

            bool isCorrectFormat = int.TryParse(idStr, out int id);
            if(!isCorrectFormat)
            {
                ConsoleColor.Red.WriteConsole("ID format is wrong");
                goto Id;
            }
            else
            {
                var result = _service.GetbyId(id);
                if(result == null)
                {
                    ConsoleColor.Red.WriteConsole("Data not found");
                }
                if(result != null)
                {
                    Console.WriteLine($"Student ID: {result.Id} - Student name: {result.FullName} - Address: {result.Address} - Student age: {result.Age} - Phone number: {result.Phone} - Group name: {result.Group.Name} - Group capacity: {result.Group.Capacity}");

                    Console.WriteLine("Please write the student Fullname for changing:");
                    string fullName = Console.ReadLine();

                    var students = _service.GetAll();

                    foreach( var student in students)
                    {
                        if (string.IsNullOrWhiteSpace(fullName))
                        {
                            fullName = student.FullName;
                            
                        }
                    }

                    Console.WriteLine("Please write the student address for changing:");
                    string address = Console.ReadLine();

                    foreach(var student in students)
                    {
                        if (string.IsNullOrWhiteSpace(address))
                        {
                            address = student.Address;
                        }
                    }    

                    Console.WriteLine("Please write the student age for changing:");
                    Age: string ageStr = Console.ReadLine();
                    int age;
                    bool isFormatAge = int.TryParse(ageStr, out age);

                    if (string.IsNullOrWhiteSpace(ageStr))
                    {
                        age = (int)result.Age;
                    }

                    if (age <= 14 || age > 100)
                    {
                        ConsoleColor.Red.WriteConsole("The age range you want to change should be between 15-100");
                        goto Age;
                    }                   

                    


                    Console.WriteLine("Please write the student phone for changing:");
                    string phone = Console.ReadLine();
                    int phoneStr;
                    bool isFormatPhone = int.TryParse(phone, out phoneStr);
                    
                    foreach(var student in students)
                    {
                        if(string.IsNullOrWhiteSpace(phone))
                        {
                            phone = student.Phone;
                        }
                    }

                    if (isFormatPhone)
                    {
                        goto GroupName;
                    }


                    Console.WriteLine("Please write group name for changing:");
                    GroupName: string groupName = Console.ReadLine();

                    foreach (var group in _groupService.GetAll())
                    {
                        if (string.IsNullOrWhiteSpace(groupName))
                        {
                            groupName = group.Name;
                        }
                    }

                    _service.Edit(id, new Student { FullName = fullName, Address = address, Age = age, Phone = phone, Group = new Group { Name = groupName, Capacity = result.Group.Capacity } });

                }
            }
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

            if (result == null)
            {
                ConsoleColor.Red.WriteConsole("No such student was found");
                goto StudentId;
            }

            Console.WriteLine($"ID: {result.Id} - {result.FullName} - {result.Address} - {result.Age}");

        }

        public void GetAll()
        {
            Console.WriteLine("All students information:");
            var result = _service.GetAll();
            foreach (var item in result)
            {
                Console.WriteLine($"ID: {item.Id} - FullName: {item.FullName} - Address: {item.Address} - Age: {item.Age} - Phone number : {item.Phone} - Group name: {item.Group.Name} - Group capacity: {item.Group.Capacity}");
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
