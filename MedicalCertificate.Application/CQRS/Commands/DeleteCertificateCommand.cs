using KDS.Primitives.FluentResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCertificate.Application.CQRS.Commands;

public record DeleteCertificateCommand(int id) : IRequest<Result<bool>>;