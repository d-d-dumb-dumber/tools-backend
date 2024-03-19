using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models.Requests;
using Domain.Repositories;
using Domain.Resources;
using Domain.UnitOfWork;

namespace Application.UseCases.PostUser;

public class PostUser(IUserRepository repository, IUnitOfWork unitOfWork) : IPostUser
{
    public async Task Execute(PostUserRequest request)
    {
        if (await repository.GetUser(request.Username) != null)
        {
            throw new LoginConflictException(Messages.InvalidLogin);
        }
        
        UserDto user = new(request);
        await repository.AddUser(user);
        await unitOfWork.Save();
    }
}

