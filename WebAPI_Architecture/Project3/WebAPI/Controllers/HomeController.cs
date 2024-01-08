using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;


public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}