﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        List<Student> Search(string searchtext);
        List<Student> Sorting(string sortType);
        void Edit(int id,Student student);
    }
}
