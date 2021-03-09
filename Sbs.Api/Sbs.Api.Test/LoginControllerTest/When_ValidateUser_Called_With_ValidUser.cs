using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sbs.Api.Data.Entities;
using Sbs.Api.Models;
using System.Threading.Tasks;
using Xunit;

namespace Sbs.Api.Test.LoginControllerTest
{
    public class When_ValidateUser_Called_With_ValidUser: Given_A_LoginController
    {

        [Fact]
        public async Task Then_Valid_User_Is_Returned()
        {
            //Arrange
            MockRepository.Setup(x => x.ValidateUserAsync(It.IsAny<LoginModel>())).Returns(Task.FromResult(new User() ));

            //Act
            var actionResult = await TestComponent.ValidateUser(new LoginModel());

            //Assert
            var result = actionResult as OkObjectResult;
            var userResult = result.Value as User;
            userResult.Should().NotBeNull();
            userResult.Should().BeOfType(typeof(User));
        }

        [Fact]
        public async Task Then_Valid_User_LoginName_Is_Returned()
        {
            //Arrange
            const string LoginName = "myLoginName";
            MockRepository.Setup(x => x.ValidateUserAsync(It.IsAny<LoginModel>())).Returns(Task.FromResult(new User() { Id =1, Name="someName", LoginName= LoginName }));

            //Act
            var actionResult = await TestComponent.ValidateUser(new LoginModel());

            //Assert
            var result = actionResult as OkObjectResult;
            var userResult = result.Value as User;
            userResult.Should().NotBeNull();
            userResult.LoginName.Should().Be(LoginName);
        }

        [Fact]
        public async Task Then_Valid_User_Name_Is_Returned()
        {
            //Arrange
            const string Name = "myName";
            MockRepository.Setup(x => x.ValidateUserAsync(It.IsAny<LoginModel>())).Returns(Task.FromResult(new User() { Id = 1, Name = Name, LoginName = "LoginName" }));

            //Act
            var actionResult = await TestComponent.ValidateUser(new LoginModel());

            //Assert
            var result = actionResult as OkObjectResult;
            var userResult = result.Value as User;
            userResult.Should().NotBeNull();
            userResult.Name.Should().Be(Name);
        }
    }
}
