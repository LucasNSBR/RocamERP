using AutoMapper;
using RocamERP.CrossCutting.Identity.Models;
using RocamERP.CrossCutting.Identity.ViewModels;

namespace RocamERP.Presentation.Web.Mappers
{
    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile()
        {
            CreateMap<RegisterViewModel, RocamAppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<RocamAppUser, OverviewViewModel>()
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => src.EmailConfirmed))
                .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.MapFrom(src => src.PhoneNumberConfirmed))
                .ForMember(dest => dest.TwoFactorEnabled, opt => opt.MapFrom(src => src.TwoFactorEnabled))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Logins, opt => opt.MapFrom(src => src.Logins));
        }
    }
}