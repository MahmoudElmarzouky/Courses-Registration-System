using System.Security.Claims;
using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.DAL.Entities;
using Courses_Registration_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Registration_System.Controllers
{
	public class CourseController : Controller
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUnitOfWork _unitOfWork;
		private string? _userIdentityId;
		private int? _studentId;

		public CourseController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
		{
			_httpContextAccessor = httpContextAccessor;
			_unitOfWork = unitOfWork;
			_userIdentityId = httpContextAccessor.HttpContext?.User.
				FindFirst(ClaimTypes.NameIdentifier)
				?.Value;
			_studentId = _unitOfWork.Students.GetAll().
				FirstOrDefault(student => student.UserIdentityId == _userIdentityId)?.StudentId;
		}
        public IActionResult Index()
		{
			return View(_unitOfWork.Courses.GetAll());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
        public IActionResult Create(CourseViewModel course)
        {
			try
			{
				if (ModelState.IsValid)
				{
					_unitOfWork.Courses.Add(course);
					return RedirectToAction("Index", "Course");
				}
				else
				{
					return View(course);
                }
            
			}catch (Exception ex)
			{
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var course = _unitOfWork.Courses.Get(id);
            if (course == null)
                return View();

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Courses.Update(course);
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    return View(course);
                }

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var course = _unitOfWork.Courses.Get(id);
            if (course == null)
                return View();

            return View(course);
        }

        [HttpPost]
        public IActionResult Delete(int id ,CourseViewModel course)
        {
            try
            {
                    _unitOfWork.Courses.Delete(id);
                    return RedirectToAction("Index", "Course");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        // TODO Course Details
        public IActionResult Details(int id)
        {
	        var course = _unitOfWork.Courses.Get(id);
	        if (course == null)
		        return View();

	        return View(course);
        }

        [HttpPost]
        public IActionResult Details(int id ,CourseViewModel course)
        {
	        try
	        {
		        _unitOfWork.Courses.Delete(id);
		        return RedirectToAction("Index", "Course");
	        }
	        catch (Exception ex)
	        {
		        return View();
	        }
        }
        
        // TODO Course AddToStudent
        public IActionResult AddToStudent(int id)
        {
	        _unitOfWork.Students.AddCourse((int)_studentId, id);
			_unitOfWork.Complete();
			return RedirectToAction("Index", "Student");
        }

        public IActionResult PutInSchedule(int id)
        {
	        var model = new CourseScheduleInputModel
	        {
				Id = id
	        };
	        return View(model);
        }
        [HttpPost]
        public IActionResult PutInSchedule(CourseScheduleInputModel model)
        {
	        // TODO add the course to Schedule 
	        
	        _unitOfWork.Courses.AddSchedule(model.Id, model.StartTime,model.EndTime);
	        _unitOfWork.Complete();
	        return RedirectToAction("Index", _unitOfWork.Courses.GetAll());
        }
        
	}
}
