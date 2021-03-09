using Moq;
using Sbs.Api.Controllers;
using Sbs.Api.Repositories;

namespace Sbs.Api.Test.HangmanControllerTest
{
    public class Given_A_HangmanController
    {
        protected HangmanController TestComponent;
        protected Mock<ISbsDbRepository> MockRepository;

        public Given_A_HangmanController()
        {
            MockRepository = new Mock<ISbsDbRepository>();
            TestComponent = new HangmanController(MockRepository.Object);
        }

        public void Dispose()
        {
            TestComponent = null;
        }

    }
}
