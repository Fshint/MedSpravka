using MediatR;

namespace MedicalCertificate.Application.CQRS.Commands;

public class CreateCertificateCommand : IRequest<Guid>
{
    public string Iin { get; set; }
    public string FullName { get; set; }
    public DateTime Date { get; set; }
}