using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Courses_Registration_System.Controllers
{
	public class HomeController : Controller
	{
	

		public HomeController()
		{

		}

		public IActionResult Index()
		{
			return View();
		}

	

	}
}