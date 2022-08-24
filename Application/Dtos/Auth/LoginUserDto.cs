using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Auth
{
    public class LoginUserDto
    {
        [Required]
        [MaxLength(StringLengthConstants.LengthXs)]
        [RegularExpression(RegexConstants.EmailRegex, ErrorMessage = "Email is not in valid format.")]
        public string Email { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = String.Empty;
    }
}
