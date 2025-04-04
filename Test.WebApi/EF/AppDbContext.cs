using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Test.ApiShared.Models;

namespace Test.WebApi.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Brand = "TechCo", Description = "High performance laptop", Price = 1200 },
                new Product { Id = 2, Name = "Smartphone", Brand = "MobileX", Description = "5G-enabled smartphone", Price = 800 },
                new Product { Id = 3, Name = "Headphones", Brand = "SoundPro", Description = "Noise-cancelling headphones", Price = 300 },
                new Product { Id = 4, Name = "Monitor", Brand = "DisplayMax", Description = "27-inch 4K monitor", Price = 400 },
                new Product { Id = 5, Name = "Keyboard", Brand = "KeyFlow", Description = "Mechanical keyboard", Price = 150 },
                new Product { Id = 6, Name = "Mouse", Brand = "ClickerPro", Description = "Wireless ergonomic mouse", Price = 75 },
                new Product { Id = 7, Name = "Smartwatch", Brand = "TimeTech", Description = "Fitness and health smartwatch", Price = 250 },
                new Product { Id = 8, Name = "Speaker", Brand = "AudioBoom", Description = "Portable Bluetooth speaker", Price = 100 },
                new Product { Id = 9, Name = "Tablet", Brand = "PadX", Description = "Lightweight tablet for work", Price = 600 },
                new Product { Id = 10, Name = "Printer", Brand = "PrintEasy", Description = "Fast and efficient printer", Price = 200 }
            );
        }
    }
}
