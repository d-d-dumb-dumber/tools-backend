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
        ValidateExistingUser(request);
        UserDto user = new(request);
        await repository.AddUser(user);
        await unitOfWork.Save();
    }

    private async void ValidateExistingUser(CreateUserRequest request)
    {
        var isValid = true;
        var errors = new List<string>();
        
        if (await repository.GetUserByUsername(request.Username) != null)
        {
            isValid = false;
            errors.Add(Messages.ConflictUsername);
        }
        if (await repository.GetUserByEmail(request.Email) != null)
        {
            isValid = false;
            errors.Add(Messages.ConflictEmail);
        }

        if (!isValid) throw new LoginConflictException(errors);
    }
}

