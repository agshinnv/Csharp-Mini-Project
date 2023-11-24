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
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public List<Student> Filter()
        {
            return AppDbContext<Student>.Datas.OrderBy(m => m.Age).ToList();
        }

        public List<Student> Search(string searchtext)
        {
            return AppDbContext<Student>.Datas.Where(m=>m.FullName == searchtext).ToList();
        }
    }
}
