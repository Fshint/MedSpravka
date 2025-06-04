using MedicalCertificate.Domain.Enums;
using MedicalCertificate.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MedicalCertificateEntity = MedicalCertificate.Domain.Entities.MedicalCertificate;

namespace MedicalCertificate.Infrastructure.Data;

public class CertificateRepository : ICertificateRepository
{
    private readonly AppDbContext _context;

    public CertificateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MedicalCertificateEntity certificate)
    {
        _context.Certificates.Add(certificate);
        await _context.SaveChangesAsync();
    }

    public async Task<MedicalCertificateEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Certificates.FindAsync(id);
    }
    
    public async Task<IEnumerable<MedicalCertificateEntity>> GetByIINAsync(string iin)
    {
        return await _context.Certificates
            .Where(c => c.IIN == iin)
            .ToListAsync();
    }

    public async Task UpdateStatusAsync(Guid id, CertificateStatus status, string? reviewerComment = null)
    {
        var cert = await _context.Certificates.FindAsync(id);
        if (cert != null)
        {
            cert.Status = status;
            cert.ReviewerComment = reviewerComment;
            await _context.SaveChangesAsync();
        }
    }

    public Task<IEnumerable<MedicalCertificateEntity>> GetByIinAsync(string iin)
    {
        throw new NotImplementedException();
    }
}