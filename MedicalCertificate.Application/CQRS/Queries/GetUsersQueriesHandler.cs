using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.Interfaces;
using MediatR;
using FluentResults;
using System.Linq;

namespace MedicalCertificate.Application.CQRS.Queries
{
    public class GetUsersQueryHandler(IUserService userService) : IRequestHandler<GetUsersQuery, Result<UserDto[]>>
    {
        public async Task<Result<UserDto[]>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userService.GetAllAsync();

            if (users == null || !users.Any())
            {
                return Result.Fail<UserDto[]>(
                    new Error("Пользователей нет.")
                        .WithMetadata("ErrorCode", Domain.Constants.ErrorCode.NotFound)
                );
            }

            var userDtos = users.Select(u => new UserDto
            {
                Id = u.Id,
                UserName = u.UserName,
                RoleId = u.RoleId,
                RoleName = "" // добавь при необходимости
            }).ToArray();

            return Result.Ok(userDtos);
        }
    }
}