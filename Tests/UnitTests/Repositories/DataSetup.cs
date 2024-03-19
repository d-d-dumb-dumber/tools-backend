using Domain.DTOs;
using Domain.Entities;

namespace UnitTests.Repositories;

public static class DataSetup
{
    public static readonly UserDto NewUserDto = new ("newusername", "newemail", "password", "salt");
    public static readonly User NewUser = new ("newusername", "newemail", "password", "salt");
    public static readonly UserDto UserDto = new ("username", "email", "password", "salt");
    public static readonly User User = new ("username", "email", "password", "salt");
    public const string EXISTING_USERNAME = "username";
    public const string NON_EXISTING_USERNAME = "invalidUsername";
}
