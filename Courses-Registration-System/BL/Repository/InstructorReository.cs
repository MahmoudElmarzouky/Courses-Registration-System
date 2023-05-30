using AutoMapper;
using Courses_Registration_System.BL.Helper;
using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.DAL.Database;
using Courses_Registration_System.DAL.Entities;
using Courses_Registration_System.Models;
using Microsoft.EntityFrameworkCore;
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
            instuctorMapped.PhotoUrl = UploadFileHelper.SaveFile(entity.IconFile, "Photos");
          
            dbContext.Instructors.Add(instuctorMapped);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var inst = dbContext.Find<Instructor>(id);
            UploadFileHelper.RemoveFile("Photos", inst.PhotoUrl);
              
            dbContext.Instructors.Remove(inst);
         dbContext.SaveChanges();

        }

        public InstuctorViewModel Get(int id)
        {
            var data = dbContext.Set<Instructor>().FirstOrDefault(a => a.InstructorId == id);
            if (Equals(null, data)) return null;
            return mapper.Map<InstuctorViewModel>(data);

   
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

            if (entity.IconFile != null)
            {
                UploadFileHelper.RemoveFile("Photos", entity.PhotoUrl);
                data.PhotoUrl = UploadFileHelper.SaveFile(entity.IconFile, "Photos");
            }
            dbContext.Set<Instructor>().Update(data);

            dbContext.SaveChanges();
        }
    }
}
