using Domain.Models.Requests;

namespace Application.UseCases.PostUser;

public interface IPostUser
{
    public Task Execute(PostUserRequest request);
}
