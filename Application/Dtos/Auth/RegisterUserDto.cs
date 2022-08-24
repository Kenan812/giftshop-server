using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Auth
{
    public class RegisterUserDto
    {
        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        [MaxLength(StringLengthConstants.LengthXxs)]
        public string LastName { get; set; } = String.Empty;

        [Required]
        [MaxLength(StringLengthConstants.LengthXs)]
        [RegularExpression(
            RegexConstants.EmailRegex,
            ErrorMessage = "Email is not in valid format.")]
        public string Email { get; set; } = String.Empty;


        [Required]
        [RegularExpression(RegexConstants.PasswordRegex, ErrorMessage = "Password is not in valid format.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = String.Empty;

        [Required]
        public int RoleId { get; set; }

    }
}
