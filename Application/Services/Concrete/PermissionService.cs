using Application.Dtos.Permission;
using Application.Services.Interfaces;
using Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Concrete
{
    public class PermissionService : IPermissionService
    {
        private readonly DataContext _dataContext;

        public PermissionService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> DeleteAsync(int permissionId)
        {
            Permission? permissionToDelete = await _dataContext.Permissions.FindAsync(permissionId);
            if (permissionToDelete == null) throw new NullReferenceException();

            _dataContext.Permissions.Remove(permissionToDelete);
            await _dataContext.SaveChangesAsync();
            return permissionToDelete.Id;
        }

        public async Task<Permission> GetAsync(int permissionId)
        {
            Permission? permission = await _dataContext.Permissions.FindAsync(permissionId);
            if (permission == null) throw new NullReferenceException();
            return permission;
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            IEnumerable<Permission> permissions = await _dataContext.Permissions.ToListAsync();
            return permissions;
        }

        public async Task<int> UpdateAsync(UpdatePermissionDto data)
        {
            Permission? permissionToUpdate = await _dataContext.Permissions.FindAsync(data.Id);
            if (permissionToUpdate == null) throw new NullReferenceException();
            permissionToUpdate.PemissionName = data.PermissionName;
            await _dataContext.SaveChangesAsync();
            return permissionToUpdate.Id;
        }

        public async Task<int> CreateAsync(CreatePermissionDto data)
        {
            Permission newPermission = new Permission()
            {
                PemissionName = data.PermissionName
            };

            _dataContext.Permissions.Add(newPermission);
            await _dataContext.SaveChangesAsync();
            return newPermission.Id;
        }
    }
}
