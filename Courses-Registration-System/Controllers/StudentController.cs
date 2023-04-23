using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Registration_System.Controllers;

public class StudentController: Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public StudentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View(_unitOfWork.Students.GetAll());
    }
    public IActionResult Create()
    {
        return View();
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
        // TODO take the identity user Id and get Id of the user 
        var id = 1;
        var myCourses = _unitOfWork.Students.GetMyCourses(id);
        return View(myCourses);
    }
}