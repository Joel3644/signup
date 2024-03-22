using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dervishi.joel._5i.PrimaWeb.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features;

namespace dervishi.joel._5i.PrimaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private UserContext db = new UserContext();
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
    public IActionResult Profile(User u)
    {
        u.ToHash();
        foreach(var thing in db.Users){
            if(thing.Username == u.Username && thing.Password == u.Password){
                TempData["AlertMessage"] = "User already exists. Please log in.";
                return View("Login");
            }
        }
        db.Users.Add(u);
        db.SaveChanges();

        HttpContext.Session.SetString("Username", u.Username!);

        return View(u);
    }
    
    [HttpPost]
    public IActionResult Purchase(Product p)
    {
        product.Add(p);
        return View(p);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult UserList()
    {
        return View(db);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}