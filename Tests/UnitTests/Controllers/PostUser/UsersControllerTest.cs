using Application.UseCases.PostUser;
using Domain.Exceptions;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using WebApi.Controllers.PostUser;
using Xunit;

namespace UnitTests.Controllers.PostUser;

public class UsersControllerTest
{
    private readonly UsersController _controller;

    public UsersControllerTest()
    {
        var postUser = new Mock<IPostUser>();
        this._controller = new UsersController(postUser.Object);
    }

    [Fact]
    public async Task TestingSucessPostUser()
    {
        ConfigureObjectValidator();
        var successRequest = JsonConvert.DeserializeObject<PostUserRequest>("{\"Username\":\"name\",\"Email\":\"email\",\"Password\":\"password\"}");
        Assert.NotNull(successRequest);
        var result = await this._controller.PostUser(successRequest!);
        Assert.IsType<NoContentResult>(result);
    }

    [Theory]
    [ClassData(typeof(UserControllerRequestTheoryData))]
    public async Task TestingModelStateValidationPostUser(string model)
    {
        ConfigureObjectValidator();
        var request = JsonConvert.DeserializeObject<PostUserRequest>(model);
        Assert.NotNull(request);
        await Assert.ThrowsAsync<InvalidRequestException>(() => this._controller.PostUser(request!));
    }

    private void ConfigureObjectValidator()
    {
        this._controller.ObjectValidator = new ObjectValidator();
    }
}
