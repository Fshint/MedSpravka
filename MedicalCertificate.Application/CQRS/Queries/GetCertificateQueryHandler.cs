using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Domain.Constants;
using KDS.Primitives.FluentResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.CQRS.Queries;
public class GetCertificateQueryHandler(ICertificateService certificateService) : IRequestHandler<GetCertificateQuery, Result<CertificateDto[]>>

{
    public async Task<Result<CertificateDto[]>> Handle(GetCertificateQuery request, CancellationToken cancellationToken)
    {
        var result = await CertificateService.GetAllAsync();

        if (result.IsFailed)
            return Result.Failure<CertificateDto[]>(new Error(ErrorCode.NotFound, "Справок нет."));

        return result;
    }
}