using Application.Dtos.Permission;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<Permission> GetAsync(int permissionId);
        Task<IEnumerable<Permission>> GetAllAsync();
        Task<int> CreateAsync(CreatePermissionDto data);
        Task<int> UpdateAsync(UpdatePermissionDto data);
        Task<int> DeleteAsync(int permissionId);
    }   
}
