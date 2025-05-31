
namespace CoursesApplication.Web.Controllers
{
    public class EnrollOnCourseDTO
    {
        public object CourseId { get; internal set; }
        public Guid SemesterId { get; internal set; }
        public bool ReEnroll { get; internal set; }
    }
}