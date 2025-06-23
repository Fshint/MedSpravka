using MediatR;
using KDS.Primitives.FluentResult;

namespace MedicalCertificate.Application.CQRS.Commands;

public class ApproveCertificateCommand(int certificateId, int approvedByUserId) : IRequest<Result>
{
    public int CertificateId { get; init; } = certificateId;
    public int ApprovedByUserId { get; init; } = approvedByUserId;
}