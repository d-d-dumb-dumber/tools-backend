using Domain.DTOs;
using Domain.Exceptions;
using Domain.Models.Requests;
using Domain.Repositories;
using Domain.Resources;
using Domain.UnitOfWork;

namespace Application.UseCases.CreateUser;

public class CreateUser(IUserRepository repository, IUnitOfWork unitOfWork) : ICreateUser
{
    public async Task Execute(CreateUserRequest request)
    {
        if (await repository.GetUser(request.Username, request.Email) != null)
        {
            throw new LoginConflictException(Messages.InvalidLogin);
        }
        
        UserDto user = new(request);
        await repository.AddUser(user);
        await unitOfWork.Save();
    }
}

