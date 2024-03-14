using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dervishi.joel._5i.PrimaWeb.Models;

namespace dervishi.joel._5i.PrimaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    static readonly List<Product> product = new();

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
        HttpContext.Session.SetString("Username", u.Username!);
        HttpContext.Session.SetString("Name", u.Name!);
        HttpContext.Session.SetString("Surname", u.Surname!);
        HttpContext.Session.SetString("Email", u.Email!);
        HttpContext.Session.SetString("DateOfBirth", u.DateOfBirth.ToString()!);
        HttpContext.Session.SetString("Sex", u.Sex!);
        HttpContext.Session.SetString("Password", u.Password!);
        return View(u);
    }
    
    [HttpPost]
    public IActionResult Purchase(Product p)
    {
        product.Add(p);
        return View(p);
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult WelcomeBack()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}