using Courses_Registration_System.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Courses_Registration_System.Models
{
	public class CourseViewModel
	{
		public int? CourseId { get; set; }
		[Required(ErrorMessage = "Enter Course Name")]
		public string CourseName { get; set; }
		[Required(ErrorMessage = "Enter Course Price")]
		public decimal CoursPrice { get; set; }
       
		public IFormFile IconFile { get; set; }
		public string? IconUrl { get; set; }
		
	}
}
