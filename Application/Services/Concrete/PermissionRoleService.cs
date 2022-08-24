using Application.Dtos.PermissionRole;
using Application.Services.Interfaces;
using Data;
using Domain.Entities;

namespace Application.Services.Concrete
{
    public class PermissionRoleService : IPermissionRoleService
    {
        private readonly DataContext _dataContext;

        public PermissionRoleService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddPermissionToRole(CreatePermissionRoleDto data)
        {
            Role? role = await _dataContext.Roles.FindAsync(data.RoleId);
            Permission? permission = await _dataContext.Permissions.FindAsync(data.PermissionId);

            if (role == null || permission == null) throw new NullReferenceException();
            if (role.Permissions.Contains(permission) || permission.Roles.Contains(role)) return false;

            role.Permissions.Add(permission);
            permission.Roles.Add(role);

            await _dataContext.SaveChangesAsync();
            return true;
        }

        public Task<bool> RemovePermission(int roleId, int permissionId)
        {
            throw new NotImplementedException();
        }
    }
}
