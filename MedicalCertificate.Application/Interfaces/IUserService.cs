using MedicalCertificate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}