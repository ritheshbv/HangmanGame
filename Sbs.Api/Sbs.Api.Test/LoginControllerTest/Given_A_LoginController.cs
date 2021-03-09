using AutoMapper;
using Moq;
using Sbs.Api.Controllers;
using Sbs.Api.Repositories;

namespace Sbs.Api.Test.LoginControllerTest
{
    public class Given_A_LoginController
    {
        protected LoginController TestComponent;
        protected Mock<ISbsDbRepository> MockRepository;
        protected Mock<IMapper> MockMapper;

        public Given_A_LoginController()
        {
            MockRepository = new Mock<ISbsDbRepository>();
            MockMapper = new Mock<IMapper>();
            TestComponent = new LoginController(MockRepository.Object, MockMapper.Object);
        }

        public void Dispose()
        {
            TestComponent = null;
        }

    }
}
