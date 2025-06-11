using MedicalCertificate.Application.DTOs;
using FluentResults;

namespace MedicalCertificate.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDTO>> LoginAsync(LoginDTO loginDto);
        Task<Result<AuthResponseDTO>> RegisterAsync(RegisterDTO registerDto);
    }
}