using Application.Dtos.Auth;
using Application.Services.Interfaces;
using AutoMapper;
using Core.Exceptions;
using Core.Helpers;
using Data;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private PasswordEncrypter _encrypter;

        public AuthService(DataContext dataContext, IMapper mapper, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _encrypter = new PasswordEncrypter();
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginUserDto data)
        {
            User? user = _dataContext.Users.Where(u => u.Email == data.Email).FirstOrDefault();
            if (user == null)
                throw new NullReferenceException();

            if (!_encrypter.VerifyPasswordHash(data.Password, user.PasswordHash, user.PasswordSalt))
                throw new InvalidSignInException();

            return CreateToken(user);
        }

        public async Task<string> RegisterAsync(RegisterUserDto data)
        {
            if (_dataContext.Users.Any(u => String.Equals(u.Email, data.Email)))
                throw new RecordAlreadyExistException();

            _encrypter.CreatePasswordHash(data.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User newUser = _mapper.Map<User>(data);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            newUser.DateOfRegistration = DateTime.Now;

            _dataContext.Users.Add(newUser);
            await _dataContext.SaveChangesAsync();

            return CreateToken(newUser);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken
            (
                claims:claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
