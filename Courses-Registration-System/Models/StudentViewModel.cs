namespace Courses_Registration_System.Models;

public class StudentViewModel
{
    public string UserIdentityId { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string StudentEmail { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public bool Gender { get; set; }
}