using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Registration.Application.Attributes;

namespace MVCProject.Models;

public class RegisterViewModel
{
    [NameValidator]
    public required string FullName { get; set; }
    
    [EmailAddress]
    public required  string Email { get; set; }

    [PasswordPropertyText,PasswordValidator]
    public required string Password { get; set; }
}