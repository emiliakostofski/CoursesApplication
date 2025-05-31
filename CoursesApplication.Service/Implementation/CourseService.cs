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
  
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> repository;

        public CourseService(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public Course DeleteById(Guid id)
        {
            var course = GetById(id);
            if (course == null)
            {
                throw new Exception("course not found");
            }
            return repository.Delete(course);
        }

        public List<Course> GetAll()
        {
            return repository.GetAll(selector:x=>x).ToList();
        }

        public Course? GetById(Guid id)
        {
            return repository.Get(selector:x=>x, predicate:x=>x.Id.Equals(id));
        }

        public Course Insert(Course course)
        {
            course.Id = Guid.NewGuid();
            return repository.Insert(course);
        }

        public ICollection<Course> InsertMany(ICollection<Course> courses)
        {
            return repository.InsertMany(courses);
        }

        public Course Update(Course flight)
        {
            return repository.Update(flight);
        }
    }
}
