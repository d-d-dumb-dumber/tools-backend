using System.Text.RegularExpressions;
using Domain.Resources;

namespace Domain.Utils;

public static class Validation
{
    private const string EMAIL_REGEX
        = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
    public static void ValidateNullArgument(this object? obj, string paramName)
    {
        if (obj == null)
        {
            throw new ArgumentException(null, paramName);
        }
    }

    public static void ValidateStringArgumentNotNullOrEmpty(this string? argument, string? paramName = null)
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            throw new ArgumentException(Messages.ArgumentStringNullOrEmpty, paramName);
        }
    }

    public static bool IsValidEmail(this string argument)
    {
        return Regex.IsMatch(argument, EMAIL_REGEX, RegexOptions.IgnoreCase);
    }
}
