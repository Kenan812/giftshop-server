using Application.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserDto loginCredentials)
        {
            try
            {
                return Ok(await _authService.LoginAsync(loginCredentials));
            }
            catch (NullReferenceException)
            {
                return NotFound("No user with such email");
            }
            catch (InvalidSignInException)
            {
                return BadRequest("Password is invalid");
            }
            catch (Exception)
            {
                return BadRequest("Unable to login");
            }

        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterUserDto registerCreadentials)
        {
            try
            {
                return Ok(await _authService.RegisterAsync(registerCreadentials));
            }
            catch (RecordAlreadyExistException)
            {
                return BadRequest("User with such email already exists");
            }
            catch (Exception)
            {
                return BadRequest("Unable to register user");
            }  
        }
    }
}
