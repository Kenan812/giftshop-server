using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]
        public string LastName { get; set; } = String.Empty;

        [Required]
        [MaxLength(StringLengthConstants.LengthXs)]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;

        [Required]
        [MaxLength(StringLengthConstants.LengthLg)]
        public byte[] PasswordHash { get; set; } = new byte[StringLengthConstants.LengthLg];


        [Required]
        [MaxLength(StringLengthConstants.LengthLg)]
        public byte[] PasswordSalt { get; set; } = new byte[StringLengthConstants.LengthLg];

        public DateTime DateOfRegistration { get; set; } = DateTime.Now;

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; } = new Role();
    }
}
