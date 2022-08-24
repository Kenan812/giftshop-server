using Application.Dtos.Role;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IRoleService
    {
        Task<GetRoleDto> GetAsync(int roleId);
        Task<IEnumerable<GetAllRolesDto>> GetAllAsync();
        Task<int> CreateAsync(CreateRoleDto data);
        Task<int> UpdateAsync(UpdateRoleDto data);
        Task<int> DeleteAsync(int roleId);
    }
}
