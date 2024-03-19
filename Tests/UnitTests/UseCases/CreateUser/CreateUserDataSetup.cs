using Domain.Models.Requests;

namespace UnitTests.UseCases.CreateUser;

public static class CreateUserDataSetup
{
    public static readonly CreateUserRequest validUser = new("usuario", "email", "senha");
}
