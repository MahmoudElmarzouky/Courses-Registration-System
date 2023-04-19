using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Registration_System.Controllers
{
	public class CourseController : Controller
	{
		private readonly IRepository<CourseViewModel> repository;

		public CourseController(IRepository<CourseViewModel>repository)
        {
			this.repository = repository;
		}
        public IActionResult Index()
		{
			return View(repository.GetAll());
		}
	}
}
