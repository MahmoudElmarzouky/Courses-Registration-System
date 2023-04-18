using Courses_Registration_System.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses_Registration_System.DAL.Database
{
	public class ApplicationDbContext:DbContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set;}
        public DbSet<CourseDate> CourseDates { get; set;}
        public DbSet<CourseStudent> CourseStudents { get; set;}
        public DbSet<CourseInstructor> CourseInstructors { get; set;}



    }
}
