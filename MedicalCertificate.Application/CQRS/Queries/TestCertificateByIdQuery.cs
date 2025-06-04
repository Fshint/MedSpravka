using MediatR;
using MedicalCertificate.Application.DTOs;

namespace MedicalCertificate.Application.CQRS.Queries;

public class GetCertificateByIdQuery : IRequest<CreateCertificateDto>
{
    public Guid Id { get; set; }

    public GetCertificateByIdQuery(Guid id)
    {
        Id = id;
    }
}
