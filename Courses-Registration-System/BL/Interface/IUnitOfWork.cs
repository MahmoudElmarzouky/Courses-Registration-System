using Courses_Registration_System.Models;

namespace Courses_Registration_System.BL.Interface;

public interface IUnitOfWork: IDisposable
{
    public IStudent Students { get; }
    public IRepository<CourseViewModel> Courses { get; }
    public void Complete();
}