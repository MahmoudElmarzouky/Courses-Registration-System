using System.ComponentModel.DataAnnotations;

namespace Courses_Registration_System.Models
{
    public class InstuctorViewModel
    {
        public int InstructorId { get; set; }
        [Required(ErrorMessage = "Enter Instructor Name"),MinLength(20)]
        public string InstructorName { get; set; }
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string InstructorEmail { get; set; }
        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "BirthDate is required.")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime BirthDate { get; set; }

        public bool Gender { get; set; } =false;
        public string? PhotoUrl { get; set; }
        public IFormFile? IconFile { get; set; }

    }
}
