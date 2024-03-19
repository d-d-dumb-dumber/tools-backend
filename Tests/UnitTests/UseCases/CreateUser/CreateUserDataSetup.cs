using Domain.Models.Requests;

namespace UnitTests.UseCases.CreateUser;

public static class CreateUserDataSetup
{
    public static readonly PostUserRequest validUser = new("usuario", "email", "senha");
}
