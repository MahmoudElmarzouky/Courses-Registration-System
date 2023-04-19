using Microsoft.AspNetCore.Mvc;

namespace Courses_Registration_System.Controllers
{
	public class CourseController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
