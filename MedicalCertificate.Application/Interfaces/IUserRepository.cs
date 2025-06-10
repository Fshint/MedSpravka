using MedicalCertificate.Domain.Entities;

namespace MedicalCertificate.Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByUsernameWithRoleAsync(string username);
        Task<User?> GetByIdWithRoleAsync(int id);
        Task<IEnumerable<User>> GetAllWithRolesAsync();
    }
}