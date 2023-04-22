using AutoMapper;
using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.DAL.Database;
using Courses_Registration_System.DAL.Entities;
using Courses_Registration_System.Models;

namespace Courses_Registration_System.BL.Repository;

public class StudentRepository: IRepository<StudentViewModel>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public StudentRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public IQueryable<StudentViewModel> GetAll()
    {
        var studentList = _dbContext.Set<Student>().ToList();
        var studentListViewModel = _mapper.Map<List<StudentViewModel>>(studentList);
        return studentListViewModel.AsQueryable();
    }

    public StudentViewModel Get(int id)
    {
        var student = _dbContext.Set<Student>().FirstOrDefault(current => current.StudentId == id);
        if (Equals(null, student)) return null;
        return _mapper.Map<StudentViewModel>(student);
    }

    public void Add(StudentViewModel studentViewModel)
    {
        var student = _mapper.Map<Student>(studentViewModel);
        _dbContext.Set<Student>().Add(student);
    }

    public void Delete(int id)
    {
        var studentViewModel = Get(id);
        if (Equals(null, studentViewModel)) return;
        var student = _mapper.Map<Student>(studentViewModel);
        _dbContext.Set<Student>().Remove(student);
    }

    public void Update(StudentViewModel studentViewModel)
    {
        var student = _mapper.Map<Student>(studentViewModel);
        _dbContext.Set<Student>().Update(student);
    }

    public StudentViewModel Search(object obj)
    {
        throw new NotImplementedException();
    }
}