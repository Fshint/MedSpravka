using MedicalCertificate.Domain.Entities;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        Task<int> SaveChangesAsync();
    }
}