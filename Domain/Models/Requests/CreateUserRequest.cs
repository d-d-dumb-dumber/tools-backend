using System.ComponentModel.DataAnnotations;
using Domain.Models.Validators;

namespace Domain.Models.Requests;

public class CreateUserRequest(string username, string email, string password)
{
    [Required(AllowEmptyStrings = false)]
    public string Username { get; } = username;
    
    [EmailValidator]
    public string Email { get; } = email;

    [Required(AllowEmptyStrings = false)]
    public string Password { get; } = password;
}
