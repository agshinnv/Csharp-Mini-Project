using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public List<Group> Search(string searchtext)
        {
            return AppDbContext<Group>.Datas.Where(m=>m.Name.Trim().ToLower().Contains(searchtext.Trim().ToLower())).ToList();
        }

        public List<Group> Sort(string sortType)
        {
            return AppDbContext<Group>.Datas.OrderBy(m => m.Capacity).ToList();
        }
    }
}
