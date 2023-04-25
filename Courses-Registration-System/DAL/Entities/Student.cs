namespace Courses_Registration_System.DAL.Entities
{
	public class Student
	{
		public string UserIdentityId { get; set; } = String.Empty;
		public int StudentId { get; set; }
		public string StudentName { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string PhotoUrl { get; set; } = string.Empty;
		public DateTime BirthDate { get; set; }
		public bool Gender { get; set; }
		public List<CourseStudent> CourseStudents { get; set; } = new();
	}
}
