using Application.Dtos.Auth;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUserDto, User>();
        }
    }
}
