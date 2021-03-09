using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sbs.Api.Test.HangmanControllerTest
{
     public class When_GetWords_Called_With_Invalid_WordType : Given_A_HangmanController
    {

        [Fact]
        public async Task Then_For_Undefined_WordType_WordsList_Is_Returned()
        {
            //Arrange
            //MockRepository.Setup(x => x.GetWordsAsync(It.IsAny<WordType>())).Returns(Task.FromResult(new string[] { "Italy", "India" }));

            //Act
            var actionResult = await TestComponent.GetWords(3);

            //Assert
            var result = actionResult as BadRequestObjectResult;
            result.Value.Should().NotBeNull();

            var messageInfo = result.Value.GetType().GetProperty("Message").GetValue(result.Value);
            messageInfo.Should().Be("WordType not matching should be 0, 1 or 2.");
        }
    }
}
