namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

public class UserAuth : Controller
{
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register([FromBody] string path)
    {
        return RedirectPermanent(path);
    }
    
    public IActionResult Login() => View();
}