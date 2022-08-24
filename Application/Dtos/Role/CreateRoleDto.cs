using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Role
{
    public class CreateRoleDto
    {
        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]

        public string RoleName { get; set; } = String.Empty;
    }
}
