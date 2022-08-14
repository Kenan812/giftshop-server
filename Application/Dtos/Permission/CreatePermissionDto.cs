using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Permission
{
    public class CreatePermissionDto
    {
        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]
        public string PermissionName { get; set; } = String.Empty;
    }
}
