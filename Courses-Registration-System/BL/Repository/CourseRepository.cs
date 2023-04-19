using AutoMapper;
using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.DAL.Database;
using Courses_Registration_System.DAL.Entities;
using Courses_Registration_System.Models;
using System.Runtime.Intrinsics.Arm;

namespace Courses_Registration_System.BL.Repository
{
	public class CourseRepository : IRepository<CourseViewModel>
	{
		private readonly ApplicationDbContext dbContext;
		private readonly IMapper mapper;

		public CourseRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
			this.dbContext = dbContext;
			this.mapper = mapper;
		}
        public void Add(CourseViewModel entity)
		{
			var courseMapped=mapper.Map<Course>(entity);
			dbContext.Add(courseMapped);
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public CourseViewModel Get(int id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<CourseViewModel> GetAll()
		{
			var courses = dbContext.Courses;
			var coursesMapped=mapper.Map<List<CourseViewModel>>(courses.AsQueryable());
			return coursesMapped.AsQueryable();
		}

		public void Update(CourseViewModel entity)
		{
			throw new NotImplementedException();
		}
	}
}
