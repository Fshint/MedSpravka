using MedicalCertificate.Application.DTOs;
using FluentResults;
using MediatR;

namespace MedicalCertificate.Application.CQRS.Queries
{
    public record GetUserByUsernameQuery(string Username) : IRequest<Result<UserDto?>>;
}