namespace Courses_Registration_System.DAL.Entities
{
	public class Course
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public decimal CoursPrice { get; set; }
		public string IconUrl { get; set; }
		public List<CourseDate> CourseDates { get; set; }

    }
}
