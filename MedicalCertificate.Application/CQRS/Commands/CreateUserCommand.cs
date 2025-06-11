using FluentResults;
using MediatR;
using MedicalCertificate.Application.DTOs;

namespace MedicalCertificate.Application.CQRS.Commands
{
    public class CreateUserCommand : IRequest<Result<UserDto>>
    {
        public string UserName { get; set; }
        public int RoleId { get; set; }
    }
}