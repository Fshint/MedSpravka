using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Infrastructure.Services;
using System.Threading.Tasks;

namespace MedicalCertificate.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);
        
        public IRoleRepository Roles => _roleRepository ??= new RoleRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}