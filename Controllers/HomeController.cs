using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using corsTesting.Models;
using Microsoft.AspNetCore.Cors;

namespace corsTesting.Controllers;

[EnableCors]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult getCorsData(string val){
        var data = new { message = val};

        return Ok(data);
    }

    public IActionResult pageCors(){
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
