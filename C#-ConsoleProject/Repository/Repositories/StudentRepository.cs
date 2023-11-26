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
        public List<Student> Sorting(string sortType)
        {
            return AppDbContext<Student>.Datas.OrderBy(m => m.Age).ToList();
        }

        public List<Student> Search(string searchtext)
        {
            return AppDbContext<Student>.Datas.Where(m=>m.FullName.Trim().ToLower() == searchtext.Trim().ToLower()).ToList();
        }

        public void Edit(int id, Student student)
        {
            var res = GetbyId(id);
            if (res != null)
            {
                if (!string.IsNullOrWhiteSpace(res.FullName))
                {
                    res.FullName = student.FullName;
                }

                if(!string.IsNullOrWhiteSpace(res.Address))
                {
                    res.Address = student.Address;
                }

                if(!string.IsNullOrWhiteSpace(res.Phone))
                {
                    res.Phone = student.Phone;
                }

                if(student.Age != null)
                {
                    res.Age = student.Age;
                }

                if(student.Group != null)
                {
                    res.Group = student.Group;
                }
            }
        }
    }
}
