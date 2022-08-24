using Application.Dtos.PermissionRole;

namespace Application.Services.Interfaces
{
    public interface IPermissionRoleService
    {
        Task<bool> AddPermissionToRole(CreatePermissionRoleDto data);
        Task<bool> RemovePermission(int roleId, int permissionId);
    }
}
