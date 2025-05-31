using CoursesApplication.Domain.DomainModels;
using CoursesApplication.Domain.DTO;
using CoursesApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Implementation
{
    public class DataFetchService : IDataFetchService
    {
        private readonly ICourseService courseService;
        private readonly HttpClient _httpClient;

        public DataFetchService(ICourseService courseService, HttpClient httpClient)
        {
            this.courseService = courseService;
            _httpClient = httpClient;
        }

        public async Task<List<Course>> FetchCoursesFromApi()
        {
            var courseDTO = await _httpClient.GetFromJsonAsync<List<CourseDTO>>("http://is-lab4.ddns.net:8080/courses");
            var courses = courseDTO.Select(x => new Course()
            {
                Id = Guid.NewGuid(),
                Name = x.Title,
                SemesterType = x.semesterType,
                Credits = x.ECTS,
            }).ToList();

            courseService.InsertMany(courses);
            return courses;
        }
    }
}
