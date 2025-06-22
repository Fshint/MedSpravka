using MedicalCertificate.Application.DTOs;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Text.Json.Serialization;

namespace MedicalCertificate.Application.CQRS.Commands; 

public class LoginCommand : IRequest<Result<AuthResponseDto>> 
{ 
    public string email { get; set; } = null!;
    
    public string Password { get; set; } = null!; 
}