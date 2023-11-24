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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService()
        {
            _repository = new StudentRepository();
        }

        public void Create(Student student)
        {
            _repository.Create(student);
        }

        public void Delete(Student student)
        {
            _repository.Delete(student);
        }

        public void Edit(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> Filter()
        {
           return _repository.Filter();
        }

        public List<Student> GetAll()
        {
            return _repository.GetAll();
        }

        public Student GetbyId(int id)
        {
            return _repository.GetbyId(id);
        }

        public List<Student> Search(string searchtext)
        {
            return _repository.Search(searchtext);
        }
    }
}
