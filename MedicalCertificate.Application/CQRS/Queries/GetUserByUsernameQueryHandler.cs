using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Domain.Constants;
using KDS.Primitives.FluentResult;
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
                return Result.Failure<UserDto?>(user.Error);

            return user;
        }
    }
}