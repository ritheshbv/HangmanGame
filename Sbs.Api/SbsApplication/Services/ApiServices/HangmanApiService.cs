using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SbsApplication.Services.ApiServices
{
    public interface IHangmanApiService
    {
        Task<string> GetWord(int level);
    }

    public class HangmanApiService : IHangmanApiService
    {
        Uri baseAddress = new Uri("http://localhost:3688/api/Hangman/");
        HttpClient client;

        public HangmanApiService()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public async Task<string> GetWord(int level)
        {
            var address = client.BaseAddress + level.ToString();
            var response = await client.GetAsync(address);

            if (response.IsSuccessStatusCode)
            {
                string returnData = response.Content.ReadAsStringAsync().Result;
                return returnData;
            }

            return string.Empty;
        }
    }
}
