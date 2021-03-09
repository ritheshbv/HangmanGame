using Microsoft.EntityFrameworkCore;
using Sbs.Api.Contexts;
using Sbs.Api.Data.Entities;
using Sbs.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sbs.Api.Repositories
{
    public class SbsDbRepository : ISbsDbRepository
    {
        private readonly SbsDbContext _ctx;

        public IEnumerable<User> Users { get; set; }

        public SbsDbRepository(SbsDbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<User> ValidateUserAsync(LoginModel loginModel)
        {
            IQueryable<User> query = _ctx.Users;
            query = query.Where(u => u.LoginName.Equals(loginModel.LoginName) && u.Password.Equals(loginModel.Password));

            return await query.FirstOrDefaultAsync();
        }

        public bool IsLoginNameExists(string loginName)
        {
            return _ctx.Users.Any(u => u.LoginName.Equals(loginName));
        }

        public void Add<T>(T entity) where T : class
        {
            _ctx.Add(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return await ( _ctx.SaveChangesAsync()) > 0;
        }

        public async Task<string[]> GetWordsAsync(WordType wordType)
        {
            IQueryable<WordDictionary> query = _ctx.Dictionary;
            query = query.Where(w => w.WordType.Equals(wordType));
            return await query.Select(w => w.Word).ToArrayAsync();
        }

        public string[] GetWords(WordType wordType)
        {
            IQueryable<WordDictionary> query = _ctx.Dictionary;
            query = query.Where(w => w.WordType.Equals(wordType));
            return query.Select(w => w.Word).ToArray();
        }
    }
}
