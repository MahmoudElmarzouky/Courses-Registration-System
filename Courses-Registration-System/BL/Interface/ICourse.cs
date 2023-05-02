using Courses_Registration_System.Models;

namespace Courses_Registration_System.BL.Interface;

public interface ICourse: IRepository<CourseViewModel>
{
    void AddSchedule(CourseScheduleInputModel model);
    public IQueryable<CourseWithScheduleViewModel> ActiveCourses();
}