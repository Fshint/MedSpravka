using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Domain.Enums;
using MedicalCertificate.Domain.Interfaces;

namespace MedicalCertificate.Application.Services;

public class CertificateService
{
    private readonly ICertificateRepository _repository;

    public CertificateService(ICertificateRepository repository)
    {
        _repository = repository;
    }

    public async Task SubmitCertificateAsync(CreateCertificateDto dto, string savedFilePath)
    {
        var cert = new Domain.Entities.MedicalCertificate
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            IIN = dto.Iin,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Clinic = dto.Clinic,
            Comment = dto.Comment,
            FilePath = savedFilePath,
            Status = CertificateStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(cert);
    }

    public async Task ApproveAsync(Guid id)
    {
        await _repository.UpdateStatusAsync(id, CertificateStatus.Approved);
    }

    public async Task RejectAsync(Guid id, string comment)
    {
        await _repository.UpdateStatusAsync(id, CertificateStatus.Rejected, comment);
    }

    public async Task<IEnumerable<Domain.Entities.MedicalCertificate>> GetByIinAsync(string iin)
    {
        return await _repository.GetByIinAsync(iin);
    }
}