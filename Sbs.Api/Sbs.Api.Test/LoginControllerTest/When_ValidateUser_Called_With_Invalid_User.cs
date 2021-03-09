using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sbs.Api.Data.Entities;
using Sbs.Api.Models;
using System.Threading.Tasks;
using Xunit;

namespace Sbs.Api.Test.LoginControllerTest
{
    public class When_ValidateUser_Called_With_Invalid_User: Given_A_LoginController
    {
        [Fact]
        public async Task Then_With_Invalid_UserName_ErrorMessage_Is_Returned()
        {
            //Arrange
            User user = null;
            MockRepository.Setup(x => x.ValidateUserAsync(It.IsAny<LoginModel>())).Returns(Task.FromResult(user));

            //Act
            var actionResult = await TestComponent.ValidateUser(new LoginModel());

            //Assert
            var result = actionResult as BadRequestObjectResult;
            result.Value.Should().NotBeNull();

            var messageInfo = result.Value.GetType().GetProperty("Message").GetValue(result.Value);
            messageInfo.Should().Be("Username or password is incorrect.");
        }
    }
}
