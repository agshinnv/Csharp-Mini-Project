using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;

        public GroupService()
        {
            _repository = new GroupRepository();
        }

        public void Create(Group group)
        {
            _repository.Create(group);
        }

        public void Delete(Group group)
        {
            _repository.Delete(group);
        }

        public void Edit(Group group)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
           return _repository.GetAll();
        }

        public Group GetbyId(int id)
        {
            return _repository.GetbyId(id);
        }

        public List<Group> Search(string searchtext)
        {
            return _repository.Search(searchtext);
        }

        public List<Group> Sort()
        {
            return _repository.Sort();
        }
    }
}
