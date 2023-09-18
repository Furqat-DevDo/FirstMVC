using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using Registration.Application.Registrations.Requests;
using Registration.Application.Registrations.Services;
using Registration.Application.Users.Services;


namespace MVCProject.Controllers;

public class RegistrationController : Controller
{
     private readonly IRegistrationService _registrationService;

    public RegistrationController(IRegistrationService registrationService, 
        IUserService userService)
    {
        _registrationService = registrationService;
    }

    [HttpGet]
    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async  Task<ActionResult> Register([FromForm] RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        await _registrationService.CreateUserAsync(new CreateUserRequest
        {
            FullName = model.FullName,
            EmailAddress = model.Email,
            Password = model.Password,
        });

        return RedirectToAction(actionName:"Index",controllerName:"User");
    }
}