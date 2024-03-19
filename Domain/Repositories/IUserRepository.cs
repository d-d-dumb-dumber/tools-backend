using Domain.DTOs;

namespace Domain.Repositories;

public interface IUserRepository
{
    public Task AddUser(UserDto userDto);
    public Task<UserDto?> GetUser(string username);
}
