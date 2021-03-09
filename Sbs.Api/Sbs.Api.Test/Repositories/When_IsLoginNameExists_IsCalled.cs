using FluentAssertions;
using Sbs.Api.Contexts;
using Sbs.Api.Data.Entities;
using Sbs.Api.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Sbs.Api.Test
{
    public class When_IsLoginNameExists_IsCalled : Given_A_SbsDbRepository
    {
        [Fact]
        public void Then_Default_LoginNameExists_Returns_True()
        {
            var options = BuildDbContext("LoginNameExitsDb");
            using (var context = new SbsDbContext(options))
            {
                TestComponent = new SbsDbRepository(context);

                var result = TestComponent.IsLoginNameExists("r");

                result.Should().BeTrue();
            }
            
        }

        [Fact]
        public void Then_Invalid_LoginNameExists_Returns_False()
        {
            var options = BuildDbContext("LoginNameDoesNotExitsDb");
            using (var context = new SbsDbContext(options))
            {
                //Arrange
                TestComponent = new SbsDbRepository(context);
                //Act
                var result = TestComponent.IsLoginNameExists("b");
                //Assert
                result.Should().BeFalse();
            }
        }

        [Fact]
        public async Task Then__After_NewUserAdded_Valid_LoginNameExists_Returns_True()
        {
            var options = BuildDbContext("NewUserAddedDb");
            using (var context = new SbsDbContext(options))
            {
                //Arrange
                TestComponent = new SbsDbRepository(context);
                TestComponent.Add<User>(new User() { Id = 2, Name = "newName", LoginName = "a", Password = "pass1" });
                await TestComponent.SaveChangesAsync();

                //Act
                var result = TestComponent.IsLoginNameExists("a");

                //Assert
                result.Should().BeTrue();
            }
        }
    }
}
