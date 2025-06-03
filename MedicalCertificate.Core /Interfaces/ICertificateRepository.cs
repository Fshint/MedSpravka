using MedicalCertificate.Core.Entities;
using MedicalCertificate.Core.Enums;


namespace MedicalCertificate.Core.Interfaces;

public interface ICertificateRepository
{
    Task AddAsync(Entities.MedicalCertificate certificate);
    Task<Entities.MedicalCertificate?> GetByIdAsync(Guid id);
    Task<IEnumerable<Entities.MedicalCertificate>> GetByIinAsync(string iin);
    Task UpdateStatusAsync(Guid id, CertificateStatus status, string? reviewerComment = null);
}