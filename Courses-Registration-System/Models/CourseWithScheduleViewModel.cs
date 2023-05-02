using Courses_Registration_System.DAL.Entities;

namespace Courses_Registration_System.Models;

public class CourseWithScheduleViewModel
{
    public int? CourseId { get; set; }
    public string CourseName { get; set; }
    public decimal CoursPrice { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? CourseIcon { get; set; } 
   

}