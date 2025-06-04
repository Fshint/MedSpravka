using MedicalCertificate.Domain.Entities;
using MedicalCertificate.Domain.Enums;

namespace MedicalCertificate.Domain.Interfaces;

public interface ICertificateRepository
{
    Task AddAsync(Entities.MedicalCertificate certificate);
    Task<Entities.MedicalCertificate?> GetByIdAsync(Guid id);
    Task<IEnumerable<Entities.MedicalCertificate>> GetByIINAsync(string iin); 
    Task UpdateStatusAsync(Guid id, CertificateStatus status, string? reviewerComment = null);
    Task<IEnumerable<Entities.MedicalCertificate>> GetByIinAsync(string iin);
}