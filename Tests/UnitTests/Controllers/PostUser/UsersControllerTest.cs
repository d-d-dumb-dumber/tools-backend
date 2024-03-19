using Application.UseCases.PostUser;
using Domain.Exceptions;
using Domain.Models.Requests;
using Domain.Resources;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using WebApi.Controllers.PostUser;
using Xunit;

namespace UnitTests.Controllers.PostUser;

public class UsersControllerTest
{
    private readonly UsersController _controller;
    private readonly Mock<IPostUser> _postUser;

    public UsersControllerTest()
    {
        this._postUser = new Mock<IPostUser>();
        this._controller = new UsersController(_postUser.Object);
    }

    [Fact]
    public async Task Test_PostUser_Valid_Request()
    {
        ConfigureObjectValidator();
        var successRequest = JsonConvert.DeserializeObject<PostUserRequest>("{\"Username\":\"name\",\"Email\":\"email@email.com\",\"Password\":\"password\"}");
        var result = await this._controller.PostUser(successRequest!);
        Assert.IsType<NoContentResult>(result);
        this._postUser.Verify(x => x.Execute(successRequest!), Times.Once);
    }

    [Fact]
    public async Task Test_PostUser_Invalid_Request_Missing_Fields()
    {
        ConfigureObjectValidator();
        var request = JsonConvert.DeserializeObject<PostUserRequest>("{\"Username\":\" \",\"Email\":\" \",\"Password\":\" \"}");
        try
        {
            await this._controller.PostUser(request!);
        }
        catch (InvalidRequestException exception)
        {
            var errors = exception.ErrorMessages;
            Assert.Equal(3, errors.Count);
            Assert.Contains("The Username field is required.", errors);
            Assert.Contains("The Password field is required.", errors);
            Assert.Contains(Messages.InvalidEmail, errors);
        }
    }

    [Theory]
    [InlineData("{\"Username\":\"username\",\"Email\":\"email@email\",\"Password\":\"Psswrd\"}")]
    [InlineData("{\"Username\":\"username\",\"Email\":\"email\",\"Password\":\"Psswrd\"}")]
    [InlineData("{\"Username\":\"username\",\"Email\":\"email.com\",\"Password\":\"Psswrd\"}")]
    [InlineData("{\"Username\":\"username\",\"Email\":\"email@\",\"Password\":\"Psswrd\"}")]
    public async Task Test_PostUser_Invalid_Request_Invalid_Email_Format(string? requestModel)
    {
        ConfigureObjectValidator();
        var request = JsonConvert.DeserializeObject<PostUserRequest>(requestModel!);
        try
        {
            await this._controller.PostUser(request!);
        }
        catch (InvalidRequestException exception)
        {
            var errors = exception.ErrorMessages;
            Assert.Equal(1, errors.Count);
            Assert.Contains(Messages.InvalidEmail, errors);
        }
    }

    private void ConfigureObjectValidator()
    {
        this._controller.ObjectValidator = new ObjectValidator();
    }
}
