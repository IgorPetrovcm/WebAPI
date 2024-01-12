namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;


public class UserAuth : Controller
{
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register([FromBody] string path)
    {
        return RedirectPermanent(path);
    }
}