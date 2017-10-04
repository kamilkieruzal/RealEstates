using AutoMapper;
using RealEstates.Core.Entities;
using RealEstates.Web.ViewModels;

namespace RealEstates.MapperProfiles
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<RegisterUserViewModel, User>();
		}
	}
}