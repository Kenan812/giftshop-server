using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.PermissionRole
{
    public class CreatePermissionRoleDto
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public int PermissionId { get; set; }
    }
}
