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

    [HttpGet]
    public IActionResult Purchase()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))){
            return View("Login");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Cart()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))){
            return View("Login");
        }
        return View(db);
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
        if(p.Name != null){
            db.Products.Add(p);
            db.SaveChanges();
        }
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

    public IActionResult Verify(User u){
        u.ToHash();
        bool Found = false;

        foreach(var thing in db.Users){
            if(thing.Username == u.Username && thing.Password == u.Password){
                HttpContext.Session.SetString("Username", u.Username!);
                Found = true;
                break;
            }
        }
        if(!Found){
            TempData["AlertMessage"] = "Invalid username or password. Please try again.";
            return RedirectToAction("Login");
        }
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int i)
    {
        var query = db.Products.Where(c => c.Id.Equals(i)).ToList();
        foreach (var item in query)
        {
            db.Products.Remove(item);
        }
        db.SaveChanges();
        return View("Cart", db);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}