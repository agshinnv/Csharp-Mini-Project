using Domain.Models;
using Repository.Data;
using Service.Helpers.Extensions;
using Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C__ConsoleProject.Controllers
{
    public class GroupController
    {
        public readonly GroupService _service;

        public GroupController()
        {
            _service = new GroupService();
        }

        public void Create()
        {
            Console.WriteLine("Please add gorup name:");
            Name: string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Group name can't be empty");
                goto Name;
            }
            else if (name.ExistingName())
            {
                ConsoleColor.Red.WriteConsole("This name already existing, please choose a different name");
                goto Name;
            }
            else
            {
                name.ExistingName();
            }

            Console.WriteLine("Set the capacity of group:");
            Capacity: string capacityStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(capacityStr))
            {
                ConsoleColor.Red.WriteConsole("Capacity can't be empty");
                goto Capacity;
            }

            bool isFormatCapacity = int.TryParse(capacityStr, out int capacity);
            if(!isFormatCapacity)
            {
                Console.WriteLine("Format is wrong");
                goto Capacity;
            }

            
            Group group = new Group
            {
                Name = name,
                Capacity = capacity
            };

            _service.Create(group);
        }


        public void Delete()
        {
            var groups = _service.GetAll();
            foreach (var item in groups)
            {
                Console.WriteLine(item.Id + "-" + item.Name + "-" + item.Capacity);
            }

            ConsoleColor.Blue.WriteConsole("Please write Id of group which you want delete:");
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

            var student = groups.FirstOrDefault(m => m.Id == id);

            _service.Delete(student);
        }
        public void Edit()
        {
            Console.WriteLine("Write ID for changing:");
            string idStr = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(idStr,out int id);
            if (isCorrectFormat)
            {
                var result = _service.GetbyId(id);
                if(result == null)
                {
                    ConsoleColor.Red.WriteConsole("Group not found");
                }
                if (result != null)
                {
                    Console.WriteLine($"Group name: {result.Name} - Group capacity: {result.Capacity}");

                    Console.WriteLine("Please write the group name for changing:");
                    Name: string name = Console.ReadLine();

                    var groups = _service.GetAll();
                    
                    foreach ( var group in groups)
                    {
                        if(group.Name.Trim().ToLower() == name.Trim().ToLower())
                        {
                            Console.WriteLine("Name already existing");
                            goto Name;
                        }
                    }


                    Console.WriteLine("Please write teh group capacity for change:");
                    string capacityStr = Console.ReadLine();
                    bool isFormatCorrect = int.TryParse(capacityStr,out int capacity);

                    _service.Edit(id, new Group { Name = name, Capacity = capacity });
                    Console.WriteLine("Group information was successfully edited");
                }
            }

            if(!isCorrectFormat)
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
            }

        }

        public void GetById()
        {
            ConsoleColor.Blue.WriteConsole("Please write Id of group which you want delete:");
            GroupId: string idStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Write something, please");
                goto GroupId;
            }

            bool isFormatId = int.TryParse(idStr, out int id);

            var result = _service.GetbyId(id);

            Console.WriteLine($"{result.Name}");
        }


        public void GetAll()
        {
            Console.WriteLine("All groups");
            var result = _service.GetAll();
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Capacity}");
            }
        }


        public void Search()
        {
            Console.WriteLine("Please write what do you want to search:");
            Text: string text = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole("Can't be empty");
                
                goto Text;
            }

            var res = _service.Search(text);

            foreach(var item in res)
            {
                Console.WriteLine($"{item.Name} - {item.Capacity}");
            }
        }

        public void Sort()
        {
            Console.WriteLine("Please select one to sort groups by capacity: asc or desc");

            string sortText = Console.ReadLine();

            foreach (var group in _service.Sort(sortText))
            {
                Console.WriteLine($"Group Name: {group.Name}, Capacity: {group.Capacity}");
            }
        }

    }
}
