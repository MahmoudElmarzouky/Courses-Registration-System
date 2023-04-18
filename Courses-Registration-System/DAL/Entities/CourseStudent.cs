namespace Courses_Registration_System.DAL.Entities
{
	public class CourseStudent
	{
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseDateId { get; set; }
        public CourseDate CourseDate { get; set; }
    }
}
