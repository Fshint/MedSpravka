using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Domain.Constants;
using MedicalCertificate.Domain.Entities;
using MedicalCertificate.Domain.Options;
using KDS.Primitives.FluentResult;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace MedicalCertificate.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtConfigurationOptions _jwtConfig;

        public AuthService(IUnitOfWork unitOfWork, IOptions<JwtConfigurationOptions> jwtOptions)
        {
            _unitOfWork = unitOfWork;
            _jwtConfig = jwtOptions.Value;
        }

        public async Task<Result<AuthResponseDTO>> LoginAsync(LoginDTO loginDto)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(loginDto.UserName);

            if (user == null)
            {
                return Result.Failure<AuthResponseDTO>(new Error(ErrorCode.Unauthorized, "Неверное имя пользователя или пароль"));
            }

            bool isPasswordValid = BC.Verify(loginDto.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return Result.Failure<AuthResponseDTO>(new Error(ErrorCode.Unauthorized, "Неверное имя пользователя или пароль"));
            }

            var token = GenerateJwtToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                UserName = user.UserName,
                RoleId = user.RoleId,
                RoleName = user.Role?.Name ?? string.Empty,
                UserId = user.Id
            };
        }

        public async Task<Result<AuthResponseDTO>> RegisterAsync(RegisterDTO registerDto)
        {
            var existingUser = await _unitOfWork.Users.GetByUsernameAsync(registerDto.UserName);

            if (existingUser != null)
            {
                return Result.Failure<AuthResponseDTO>(new Error(ErrorCode.Conflict, "Пользователь с таким именем уже существует"));
            }

            string passwordHash = BC.HashPassword(registerDto.Password);

            var user = new User
            {
                UserName = registerDto.UserName,
                RoleId = registerDto.RoleId,
                PasswordHash = passwordHash
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            var token = GenerateJwtToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                UserName = user.UserName,
                RoleId = user.RoleId,
                RoleName = user.Role?.Name ?? string.Empty,
                UserId = user.Id
            };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role?.Name ?? string.Empty)
                }),
                Expires = DateTime.UtcNow.AddHours(_jwtConfig.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}