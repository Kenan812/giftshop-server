using Application.Dtos.Role;
using Application.Services.Interfaces;
using AutoMapper;
using Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public RoleService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateRoleDto data)
        {
            Role newRole = _mapper.Map<Role>(data);
 
            _dataContext.Roles.Add(newRole);
            await _dataContext.SaveChangesAsync();
            return newRole.Id;
        }

        public async Task<int> DeleteAsync(int roleId)
        {
            Role? roleToDelete = await _dataContext.Roles.FindAsync(roleId);
            if (roleToDelete == null) throw new NullReferenceException();

            _dataContext.Roles.Remove(roleToDelete);
            await _dataContext.SaveChangesAsync();
            return roleToDelete.Id;
        }

        public async Task<IEnumerable<GetAllRolesDto>> GetAllAsync()
        {
            IList<GetAllRolesDto> roles = new List<GetAllRolesDto>(); 
            foreach (Role role in await _dataContext.Roles.ToListAsync())
            {
                roles.Add(_mapper.Map<GetAllRolesDto>(role));
            }
            return roles;
        }

        public async Task<GetRoleDto> GetAsync(int roleId)
        {
            GetRoleDto? role = _mapper.Map<GetRoleDto>( await _dataContext.Roles.FindAsync(roleId));
            if (role == null) throw new NullReferenceException();
            return role;
        }

        public async Task<int> UpdateAsync(UpdateRoleDto data)
        {
            Role? roleToUpdate = await _dataContext.Roles.FindAsync(data.Id);
            if (roleToUpdate == null) throw new NullReferenceException();

            roleToUpdate = _mapper.Map<Role>(data);

            await _dataContext.SaveChangesAsync();
            return roleToUpdate.Id;
        }
    }
}
