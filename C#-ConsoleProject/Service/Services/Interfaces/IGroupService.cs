using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group group);
        void Edit(Group group);
        void Delete(Group group);
        Group GetbyId(int id);
        List<Group> GetAll();
        List<Group> Search(string searchtext);
        List<Group> Sort();
    }
}
