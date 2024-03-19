using Domain.Models.Requests;

namespace Application.UseCases.CreateUser;

public interface ICreateUser
{
    public Task Execute(PostUserRequest request);
}
