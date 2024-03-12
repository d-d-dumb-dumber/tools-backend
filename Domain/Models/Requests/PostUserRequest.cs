using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests;

public class PostUserRequest(string name, string email, string password)
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; } = name;

    [Required(AllowEmptyStrings = false)]
    public string Email { get; } = email;

    [Required(AllowEmptyStrings = false)]
    public string Password { get; } = password;
}
