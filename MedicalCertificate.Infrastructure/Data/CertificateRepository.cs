using MedicalCertificate.Domain.Enums;
using MedicalCertificate.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MedicalCertificateEntity = MedicalCertificate.Domain.Entities.MedicalCertificate;

namespace MedicalCertificate.Infrastructure.Data;

public class CertificateRepository(AppDbContext context) : ICertificateRepository
{
    public async Task AddAsync(MedicalCertificateEntity certificate)
    {
        context.Certificates.Add(certificate);
        await context.SaveChangesAsync();
    }

    public async Task<MedicalCertificateEntity?> GetByIdAsync(Guid id)
    {
        return await context.Certificates.FirstOrDefaultAsync(x => x.Id == id); 
    }
    
    public async Task<IEnumerable<MedicalCertificateEntity>> GetByIINAsync(string iin)
    {
        return await context.Certificates
            .Where(c => c.IIN == iin)
            .ToListAsync();
    }

    public async Task UpdateStatusAsync(Guid id, CertificateStatus status, string? reviewerComment = null)
    {
        var cert = await context.Certificates.FindAsync(id);
        if (cert != null)
        {
            cert.Status = status;
            cert.ReviewerComment = reviewerComment;
            await context.SaveChangesAsync();
        }
    }

    public Task<IEnumerable<MedicalCertificateEntity>> GetByIinAsync(string iin)
    {
        throw new NotImplementedException();
    }
}