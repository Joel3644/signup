using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dervishi.joel._5i.PrimaWeb.Models;

namespace dervishi.joel._5i.PrimaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    static readonly List<Product> product = new();
    static readonly List<User> users = new();

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
        return View();
    }

    public IActionResult Purchase()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Cart()
    {
        return View(product);
    }
    
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult SignUp(User u)
    {
        return View(u);
    }
    
    [HttpPost]
    public IActionResult Conferma(User u)
    {
        users.Add(u);
        return View(u);
    }
    
    [HttpPost]
    public IActionResult Purchase(Product p)
    {
        product.Add(p);
        return View(p);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}