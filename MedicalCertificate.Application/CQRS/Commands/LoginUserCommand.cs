using MedicalCertificate.Application.DTOs;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Text.Json.Serialization;

namespace MedicalCertificate.Application.CQRS.Commands; 

public class LoginCommand : IRequest<Result<AuthResponseDto>> 
{ 
    [JsonPropertyName("email")] 
    public string email { get; set; } = null!;
        
    [JsonPropertyName("password")]
    public string Password { get; set; } = null!; 
}