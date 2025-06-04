using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCertificate.WebAPI.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    [NonAction]
    public IActionResult GenerateProblemResponse(Error error)
    {
        ProblemDetails problemDetails = error.Message switch
        {
            "UnknownError" => new ProblemDetails
            {
                Title = "Not Found",
                Detail = "Нету данных",
                Status = 404
            },
            
            "BadRequest" => new ProblemDetails
            {
                Title = "Bad Request",
                Detail = "Неправильный запрос",
                Status = 400
            },

            "Unauthorized" => new ProblemDetails
            {
                Title = "Unauthorized",
                Detail = "Не авторизован",
                Status = 401
            },
            "Forbidden" => new ProblemDetails
            {
                Title = "Forbidden",
                Detail = "Доступ запрещён",
                Status = 403
            },
            "Conflict" => new ProblemDetails
            {
                Title = "Conflict",
                Detail = "Конфликт данных",
                Status = 409
            },
            "Validation" => new ProblemDetails
            {
                Title = "Validation Error",
                Detail = "Ошибка валидации",
                Status = 422
            },
            "UnprocessableEntity," => new ProblemDetails
            {
                Title = "Unprocessable Entity",
                Detail = "Невозможно обработать сущность",
                Status = 422
            },
            "TooManyRequests" => new ProblemDetails
            {
                Title = "Too Many Requests",
                Detail = "Слишком много запросов",
                Status = 429
            },
            "ServiceUnavailable" => new ProblemDetails
            {
                Title = "Service Unavailable",
                Detail = "Сервис недоступен",
                Status = 503
            }
        };

        return StatusCode(problemDetails.Status ?? 500, problemDetails);
    }
}