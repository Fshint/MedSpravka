using MedicalCertificate.Application.DTOs;
using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace MedicalCertificate.Application.CQRS.Commands
{
    public class LoginCommand : IRequest<Result<AuthResponseDTO>>
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = null!;
        
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
}