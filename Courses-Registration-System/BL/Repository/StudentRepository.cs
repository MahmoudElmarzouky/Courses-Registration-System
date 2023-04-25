using AutoMapper;
using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.DAL.Database;
using Courses_Registration_System.DAL.Entities;
using Courses_Registration_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Courses_Registration_System.BL.Repository;

public class StudentRepository: IStudent
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

    public IQueryable<MyCourseViewModel> GetMyCourses(int id)
    {
        var courses = _dbContext.Set<Student>().
            Include(c => c.CourseStudents).
            ThenInclude(c=>c.CourseDate)
            .FirstOrDefault(student => student.StudentId == id)?.
            CourseStudents.
            Select(_convertToMyCourseModel);
        
        return courses.AsQueryable();
    }

    public IQueryable<MyCourseViewModel> GetAllCourses()
    {
        var courses = _dbContext.Set<CourseStudent>().
            Select(_convertToMyCourseModel)
            .OrderBy(course => course.StartDate).
            ThenBy(course => course.EndDate);
        return courses.AsQueryable();
    }

    public void AddCourse(int studentId, int id)
    {
        var studentCourse = new CourseStudent
        {
            StudentId = studentId,
            CourseDateId = id
        };
        var student = _dbContext.Set<Student>().FirstOrDefault(student => student.StudentId == studentId);
        student?.CourseStudents.Add(studentCourse);
    }

    private MyCourseViewModel _convertToMyCourseModel(CourseStudent courseStudent)
    {
        var currentCourse = _dbContext.Set<Course>()
            .FirstOrDefault(course => course.CourseId == courseStudent.CourseDate.CourseId);
        return new MyCourseViewModel
        {
            CourseId = currentCourse.CourseId,
            CourseName = currentCourse.CourseName,
            CoursePrice = currentCourse.CoursPrice,
            StartDate = courseStudent.CourseDate.StartDate,
            EndDate = courseStudent.CourseDate.EndtDate,
            CourseIconPath = currentCourse.IconUrl
        };
    }
}