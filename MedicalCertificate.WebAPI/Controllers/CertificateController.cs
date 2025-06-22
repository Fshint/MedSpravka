using MedicalCertificate.Application.CQRS.Commands;
using MedicalCertificate.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MedicalCertificate.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CertificateController(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetCertificateQuery());
        if (result.IsFailed)
            return GenerateProblemResponse(result.Error);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetCertificateByIdQuery(id));
        if (result.IsFailed)
            return GenerateProblemResponse(result.Error);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCertificateCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsFailed)
            return GenerateProblemResponse(result.Error);

        return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateCertificateCommand command)
    {
        var updatedCommand = command with { Id = id };
        var result = await mediator.Send(updatedCommand);

        if (result.IsFailed)
            return GenerateProblemResponse(result.Error);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteCertificateCommand(id));
        if (result.IsFailed)
            return GenerateProblemResponse(result.Error);

        return Ok(result);
    }

}