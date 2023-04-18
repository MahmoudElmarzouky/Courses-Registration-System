namespace Courses_Registration_System.DAL.Entities
{
	public class Student
	{
		public int StudentId { get; set; }
		public string StudentName { get; set; }
		public string StudentEmail { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime BirthDate { get; set; }
		public int Gender { get; set; }
		public int CourseStudentId { get; set; }
		public CourseStudent CourseStudent { get; set; }

    }
}
