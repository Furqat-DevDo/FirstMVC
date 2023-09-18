using Microsoft.AspNetCore.Mvc;
using Registration.Application.Users.Services;

namespace MVCProject.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult>Index()
    {
        var users = await _userService.GetAllAsync();
        return View(users);
    }
}