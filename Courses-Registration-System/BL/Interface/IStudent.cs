using Courses_Registration_System.Models;

namespace Courses_Registration_System.BL.Interface;

public interface IStudent: IRepository<StudentViewModel>
{
    public IQueryable<MyCourseViewModel> GetMyCourses(int id);
    IQueryable<MyCourseViewModel> GetAllCourses();
    void AddCourse(int studentId, int id);
}