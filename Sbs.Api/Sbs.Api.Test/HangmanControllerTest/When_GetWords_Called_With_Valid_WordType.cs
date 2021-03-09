using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sbs.Api.Data.Entities;
using System.Threading.Tasks;
using Xunit;

namespace Sbs.Api.Test.HangmanControllerTest
{
    public class When_GetWords_Called_With_Valid_WordType : Given_A_HangmanController
    {

        [Fact]
        public async Task Then_For_Easy_WordType_WordsList_Is_Returned()
        {
            //Arrange
            MockRepository.Setup(x => x.GetWordsAsync(It.IsAny<WordType>())).Returns(Task.FromResult(new string[] { "Italy", "India" }));

            //Act
            var actionResult = await TestComponent.GetWords(0);

            //Assert
            var result = actionResult as OkObjectResult;
            var wordsResult = result.Value as string[];
            
            Assert.Equal(2, wordsResult.Length);
            wordsResult.Should().Contain(x => x == "India");
        }

        [Fact]
        public async Task Then_For_Moderate_WordType_WordsList_Is_Returned()
        {
            //Arrange
            MockRepository.Setup(x => x.GetWordsAsync(It.IsAny<WordType>())).Returns(Task.FromResult(new string[] { "Italy", "India" }));

            //Act
            var actionResult = await TestComponent.GetWords(1);

            //Assert
            var result = actionResult as OkObjectResult;
            var wordsResult = result.Value as string[];

            Assert.Equal(2, wordsResult.Length);
        }

        [Fact]
        public async Task Then_For_Hard_WordType_WordsList_Is_Returned()
        {
            //Arrange
            MockRepository.Setup(x => x.GetWordsAsync(It.IsAny<WordType>())).Returns(Task.FromResult(new string[] { "Italy", "India" }));

            //Act
            var actionResult = await TestComponent.GetWords(2);

            //Assert
            var result = actionResult as OkObjectResult;
            var wordsResult = result.Value as string[];

            Assert.Equal(2, wordsResult.Length);
        }
    }
}
