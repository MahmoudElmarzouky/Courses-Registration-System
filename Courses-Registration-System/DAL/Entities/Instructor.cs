namespace Courses_Registration_System.DAL.Entities
{
	public class Instructor
	{
		public int InstructorId { get; set; }
		public string InstructorName { get; set; }
		public string InstructorEmail { get; set; }
        public string PhoneNumber { get; set; }
		public string PhotoUrl { get; set; }
        public DateTime BirthDate { get; set;}
        public  bool Gender { get; set; }
        public List<CourseInstructor> CourseInstructors { get; set; }

    }
}
