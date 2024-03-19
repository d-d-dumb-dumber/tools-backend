using Domain.Models.Requests;

namespace Application.UseCases.CreateUser;

public interface ICreateUser
{
    public Task Execute(CreateUserRequest request);
}
