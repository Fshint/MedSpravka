using MedicalCertificate.Application.DTOs;
using KDS.Primitives.FluentResult;

namespace MedicalCertificate.Application.Interfaces
{
    public interface IAuthService
    {
        Task<Result<AuthResponseDTO>> LoginAsync(LoginDTO loginDto);
    }
}