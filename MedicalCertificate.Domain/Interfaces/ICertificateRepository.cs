using MedicalCertificate.Domain.Enums;

namespace MedicalCertificate.Domain.Interfaces;

public interface ICertificateRepository
{
    Task AddAsync(Domain.Entities.MedicalCertificate certificate);
    Task<Domain.Entities.MedicalCertificate?> GetByIdAsync(Guid id);
    Task<IEnumerable<Domain.Entities.MedicalCertificate>> GetByIinAsync(string iin);
    Task UpdateStatusAsync(Guid id, CertificateStatus status, string? reviewerComment = null);
    Task<IEnumerable<Entities.MedicalCertificate>> GetByIINAsync(string iin);
}