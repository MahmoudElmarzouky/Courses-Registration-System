using System.Security.Claims;
using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Registration_System.Controllers;

[Authorize]
public class StudentController: Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private string? _userIdentityId;
    public StudentController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _userIdentityId = httpContextAccessor.HttpContext?.User.
            FindFirst(ClaimTypes.NameIdentifier)
            ?.Value;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Create(string userId)
    {
        var model = new StudentViewModel { UserIdentityId = userId };
        return View(model);
    }
    [HttpPost]
    public IActionResult Create(StudentViewModel model)
    {
        _unitOfWork.Students.Add(model);
        _unitOfWork.Complete();
        return View("Index", _unitOfWork.Students.GetAll());
    }

    public IActionResult MyCourses()
    {
        var id = _unitOfWork.Students.GetAll().
            FirstOrDefault(student => student.UserIdentityId == _userIdentityId)?.StudentId;
        if (id == null) 
            return View();
        var myCourses = _unitOfWork.Students.GetMyCourses((int)id);
        return View(myCourses);
    }
    public IActionResult AllCourses()
    {
        throw new NotImplementedException();
        var allCourses = _unitOfWork.Students.GetAllCourses();
        return View("MyCourses", allCourses);
    }
}