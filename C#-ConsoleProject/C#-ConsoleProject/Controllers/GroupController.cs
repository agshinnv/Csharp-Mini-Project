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
            ConsoleColor.Blue.WriteConsole("Please write name of group which you want delete");
            Text: string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            {
                ConsoleColor.Red.WriteConsole("Write something, please");
                goto Text;
            }

            Group groupName = AppDbContext<Group>.Datas.FirstOrDefault(m => m.Name.Trim().ToLower() == text.Trim().ToLower());

            if (groupName == null)
            {
                Console.WriteLine("Group couldn't find");
                return;
            }

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

            Group groupName = AppDbContext<Group>.Datas.FirstOrDefault(m => m.Id == id);

            Console.WriteLine($"{ groupName.Name}");
        }

    }
}
