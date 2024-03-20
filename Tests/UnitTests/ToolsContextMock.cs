using Domain.DTOs;
using Domain.Entities;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace UnitTests;

public static class ToolsContextMock
{
    public static ToolsContext StartNewContext()
    {
        var options = new DbContextOptionsBuilder<ToolsContext>()
            .UseInMemoryDatabase(databaseName: "tools_db")
            .Options;
        
        var context = new ToolsContext(options);
        context.Database.EnsureDeleted();
        context.Users.Add(User1);
        context.Users.Add(User2);
        context.Users.Add(User3);
        context.Users.Add(User4);
        context.Users.Add(User5);
        context.Users.Add(User6);
        context.Users.Add(User7);
        context.Users.Add(User8);
        context.Users.Add(User9);
        context.SaveChanges();
        return context;
    }

    public static readonly User User1 = new("user1", "user1@gmail.com", "password", "salt");
    public static readonly User User2 = new("user2", "user2@gmail.com", "password", "salt");
    public static readonly User User3 = new("user3", "user3@gmail.com", "password", "salt");
    public static readonly User User4 = new("user4", "user4@gmail.com", "password", "salt");
    public static readonly User User5 = new("user5", "user5@gmail.com", "password", "salt");
    public static readonly User User6 = new("user6", "user6@gmail.com", "password", "salt");
    public static readonly User User7 = new("user7", "user7@gmail.com", "password", "salt");
    public static readonly User User8 = new("user8", "user8@gmail.com", "password", "salt");
    public static readonly User User9 = new("user9", "user9@gmail.com", "password", "salt");
    public static readonly UserDto NewUser1Dto = new("NewUser1", "NewUser1@gmail.com", "password", "salt");
    public static readonly UserDto ExistingUserNameDto = new("user1", "NewUser2@gmail.com", "password", "salt");
    public static readonly User NewUser1 = new("NewUser1", "NewUser1@gmail.com", "password", "salt");
    public static readonly User ExistingUserName = new("user1", "NewUser2@gmail.com", "password", "salt");
}
