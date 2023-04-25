using Courses_Registration_System.DAL.Entities;

namespace Courses_Registration_System.Models;

public class CourseWithScheduleViewModel: CourseViewModel
{
    public List<CourseDate> CourseDates { get; set; } = new();
}