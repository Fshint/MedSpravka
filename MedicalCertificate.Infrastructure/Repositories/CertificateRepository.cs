using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Domain.Entities;
using MedicalCertificate.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCertificate.Infrastructure.Repositories;
public class CertificateRepository : Repository<Certificate>, ICertificateRepository
{
    public CertificateRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Certificate>> GetAllWithSupervisorAsync()
    {
        return await _context.Certificates.Include(t => t.Supervisor).ToListAsync();
    }

    public async Task<Certificate?> GetByIdWithSupervisorAsync(int id)
    {
        return await _context.Certificates.Include(t => t.Supervisor).FirstOrDefaultAsync(t => t.Id == id);
    }
}
    
