using Sbs.Api.Data.Entities;
using Sbs.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sbs.Api.Repositories
{
    public interface ISbsDbRepository
    {
        IEnumerable<User> Users { get; set; }
        Task<User> ValidateUserAsync(LoginModel loginModel);
        void Add<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<string[]> GetWordsAsync(WordType wordType);
        string[] GetWords(WordType wordType);
        bool IsLoginNameExists(string loginName);
    }
}