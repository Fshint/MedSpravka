using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Domain.Constants;
using FluentResults;
using MediatR;

namespace MedicalCertificate.Application.CQRS.Queries
{
    public class GetUserByUsernameQueryHandler(IUserService userService)
        : IRequestHandler<GetUserByUsernameQuery, Result<UserDto?>>
    {
        public async Task<Result<UserDto?>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await userService.GetByUsernameAsync(request.Username);

            if (user.IsFailed)
                return Result.Fail<UserDto?>(user.Errors);

            return user;
        }
    }
}