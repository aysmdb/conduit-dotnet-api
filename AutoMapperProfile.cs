using AutoMapper;
using conduit_dotnet_api.Models.Entities;
using conduit_dotnet_api.Models.Requests;
using conduit_dotnet_api.Models.Responses;

namespace conduit_dotnet_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegistrationRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.User.Password))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));

            CreateMap<User, UserResponse>()
                .ForPath(dest => dest.User.Email, opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.User.Username, opt => opt.MapFrom(src => src.Username))
                .ForPath(dest => dest.User.Bio, opt => opt.MapFrom(src => src.Bio))
                .ForPath(dest => dest.User.Image, opt => opt.MapFrom(src => src.Image));
        }
    }
}
