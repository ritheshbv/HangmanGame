﻿using Microsoft.EntityFrameworkCore;
using Sbs.Api.Data.Entities;

namespace Sbs.Api.Contexts
{
    public class SbsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WordDictionary> Dictionary { get; set; }

        public SbsDbContext(DbContextOptions<SbsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        #region Private Methods
        private void SeedData(ModelBuilder modelBuilder)
        {
            var id = 1;
            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id = id,
                    Name = "Rit",
                    Address = "3",
                    LoginName = "r",
                    Password = "pass",
                });

            modelBuilder.Entity<WordDictionary>()
                .HasData(
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
                new WordDictionary() { Id = id++, WordType = WordType.Hard, Word = "Switzerland" });
        }
        #endregion
    }
}
