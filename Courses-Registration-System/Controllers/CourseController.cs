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
					repository.Add(course);
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
            var course = repository.Get(id);
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
                    repository.Update(course);
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
            var course = repository.Get(id);
            if (course == null)
                return View();

            return View(course);
        }

        [HttpPost]
        public IActionResult Delete(int id ,CourseViewModel course)
        {
            try
            {
                if (id!=null)
                    repository.Delete(id);
                
                    return RedirectToAction("Index", "Course");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
