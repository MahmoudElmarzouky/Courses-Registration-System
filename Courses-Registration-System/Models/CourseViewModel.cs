using Courses_Registration_System.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Courses_Registration_System.Models
{
	public class CourseViewModel
	{
		public int CourseId { get; set; }
		[Required(ErrorMessage = "Enter Course Name")]
		public string CourseName { get; set; }
		[Required(ErrorMessage = "Enter Course Name")]
		public decimal CoursPrice { get; set; }
		[Required(ErrorMessage = "Enter Course Name")]
		public string IconName { get; set; }
		public IFormFile IconUrl { get; set; }
	}
}
