using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]
        public string RoleName { get; set; } = String.Empty;

        public List<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
