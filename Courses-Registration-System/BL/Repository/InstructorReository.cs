using AutoMapper;
using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.DAL.Database;
using Courses_Registration_System.DAL.Entities;
using Courses_Registration_System.Models;
using NuGet.Protocol.Core.Types;

namespace Courses_Registration_System.BL.Repository
{
    public class InstructorReository : IRepository<InstuctorViewModel>
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public InstructorReository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


        public void Add(InstuctorViewModel entity)
        {

            var instuctorMapped = mapper.Map<Instructor>(entity);
            dbContext.Instructors.Add(instuctorMapped);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var inst = dbContext.Find<Instructor>(id);
            dbContext.Instructors.Remove(inst);
         dbContext.SaveChanges();

        }

        public InstuctorViewModel Get(int id)
        {
            var data = dbContext.Instructors.Where(a => a.InstructorId == id).ToList();

            var instuctorMapped = mapper.Map<InstuctorViewModel>(data);

            return instuctorMapped;

            
                                            
        }

        public IQueryable<InstuctorViewModel> GetAll()
        {
            var instructor = dbContext.Instructors;
            var instructorMapped = mapper.Map<List<InstuctorViewModel>>(instructor.AsQueryable());
            return instructorMapped.AsQueryable();
        }

        public InstuctorViewModel Search(object obj)
        {
            throw new NotImplementedException();
        }

        public void Update(InstuctorViewModel entity)
        {
            // Mapping
            var data = mapper.Map<Instructor>(entity);
            dbContext.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            dbContext.SaveChanges();
        }
    }
}
