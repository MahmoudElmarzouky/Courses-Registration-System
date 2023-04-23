namespace Courses_Registration_System.Models;

public class MyCourseViewModel
{
    public int CourseId { get; set; }
    public string CourseName { get; set; } = string.Empty;
    public decimal CoursePrice { get; set; }
    public string CourseIconPath { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}