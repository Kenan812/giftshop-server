using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Permission
{
    public class UpdatePermissionDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]
        public string PermissionName { get; set; } = String.Empty;
    }
}
