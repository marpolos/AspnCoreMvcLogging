using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnCoreMvcLogging.Models;

namespace AspnCoreMvcLogging.Controllers;

public class HomeController : Controller
{
    readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Action Index :: HomeController -> executou" + DateTime.Now.ToLongTimeString());
        return View();
    }

    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page.";
        _logger.LogWarning("Action About :: HomeController -> executou" + DateTime.Now.ToLongTimeString());
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Your contact page.";
        _logger.LogTrace("Action About :: HomeController -> executou" + DateTime.Now.ToLongTimeString());
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
