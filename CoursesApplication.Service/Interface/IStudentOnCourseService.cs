using CoursesApplication.Domain.DomainModels;

namespace CoursesApplication.Service.Interface;

public interface IStudentOnCourseService
{
    StudentOnCourse EnrollOnCourse(string studentId, Guid courseId, Guid semesterId, bool reEnrolled);

    List<StudentOnCourse> GetAll();
    List<StudentOnCourse> GetAllByPassengerId(string passengerId);
    StudentOnCourse? GetById(Guid id);
    StudentOnCourse Insert(StudentOnCourse flight);
    StudentOnCourse Update(StudentOnCourse flight);
    StudentOnCourse DeleteById(Guid id);
    void EnrollOnCourse(string? userId, object courseId, object semesterId, object reEnroll);
    object EnrollOnCourse(string? userId, object courseId, Guid semesterId, object reEnroll);
}