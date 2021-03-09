using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sbs.Api.Data.Entities;
using Sbs.Api.Models;
using System.Threading.Tasks;
using Xunit;

namespace Sbs.Api.Test.LoginControllerTest
{
    public class When_Register_Called_With_ValidUser : Given_A_LoginController
    {
        [Fact]
        public async Task Then_Valid_User_Is_Added_To_DB()
        {
            //Arrange
            const string userName = "myLoginName";
            MockRepository.Setup(x => x.IsLoginNameExists(It.IsAny<string>())).Returns(false);
            MockRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(true));
            MockMapper.Setup(x => x.Map<User>(It.IsAny<RegisterUserModel>())).Returns(new User());

            //Act
            var actionResult = await TestComponent.Register(new RegisterUserModel() { LoginName = userName });

            //Assert
            var result = actionResult as CreatedResult;
            var registedUser = result.Value as RegisterUserModel;
            registedUser.LoginName.Should().Be(userName);
        }

        [Fact]
        public async Task Then_For_User_Already_Existing_Will_Not_Be_Registered()
        {
            //Arrange
            MockRepository.Setup(x => x.IsLoginNameExists(It.IsAny<string>())).Returns(true);
            MockMapper.Setup(x => x.Map<User>(It.IsAny<RegisterUserModel>())).Returns(new User());

            //Act
            var actionResult = await TestComponent.Register(new RegisterUserModel());

            //Assert
            var result = actionResult as BadRequestObjectResult;
            result.Value.Should().NotBeNull();

            var messageInfo = result.Value.GetType().GetProperty("Message").GetValue(result.Value);
            messageInfo.Should().Be("Login name already Exists.");
        }

        [Fact]
        public async Task Then_Valid_User_Name_Then_Add_Method_Is_Called()
        {
            //Arrange
            const string userName = "myLoginName";
            MockRepository.Setup(x => x.IsLoginNameExists(It.IsAny<string>())).Returns(false);
            MockRepository.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult(true));
            MockMapper.Setup(x => x.Map<User>(It.IsAny<RegisterUserModel>())).Returns(new User() { LoginName = userName });

            //Act
            var actionResult = await TestComponent.Register(new RegisterUserModel() { LoginName = userName });

            //Assert
            MockRepository.Verify(x => x.Add<User>(It.Is<User>(u => u.LoginName.Equals(userName))), Times.Once);
        }
    }
}
