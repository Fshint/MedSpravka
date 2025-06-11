using MedicalCertificate.Domain.Entities;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalCertificate.Application.DTOs;

namespace MedicalCertificate.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<Result<UserDto?>> GetByIdAsync(int id);
        Task<Result<UserDto?>> GetByUsernameAsync(string username);
        Task<Result<UserDto>> CreateAsync(UserDto userDto);
        Task <Result<UserDto>> UpdateAsync(int id, UserDto userDto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}