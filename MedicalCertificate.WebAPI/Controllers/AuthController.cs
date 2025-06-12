using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.CQRS.Commands;
using MediatR;
using MedicalCertificate.WebAPI.Contracts;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace MedicalCertificate.WebAPI.Controllers;

[Route("api/[controller]")]
public class AuthController(IMediator mediator) : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginContract request)
    {
        var result = await mediator.Send(request.Adapt<LoginCommand>());

        if (result.IsFailed)
            return GenerateProblemResponse(result.Errors);

        return Ok(result.Value);
    }
}