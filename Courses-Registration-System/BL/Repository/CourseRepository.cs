using AutoMapper;
using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.DAL.Database;
using Courses_Registration_System.Models;

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
			throw new NotImplementedException();
		}

		public void Update(CourseViewModel entity)
		{
			throw new NotImplementedException();
		}
	}
}
