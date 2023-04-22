using Courses_Registration_System.BL.Interface;
using Courses_Registration_System.BL.Repository;
using Courses_Registration_System.DAL.Database;
using Courses_Registration_System.DAL.Entities;
using Courses_Registration_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses_Registration_System
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Add dependency injection for Auto Mapper
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// Add dependency injection For repository 
			builder.Services.AddScoped<IRepository<CourseViewModel>,CourseRepository>();
            builder.Services.AddScoped<IRepository<InstuctorViewModel>, InstructorReository>();
			//builder.Services.AddScoped<IRepository<StudentViewModel>, StudentRepository>();
			builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            // Add dependency injection for connection string 
            builder.Services.AddDbContextPool<ApplicationDbContext>
			(options => options.UseSqlServer(
				builder.Configuration.GetConnectionString("CoursesRegistrationDbConnection")
				,options => options.EnableRetryOnFailure())
				);
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}