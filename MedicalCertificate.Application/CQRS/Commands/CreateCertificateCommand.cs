using MedicalCertificate.Application.DTOs;
using KDS.Primitives.FluentResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.CQRS.Commands.CreateCertificateCommand;

public class CreateThemeCommand : IRequest<Result<CertificateDto>>
{
    public string UserId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Clinic { get; set; } = string.Empty;

    public string Comment { get; set; } = string.Empty;

    public int FilePathId { get; set; }

    public int StatusId { get; set; }

    public string ReviewerComment { get; set; } = string.Empty;
}