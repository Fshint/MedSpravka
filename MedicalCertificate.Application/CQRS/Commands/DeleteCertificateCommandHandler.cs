using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Application.CQRS.Commands;
using KDS.Primitives.FluentResult;
using MediatR;

namespace MedicalCertificate.Application.CQRS.Commands;

public class DeleteCertificateCommandHandler(ICertificateService certificateServiceService) : IRequestHandler<DeleteCertificateCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
    {
        var result = await CertificateService.DeleteAsync(request.id);

        if (result.IsFailed)
            return Result.Failure<bool>(result.Error);

        return result;
    }
}