using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Domain.Entities;
using MedicalCertificate.Infrastructure.Data;

namespace MedicalCertificate.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

    }
}