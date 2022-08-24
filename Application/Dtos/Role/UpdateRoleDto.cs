using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Role
{
    public class UpdateRoleDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]

        public string RoleName { get; set; } = String.Empty;
    }
}
