using Courses_Registration_System.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses_Registration_System.DAL.Database
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Crate Relation between Course Date and Student 

			// Create Composite Primary Key  for talble  CourseStudent 
			modelBuilder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.CourseDateId, cs.StudentId });
			// Create relation 1 to many Between CourseStudent and Student
			modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.CourseStudents)
				.HasForeignKey(cs => cs.StudentId);
			// Create relation 1 to many Between CourseStudent and CourseDate
			modelBuilder.Entity<CourseStudent>()
				.HasOne(cs => cs.CourseDate)
				.WithMany(c => c.CourseStudents)
				.HasForeignKey(cs => cs.CourseDateId);

			// Crate Relation between Course Date and Instructor 

			// Create Composite Primary Key  for talble  CourseInstructor 
			modelBuilder.Entity<CourseInstructor>()
				.HasKey(ci => new { ci.CourseDateId, ci.InstructorId });
			// Create relation 1 to many Between CourseInstructor and Instructor
			modelBuilder.Entity<CourseInstructor>()
				.HasOne(ci => ci.Instructor)
				.WithMany(i => i.CourseInstructors)
				.HasForeignKey(ci => ci.InstructorId);
			// Create relation 1 to many Between CourseInstructor and CourseDate
			modelBuilder.Entity<CourseInstructor>()
				.HasOne(ci => ci.CourseDate)
				.WithMany(i => i.CourseInstructors)
				.HasForeignKey(ci => ci.CourseDateId);

			// Create relation 1 to many Between Courses and CourseDate
			modelBuilder.Entity<CourseDate>()
				.HasOne(cc => cc.Course)
				.WithMany(c => c.CourseDates)
				.HasForeignKey(cc => cc.CourseId);
		}
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set;}
        public DbSet<CourseDate> CourseDates { get; set;}
        public DbSet<CourseStudent> CourseStudents { get; set;}
        public DbSet<CourseInstructor> CourseInstructors { get; set;}



    }
}
