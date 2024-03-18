namespace Domain.Entities;

public class User(string name, string email, string password, string salt)
{
    public ulong Id { get; init; }
    public string Name { get; } = name;
    public string Email { get; } = email;
    public string Password { get; } = password;
    public string Salt { get; } = salt;

    protected bool Equals(User other)
    {
        return Name == other.Name && Email == other.Email && Password == other.Password && Salt == other.Salt;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((User)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Email, Password, Salt);
    }

    public static bool operator ==(User? left, User? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(User? left, User? right)
    {
        return !Equals(left, right);
    }
}