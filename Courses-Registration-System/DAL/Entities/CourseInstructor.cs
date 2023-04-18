namespace Courses_Registration_System.DAL.Entities
{
	public class CourseInstructor
	{
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CourseDateId { get; set; }
        public CourseDate CourseDate { get; set; }

    }
}
