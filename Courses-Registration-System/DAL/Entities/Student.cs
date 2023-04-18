namespace Courses_Registration_System.DAL.Entities
{
	public class Student
	{
		public int UserIdentityId { get; set; }
		public int StudentId { get; set; }
		public string StudentName { get; set; }
		public string StudentEmail { get; set; }
		public string PhoneNumber { get; set; }
		public string PhotoUrl { get; set; }
		public DateTime BirthDate { get; set; }
		public bool Gender { get; set; }
		public List<CourseStudent> CourseStudents { get; set; }

    }
}
