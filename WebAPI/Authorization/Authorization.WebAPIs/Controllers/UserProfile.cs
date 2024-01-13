namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


public class UserProfile : Controller
{
    [Authorize]
    [HttpGet]
    public IActionResult Profile() => View();
}