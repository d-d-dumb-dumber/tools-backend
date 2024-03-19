using Infrastructure.DataAccess.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests.Repositories;

public class UserRepositoryTest
{
    
    [Fact]
    public async Task Test_AddUser()
    {
        await using var context = StartDatabase();
        var repository = new UserRepository(context);
        await repository.AddUser(DataSetup.NewUserDto);
        await context.SaveChangesAsync();
        Assert.Contains(DataSetup.NewUser, context.Users);
    }
    
    [Fact]
    public async Task Test_Get_Existing_User()
    {
        await using var context = StartDatabase();
        var repository = new UserRepository(context);
        var result = await repository.GetUser(DataSetup.EXISTING_USERNAME);
        Assert.Equal(DataSetup.UserDto, result);
    }
    
    [Fact]
    public async Task Test_Get_Non_Existing_User()
    {
        await using var context = StartDatabase();
        var repository = new UserRepository(context);
        var result = await repository.GetUser(DataSetup.NON_EXISTING_USERNAME);
        Assert.Null(result);
    }

    private ToolsContext StartDatabase()
    {
        var options = new DbContextOptionsBuilder<ToolsContext>()
            .UseInMemoryDatabase(databaseName: "tools_db")
            .Options;
        
        var context = new ToolsContext(options);
        context.Database.EnsureDeleted();
        context.Users.Add(DataSetup.User);
        context.SaveChanges();
        return context;
    }
}
