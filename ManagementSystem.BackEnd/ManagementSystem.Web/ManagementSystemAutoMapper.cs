using AutoMapper;
using ManagementSystem.Data.EntityModels;
using ManagementSystem.Mapping.DTOs;

namespace ManagementSystem.Web
{
    public class ManagementSystemAutoMapper : Profile
    {
        public ManagementSystemAutoMapper() 
        {
            CreateMap<UserDetails, UserDto>();
            CreateMap<UserDetailsDto, UserDetails>();

            CreateMap<UserDetails, UserDetailsDto>();
            CreateMap<UserDetailsDto, UserDetails>();
        }
    }
}