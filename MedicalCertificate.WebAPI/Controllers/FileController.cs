using Microsoft.AspNetCore.Mvc;
using MedicalCertificate.Application.Interfaces;
using MedicalCertificate.Application.DTOs;

namespace MedicalCertificate.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileStorageService _fileStorage;

    public FileController(IFileStorageService fileStorage)
    {
        _fileStorage = fileStorage;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] FileUploadRequest request)
    {
        if (request.File is null || request.File.Length is 0)
            return BadRequest("Файл не выбран");

        using var stream = request.File.OpenReadStream();
        await _fileStorage.UploadAsync(request.File.FileName, stream, request.File.ContentType);

        return Ok($"Файл {request.File.FileName} загружен");
    }

    [HttpGet("download/{fileName}")]
    public async Task<IActionResult> Download(string fileName)
    {
        var stream = await _fileStorage.DownloadAsync(fileName);
        return File(stream, "application/octet-stream", fileName);
    }

    [HttpDelete("delete/{fileName}")]
    public async Task<IActionResult> Delete(string fileName)
    {
        await _fileStorage.DeleteAsync(fileName);
        return Ok($"Файл {fileName} удалён");
    }
}
