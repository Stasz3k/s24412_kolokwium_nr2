using Microsoft.EntityFrameworkCore;
using s24412_kolokwium_nr2.Models;
using System;

namespace s24412_kolokwium_nr2.Data
{
    public class s24412DbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<CharacterTitle> CharacterTitles { get; set; }

        public s24412DbContext(DbContextOptions<s24412DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backpack>()
                .HasKey(b => new { b.CharacterId, b.ItemId });

            modelBuilder.Entity<CharacterTitle>()
                .HasKey(ct => new { ct.CharacterId, ct.TitleId });
            
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Item1", Weight = 10 }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, FirstName = "John", LastName = "Dzban", CurrentWeight = 43, MaxWeight = 200 }
            );

            modelBuilder.Entity<Title>().HasData(
                new Title { Id = 1, Name = "Title1" }
            );

            modelBuilder.Entity<CharacterTitle>().HasData(
                new CharacterTitle { CharacterId = 1, TitleId = 1, AcquiredAt = DateTime.Now }
            );

            modelBuilder.Entity<Backpack>().HasData(
                new Backpack { CharacterId = 1, ItemId = 1, Amount = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}