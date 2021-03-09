using Newtonsoft.Json;
using SbsApplication.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SbsApplication.Services.ApiServices
{
    public interface ILoginApiService
    {
        Task<ILoginViewModel> AuthenticateUser(ILoginViewModel loginViewModel);
        Task<bool> RegisterUser(IUserViewModel userViewModel);
    }
    public class LoginApiService : ILoginApiService
    {
        Uri baseAddress = new Uri("http://localhost:3688/api/Login");
        readonly HttpClient client;

        public LoginApiService()
        {
            client = new HttpClient
            {
                BaseAddress = baseAddress
            };
        }

        public async Task<ILoginViewModel> AuthenticateUser(ILoginViewModel loginViewModel)
        {
            string data = JsonConvert.SerializeObject(loginViewModel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var address = client.BaseAddress + "/authenticate";
            var response = await client.PostAsync(address, content);

            if (response.IsSuccessStatusCode)
            {
                string returnData = response.Content.ReadAsStringAsync().Result;
                var newData = JsonConvert.DeserializeObject<LoginViewModel>(returnData);

                return newData;
            }

            return null;
        }

        public async Task<bool> RegisterUser(IUserViewModel userViewModel)
        {
            string data = JsonConvert.SerializeObject(userViewModel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var address = client.BaseAddress + "/register";
            var response = await client.PostAsync(address, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
