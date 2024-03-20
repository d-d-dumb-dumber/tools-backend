using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests;

public class LoginUserRequest(string username, string password)
{
    [Required(AllowEmptyStrings = false)]
    public string UsernameOrEmail { get; } = username;

    [Required(AllowEmptyStrings = false)] 
    public string Password { get; } = password;
}

