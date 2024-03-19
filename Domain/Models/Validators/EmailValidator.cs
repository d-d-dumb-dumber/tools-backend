using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Domain.Resources;

namespace Domain.Models.Validators;

public class EmailValidator : ValidationAttribute 
{
    public EmailValidator()
    {
        this.ErrorMessage = Messages.InvalidEmail;
    }
    public override bool IsValid(object? value)
    {
        return value != null && MailAddress.TryCreate(value.ToString(), out _);
    }
}
