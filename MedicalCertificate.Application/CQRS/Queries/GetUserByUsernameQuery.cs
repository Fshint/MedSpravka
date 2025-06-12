using MedicalCertificate.Application.DTOs;
using KDS.Primitives.FluentResult;
using MediatR;

namespace MedicalCertificate.Application.CQRS.Queries
{
    public record GetUserByUsernameQuery(string Username) : IRequest<Result<UserDto?>>;
}