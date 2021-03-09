using Newtonsoft.Json;
using SbsApplication.Models;
using SbsApplication.Services.ApiServices;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SbsApplication.Services
{
    public interface ILoginService
    {
        Task<bool> AuthenticateUser(ILoginViewModel loginViewModel);

        ILoginViewModel Model { get; }
    }

    public class LoginService :ILoginService
    {
        private readonly ILoginViewModel model;
        private readonly ILoginApiService loginApiService;

        public LoginService(ILoginViewModel loginViewModel, ILoginApiService loginApiService)
        {
            this.model = loginViewModel ?? throw new ArgumentNullException(nameof(loginViewModel));
            this.loginApiService = loginApiService ?? throw new ArgumentNullException(nameof(loginApiService));
        }

        public ILoginViewModel Model => this.model;
        public async Task<bool> AuthenticateUser(ILoginViewModel loginViewModel)
        {
            var result = await this.loginApiService.AuthenticateUser(loginViewModel);

            return result != null;
        }
    }
}
