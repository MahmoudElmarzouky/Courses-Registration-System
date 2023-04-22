using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Registration_System.Controllers;

public class StudentController: Controller
{
    private readonly IRepository<StudentViewModel> _studentRepository;
    public StudentController(IRepository<StudentViewModel> studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public IActionResult Index()
    {
        return View(_studentRepository.GetAll());
    }

    
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(StudentViewModel model)
    {
        _studentRepository.Add(model);
        return View("Index");
    }
}