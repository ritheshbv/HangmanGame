using Sbs.Api.Repositories;
using Sbs.Api.Contexts;
using Sbs.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Sbs.Api.Test
{
    public class Given_A_SbsDbRepository
    {
        protected ISbsDbRepository TestComponent;

        public Given_A_SbsDbRepository()
        {
        }

        protected DbContextOptions<SbsDbContext> BuildDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<SbsDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            using (var context = new SbsDbContext(options))
            {
                var id = 1;
                context.Users.Add(new User()
                {
                    Id = id,
                    Name = "Rit",
                    Address = "3",
                    LoginName = "r",
                    Password = "pass",
                });

                context.Dictionary.AddRange(
                    new WordDictionary() { Id = id++, WordType = WordType.Easy, Word = "Italy" },
                    new WordDictionary() { Id = id++, WordType = WordType.Easy, Word = "India" },
                    new WordDictionary() { Id = id++, WordType = WordType.Easy, Word = "France" },
                    new WordDictionary() { Id = id++, WordType = WordType.Easy, Word = "Asia" },
                    new WordDictionary() { Id = id++, WordType = WordType.Easy, Word = "Paris" },
                    new WordDictionary() { Id = id++, WordType = WordType.Easy, Word = "Vienna" },
                    new WordDictionary() { Id = id++, WordType = WordType.Easy, Word = "Texas" },
                    new WordDictionary() { Id = id++, WordType = WordType.Easy, Word = "Poole" },
                    new WordDictionary() { Id = id++, WordType = WordType.Moderate, Word = "Denmark" },
                    new WordDictionary() { Id = id++, WordType = WordType.Moderate, Word = "Germany" },
                    new WordDictionary() { Id = id++, WordType = WordType.Moderate, Word = "Munich" },
                    new WordDictionary() { Id = id++, WordType = WordType.Moderate, Word = "England" },
                    new WordDictionary() { Id = id++, WordType = WordType.Moderate, Word = "Scotland" },
                    new WordDictionary() { Id = id++, WordType = WordType.Moderate, Word = "Cyprus" },
                    new WordDictionary() { Id = id++, WordType = WordType.Moderate, Word = "Delhi" },
                    new WordDictionary() { Id = id++, WordType = WordType.Moderate, Word = "London" },
                    new WordDictionary() { Id = id++, WordType = WordType.Hard, Word = "Armsterdam" },
                    new WordDictionary() { Id = id++, WordType = WordType.Hard, Word = "Australia" },
                    new WordDictionary() { Id = id++, WordType = WordType.Hard, Word = "America" },
                    new WordDictionary() { Id = id++, WordType = WordType.Hard, Word = "Continent" },
                    new WordDictionary() { Id = id++, WordType = WordType.Hard, Word = "Luxemburg" },
                    new WordDictionary() { Id = id++, WordType = WordType.Hard, Word = "Portugal" },
                    new WordDictionary() { Id = id++, WordType = WordType.Hard, Word = "Argentina" },
                    new WordDictionary() { Id = id++, WordType = WordType.Hard, Word = "Switzerland" }
                    );

                context.SaveChanges();
            }

            return options;
        }
        public void Dispose()
        {
            TestComponent = null;
        }

    }
}
