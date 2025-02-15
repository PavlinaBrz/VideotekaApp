using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VideotekaApp.Models;

namespace VideotekaApp.Controllers.Films;

public class FilmsController : Controller
{
    private readonly ILogger<FilmsController> _logger;

    public FilmsController(ILogger<FilmsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
