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
            foreach(var item in groups)
            {
                Console.WriteLine(item.Name + "-" + item.Capacity);
            }

            ConsoleColor.Blue.WriteConsole("Please write name of group which you want delete");
            Text: string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole("Write something, please");
                goto Text;
            }

            var group = groups.FirstOrDefault(m=>m.Name.Trim().ToLower() == text.Trim().ToLower());

            
        }

        public void GetById()
        {
            ConsoleColor.Blue.WriteConsole("Please write Id of group which you want delete");
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
            Console.WriteLine("Please write what do you want to sort");
        }

    }
}
