using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Registration_System.Controllers
{
	public class InstuctorController : Controller
	{
		private readonly IRepository<InstuctorViewModel> repository;

		public InstuctorController(IRepository<InstuctorViewModel> repository)
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
        public IActionResult Create(InstuctorViewModel instructor)
        {
			try
			{
				if (ModelState.IsValid)
				{
					repository.Add(instructor);
					return RedirectToAction("Index", "Instuctor");
				}
				else
				{
					return View(instructor);
                }
            
			}catch (Exception ex)
			{
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var instructor = repository.Get(id);
            if (instructor == null)
                return View();

            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(InstuctorViewModel instructor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Update(instructor);
                    return RedirectToAction("Index", "Instuctor");
                }
                else
                {
                    return View(instructor);
                }

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var instructor = repository.Get(id);
            if (instructor == null)
                return View();

            return View(instructor);
        }

        [HttpPost]
        public IActionResult Delete(InstuctorViewModel instructor)
        {
            try
            {
                if (instructor.InstructorId == null) 
                    return View();
                    int InstructorId = (int)instructor.InstructorId;
                    if(instructor.InstructorId !=null)
                    repository.Delete(InstructorId);
                    return RedirectToAction("Index", "Instuctor");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
