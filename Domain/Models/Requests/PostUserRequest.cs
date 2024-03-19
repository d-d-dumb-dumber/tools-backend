using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests;

public class PostUserRequest(string username, string email, string password)
{
    [Required(AllowEmptyStrings = false)]
    public string Username { get; } = username;

    [Required(AllowEmptyStrings = false)]
    public string Email { get; } = email;

    [Required(AllowEmptyStrings = false)]
    public string Password { get; } = password;
}
