using Microsoft.AspNetCore.Mvc;

namespace MedicalCertificate.WebAPI.Controllers;

public class CertificateController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}