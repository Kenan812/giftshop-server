using Application.Dtos.Auth;

namespace Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterUserDto data);
        Task<string> LoginAsync(LoginUserDto data);
    }
}
