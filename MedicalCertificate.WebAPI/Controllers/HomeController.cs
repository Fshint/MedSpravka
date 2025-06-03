using Microsoft.AspNetCore.Mvc;

namespace MedicalCertificate.WebAPI.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}