using Domain.Exceptions;
using Domain.Resources;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests.Repositories;

public class UserRepositoryTest
{
    
    [Fact]
    public async Task Test_Add_New_User()
    {
        await using var context = StartDatabase();
        var repository = new UserRepository(context);
        await repository.AddUser(DataSetup.NewUserDto);
        await context.SaveChangesAsync();
        Assert.Contains(DataSetup.NewUser, context.Users);
    }
    
    [Fact]
    public async Task Test_Add_Existing_Username_User()
    {
        await using var context = StartDatabase();
        var repository = new UserRepository(context);
        try
        {
            await repository.AddUser(DataSetup.UserDto);
            await context.SaveChangesAsync();
        }
        catch (LoginConflictException exception)
        {
            Assert.DoesNotContain(DataSetup.NewUser, context.Users);
            Assert.Equal(Messages.ConflictUsername, exception.Message);
        }
    }
    
    [Fact]
    public async Task Test_Get_Existing_User_By_Username()
    {
        await using var context = StartDatabase();
        var repository = new UserRepository(context);
        var result = await repository.GetUserByUsername(DataSetup.EXISTING_USERNAME);
        Assert.Equal(DataSetup.UserDto, result);
    }
    
    [Fact]
    public async Task Test_Get_Non_Existing_Username()
    {
        await using var context = StartDatabase();
        var repository = new UserRepository(context);
        var result = await repository.GetUserByUsername(DataSetup.NON_EXISTING_USERNAME);
        Assert.Null(result);
    }
    
    [Fact]
    public async Task Test_Get_Existing_User_By_Email()
    {
        await using var context = StartDatabase();
        var repository = new UserRepository(context);
        var result = await repository.GetUserByEmail(DataSetup.EXISTING_EMAIL);
        Assert.Equal(DataSetup.UserDto, result);
    }
    
    [Fact]
    public async Task Test_Get_Non_Existing_Email()
    {
        await using var context = StartDatabase();
        var repository = new UserRepository(context);
        var result = await repository.GetUserByEmail(DataSetup.NON_EXISTING_EMAIL);
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
