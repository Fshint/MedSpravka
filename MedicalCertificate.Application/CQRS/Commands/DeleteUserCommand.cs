using FluentResults;
using MediatR;
using System;

namespace MedicalCertificate.Application.CQRS.Commands
{
    public record DeleteUserCommand(int id) : IRequest<Result<bool>>;

}