using MediatR;
using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Domain.Interfaces;

namespace MedicalCertificate.Application.CQRS.Queries;

public class TestCertificateByIdQueryHandler : IRequestHandler<GetCertificateByIdQuery, CreateCertificateDto>
{
    private readonly ICertificateRepository _repository;

    public TestCertificateByIdQueryHandler(ICertificateRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateCertificateDto> Handle(GetCertificateByIdQuery request, CancellationToken cancellationToken)
    {
        var cert = await _repository.GetByIdAsync(request.Id);

        if (cert == null) return null!;

        return new CreateCertificateDto()
        {
            FullName = cert.FullName,
            Iin = cert.IIN,
            StartDate = cert.StartDate,
            EndDate = cert.EndDate,
            Clinic = cert.Clinic,
            Comment = cert.Comment,
        };
    }
}