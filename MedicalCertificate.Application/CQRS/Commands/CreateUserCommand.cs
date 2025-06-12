using MedicalCertificate.Application.DTOs;
using KDS.Primitives.FluentResult;
using MediatR;
using System.Text.Json.Serialization;

namespace MedicalCertificate.Application.CQRS.Commands
{
    public class CreateUserCommand : IRequest<Result<UserDto>>
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("roleId")]
        public int RoleId { get; set; }
    }
}