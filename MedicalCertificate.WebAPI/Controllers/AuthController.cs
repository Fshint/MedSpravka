using MedicalCertificate.Application.DTOs;
using MedicalCertificate.Application.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalCertificate.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await mediator.Send(command);

            if (result.IsFailed)
            {
                return GenerateProblemResponse(result.Error);
            }

            return Ok(result.Value);
        }
    }
}