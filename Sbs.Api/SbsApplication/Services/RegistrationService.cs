using SbsApplication.Models;
using SbsApplication.Services.ApiServices;
using System;
using System.Threading.Tasks;

namespace SbsApplication.Services
{
    public interface IRegistrationService
    {
        Task<bool> RegisterUser(IUserViewModel userViewModel);
    }
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserViewModel model;
        private readonly ILoginApiService loginApiService;

        public RegistrationService(IUserViewModel userViewModel, ILoginApiService loginApiService)
        {
            this.model = userViewModel ?? throw new ArgumentNullException(nameof(userViewModel));
            this.loginApiService = loginApiService ?? throw new ArgumentNullException(nameof(loginApiService));
        }

        public async Task<bool> RegisterUser(IUserViewModel userViewModel)
        {
            return await this.loginApiService.RegisterUser(userViewModel);
        }
    }
}
