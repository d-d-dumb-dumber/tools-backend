using Application.UseCases.PostUser;
using Domain.DTOs;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.UnitOfWork;
using Domain.Utils;
using Moq;
using Xunit;

namespace UnitTests.UseCases;

public class PostUserUseCaseTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly PostUser _useCase;

        public PostUserUseCaseTest()
        {
            Configuration.SetConfiguration(TestConfigurationBuilder.BuildTestConfiguration());
            this._userRepository = new Mock<IUserRepository>();
            this._unitOfWork = new Mock<IUnitOfWork>();
            this._useCase = new PostUser(_userRepository.Object, _unitOfWork.Object);
        }

        [Fact]
        public async Task Test_PostUser()
        {
            UserDto user = new("usuario", "email", "10", "10");

            await _useCase.Execute(PostUserDataSetup.validUser);
            
            this._userRepository.Verify(repo => repo.AddUser(user), Times.Once);
            this._userRepository.Verify(repo => repo.GetUser("usuario"), Times.Once);
            this._unitOfWork.Verify(x => x.Save(), Times.Once);
            Assert.Equal(PostUserDataSetup.validUser.Username, user.Username);
        }

        [Fact]
        public async Task Test_PostUser_Existing_Login()
        {
            ConfigureUserRepositoryForExistingLogin();
            
            UserDto user = new("usuario", "email", "10", "10");
            
            await Assert.ThrowsAsync<LoginConflictException>(() => _useCase.Execute(PostUserDataSetup.validUser));
            
            this._userRepository.Verify(repo => repo.GetUser("usuario"), Times.Once);
            this._userRepository.Verify(repo => repo.AddUser(user), Times.Never);
            this._unitOfWork.Verify(x => x.Save(), Times.Never);
            Assert.Equal(PostUserDataSetup.validUser.Username, user.Username);
        }

        private void ConfigureUserRepositoryForExistingLogin()
        {
            this._userRepository.Setup(repo => repo.GetUser("usuario")).ReturnsAsync(new UserDto("usuario", "email", "10", "10"));
        }
    }
