using FluentResults;
using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Domain.Constants;
using MedicalCertificate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.Services
{
    public class UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserService
    {
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<Result<UserDto>> GetByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                RoleId = user.RoleId,
            };
            return Result.Ok(userDto);
        }
        
        public async Task<Result<UserDto?>> GetByUsernameAsync(string username)
        {
            var user = await unitOfWork.Users.GetByUsernameWithRoleAsync(username);

            if (user == null)
            {
                return Result.Fail<UserDto?>(
                    new Error($"Пользователь с именем {username} не найден.")
                        .WithMetadata("ErrorCode", ErrorCode.NotFound));

            }

            var userDto = new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                RoleId = user.RoleId,
                RoleName = user.Role?.Name ?? string.Empty
            };

            return userDto;
        }

        public async Task<Result<UserDto>> CreateAsync(UserDto userDto)
        {
            try
            {
                var user = new User
                {
                    UserName = userDto.UserName,
                    RoleId = userDto.RoleId,
                };

                await userRepository.AddAsync(user);
                
                return Result.Ok(userDto);
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Ошибка при создании пользователя").CausedBy(ex));
            }
        }

        public async Task<Result<UserDto>> UpdateAsync(int id, UserDto userDto)
        {
            var existingUser = await userRepository.GetByIdAsync(id);

            if (existingUser == null)
                return Result.Fail<UserDto>("Пользователь не найден");

            existingUser.UserName = userDto.UserName;
            existingUser.RoleId = userDto.RoleId;

            userRepository.Update(existingUser);

            return Result.Ok(userDto);
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Fail("Пользователь не найден");

            userRepository.Remove(user);
            return Result.Ok(true);
        }
    }
}