using MedicalCertificate.Core.Entities;
using MedicalCertificate.Core.Enums;

namespace MedicalCertificate.Core.Interfaces;

public interface ICertificateRepository
{
    Task AddAsync(MedicalCertificate certificate);
    Task<MedicalCertificate?> GetByIdAsync(Guid id);
    Task<IEnumerable<MedicalCertificate>> GetByIinAsync(string iin);
    Task UpdateStatusAsync(Guid id, CertificateStatus status, string? reviewerComment = null);
}