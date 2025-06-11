using MedicalCertificate.Application.DTOs;
using FluentResults;
using MediatR;

namespace MedicalCertificate.Application.CQRS.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<Result<UserDto?>>;
}