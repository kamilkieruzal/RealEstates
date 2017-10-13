using AutoMapper;
using RealEstates.Core.Entities;
using RealEstates.Core.Utils;
using RealEstates.ViewModels;
using System.Web;

namespace RealEstates.MapperProfiles
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<RegisterUserViewModel, User>();
			CreateMap<HttpPostedFileBase, Photo>().
				ForMember(dest => dest.PhotoData, opt => opt.MapFrom(src => HttpPostedBaseImageReader.ReadFully(src.InputStream)));
			CreateMap<AddOfferViewModel, Offer>().
				ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos));
		}
	}
}