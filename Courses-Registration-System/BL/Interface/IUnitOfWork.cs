using Courses_Registration_System.Models;

namespace Courses_Registration_System.BL.Interface;

public interface IUnitOfWork: IDisposable
{
    public IRepository<StudentViewModel> Students { get; }
    public void Complete();
}