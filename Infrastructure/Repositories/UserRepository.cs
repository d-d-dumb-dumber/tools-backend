using Domain.DTOs;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(ToolsContext context) : IUserRepository
{
    public async Task AddUser(UserDto userDto)
    {
        User userEntity = new(userDto);
        await context.Users.AddAsync(userEntity);
    }

    public async Task<UserDto?> GetUser(string username)
    {
        var user = await context.Users.Where(user => user.Username == username).SingleOrDefaultAsync();
        return user == null ? null : new UserDto(user);
    }
}