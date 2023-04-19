using AutoMapper;
using Courses_Registration_System.DAL.Entities;
using Courses_Registration_System.Models;

namespace Courses_Registration_System.BL.Mapper
{
	public class DomainProfile:Profile
	{
		public DomainProfile() {
			CreateMap<CourseViewModel,Course>()
				.ForMember(
					dest => dest.IconUrl,
					src => src.MapFrom(src => src.IconName)
				).ReverseMap();
		}
	}
}
