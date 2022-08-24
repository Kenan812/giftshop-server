using Application.Dtos.Role;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, GetRoleDto>();
            CreateMap<Role, GetAllRolesDto>();

            CreateMap<UpdateRoleDto, Role>();
            CreateMap<CreateRoleDto, Role>();
        }
    }
}
