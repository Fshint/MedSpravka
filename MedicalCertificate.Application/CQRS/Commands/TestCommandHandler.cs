using MediatR;
using MedicalCertificate.Domain.Entities;
using MedicalCertificate.Domain.Enums;
using MedicalCertificate.Domain.Interfaces;

namespace MedicalCertificate.Application.CQRS.Commands;

public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand, Guid>
{
    private readonly ICertificateRepository _repository;

    public CreateCertificateCommandHandler(ICertificateRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
    {
        var certificate = new Domain.Entities.MedicalCertificate
        {
            Id = Guid.NewGuid(),
            IIN = request.Iin,
            FullName = request.FullName,
            StartDate = request.Date,
            EndDate = request.Date,
            Status = CertificateStatus.Pending
        };

        await _repository.AddAsync(certificate);
        return certificate.Id;
    }
}