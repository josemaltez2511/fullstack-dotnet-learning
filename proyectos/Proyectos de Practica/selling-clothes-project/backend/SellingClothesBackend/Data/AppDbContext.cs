using System;
using Microsoft.EntityFrameworkCore;
using SellingClothesBackend.Models.Products.Product; // Assuming Product is the base class for all products 
using SellingClothesBackend.Models.Products.Bags;
using SellingClothesBackend.Models.Products.Clothing;   
using SellingClothesBackend.Models.Products.Jewelry;
using SellingClothesBackend.Models.Products.Shoes;
using SellingClothesBackend.Models.Products.Watch;

namespace SellingClothesBackend.Data
{
    public class AppDbContext : DbContext //using DbContext to interact with the database, AppDbContext is the main class for database operations
    {
        // Constructor to initialize the DbContext with options
        // This allows for dependency injection and configuration of the database connection
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        // DbSet<Product> is the only one required based on DRY (Don´t Repeat Yourself) principle
        // use just DbSet<Product> to represent all products
        // This allows for querying and saving instances of Product and its derived classes
        public DbSet<Product> Products { get; set; } // DbSet for the base Product class

        // DbSets for derived product classes 
        // These allow for querying and saving instances of specific product types
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the model for each derived product class
            // This ensures that EF Core knows how to handle the inheritance structure
            modelBuilder.Entity<ClothingProduct>();
            modelBuilder.Entity<BagProduct>();
            modelBuilder.Entity<ShoesProduct>();
            modelBuilder.Entity<JewelryProduct>();
            modelBuilder.Entity<WatchProduct>();

            // There was a warn in the console about the decimals so
            // this tells the database that ProductPrice column can store 18 digits, two of them after the decimal point 
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductPrice)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder); // Call the base method to ensure any additional configurations are applied
        }
    }
}