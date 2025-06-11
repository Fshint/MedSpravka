using MedicalCertificate.Application.Interfaces;
using FluentResults;
using MediatR;

namespace MedicalCertificate.Application.CQRS.Commands
{
    public class DeleteUserCommandHandler(IUserService userService)
        : IRequestHandler<DeleteUserCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await userService.DeleteAsync(request.Id);

            if (result.IsFailed)
                return Result.Fail<bool>(result.Errors);

            return result;
        }
    }
}