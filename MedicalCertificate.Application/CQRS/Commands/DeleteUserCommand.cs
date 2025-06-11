using FluentResults;
using MediatR;
using System;

namespace MedicalCertificate.Application.CQRS.Commands
{
    public class DeleteUserCommand : IRequest<Result<bool>>
    {
        public int Id { get; set; } 
    }
}