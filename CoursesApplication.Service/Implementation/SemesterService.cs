using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Implementation
{
    public class SemesterService : ISemesterService
    {
        private readonly IRepository<Semester> repository;

        public SemesterService(IRepository<Semester> repository)
        {
            this.repository = repository;
        }

        public Semester DeleteById(Guid id)
        {
            var courses = GetById(id);
            if (courses == null)
            {
                throw new Exception("Course not found");
            }
            return repository.Delete(courses);
        }

        public List<Semester> GetAll()
        {
            return repository.GetAll(selector:x=>x).ToList();
        }

        public Semester? GetById(Guid id)
        {
            return repository.Get(selector:x=>x, predicate:x=>x.Id.Equals(id));
        }

        public Semester Insert(Semester flight)
        {
            flight.Id = Guid.NewGuid();
            return repository.Insert(flight);
        }

        public ICollection<Semester> InsertMany(ICollection<Semester> flights)
        {
            return repository.InsertMany(flights);  
        }

        public Semester Update(Semester flight)
        {
           return repository.Update(flight);
        }
    }
}
