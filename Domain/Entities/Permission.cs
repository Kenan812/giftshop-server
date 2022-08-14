using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]
        public string PemissionName { get; set; } = String.Empty;

        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
