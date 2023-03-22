using System.Diagnostics;

using CarWorkshop.MVC.Models;

using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers;

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

    public IActionResult Privacy()
    {
        var model = new List<Person>()
        {
            new Person()
            {
                FirstName="Piotr",
                LastName="Kowalsk"
            },
            new Person()
            {
                FirstName="Karol",
                LastName="Krawczyk"
            }
        };

        return View(model);
    }

    public IActionResult About()
    {
        var model = new About()
        {
            Title = "About",
            Description = "This is the About page",
            Tags = new string[]
            {
                "Tag 1",
                "Tag 2",
                "Tag 3"
            }
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
