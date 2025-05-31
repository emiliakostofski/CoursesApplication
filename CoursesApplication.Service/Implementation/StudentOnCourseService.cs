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
    public class StudentOnCourseService : IStudentOnCourseService
    {
        private readonly ICourseService courseService;
        private readonly ISemesterService semesterService;
        private readonly IRepository<StudentOnCourse> repository;

        public StudentOnCourseService(ICourseService courseService, ISemesterService semesterService, IRepository<StudentOnCourse> repository)
        {
            this.courseService = courseService;
            this.semesterService = semesterService;
            this.repository = repository;
        }

        public Domain.DomainModels.StudentOnCourse DeleteById(Guid id)
        {
            var course = GetById(id);
            if (course == null)
            {
                throw new Exception("not found");
            }
            return repository.Delete(course);
        }

        public Domain.DomainModels.StudentOnCourse EnrollOnCourse(string studentId, Guid courseId, Guid semesterId, bool reEnrolled)
        {
            var course = courseService.GetById(courseId);
            var semester = semesterService.GetById(semesterId);

            var enrollOnCourse = new StudentOnCourse()
            {
                StudentId = studentId,
                CourseId = courseId,
                SemesterId = semesterId,
                Course = course,
                Semester = semester,
            };
            return repository.Insert(enrollOnCourse);
        }

        public void EnrollOnCourse(string? userId, object courseId, object semesterId, object reEnroll)
        {
            throw new NotImplementedException();
        }

        public object EnrollOnCourse(string? userId, object courseId, Guid semesterId, object reEnroll)
        {
            throw new NotImplementedException();
        }

        public List<Domain.DomainModels.StudentOnCourse> GetAll()
        {
            return repository.GetAll(selector:x=>x).ToList();
        }

        public List<Domain.DomainModels.StudentOnCourse> GetAllByPassengerId(string passengerId)
        {
            return repository.GetAll(selector:x=>x, predicate:x=>x.StudentId.Equals(passengerId)).ToList();
        }

        public Domain.DomainModels.StudentOnCourse? GetById(Guid id)
        {
            return repository.Get(selector: x=>x, predicate:x=>x.Id.Equals(id));
        }

        public Domain.DomainModels.StudentOnCourse Insert(Domain.DomainModels.StudentOnCourse flight)
        {
            flight.Id = Guid.NewGuid();
            return repository.Insert(flight);
        }

        public Domain.DomainModels.StudentOnCourse Update(Domain.DomainModels.StudentOnCourse flight)
        {
            return repository.Update(flight);   
        }
    }
}
