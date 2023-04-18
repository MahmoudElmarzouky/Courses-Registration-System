namespace Courses_Registration_System.DAL.Entities
{
	public class CourseDate
	{
        public int CourseDateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
        public List<CourseInstructor> CourseInstructors { get; set; }

     

    }
}
