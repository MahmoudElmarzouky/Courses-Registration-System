using AutoMapper;
using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.DAL.Database;
using Courses_Registration_System.Models;

namespace Courses_Registration_System.BL.Repository;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IRepository<StudentViewModel> Students { get; }
    public UnitOfWork(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        Students = new StudentRepository(_dbContext, mapper);
    }
    public void Complete()
    {
        _dbContext.SaveChanges();
    }
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}