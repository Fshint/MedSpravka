using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.Interfaces;
using KDS.Primitives.FluentResult;
using MediatR;

namespace MedicalCertificate.Application.CQRS.Commands
{
    public class CreateUserCommandHandler(IUserService userService)
        : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = new UserDto
            {
                UserName = request.UserName,
                RoleId = request.RoleId,
                RoleName = string.Empty
            };

            var result = await userService.CreateAsync(userDto);

            if (result.IsFailed)
                return Result.Failure<UserDto>(result.Error);

            return result;
        }
    }
}