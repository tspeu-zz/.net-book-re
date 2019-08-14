using Microsoft.EntityFrameworkCore;
using System;
using webapi_FreeCodeCamp.Domain.Models;

/// <summary>
/// This class must inherit DbContext, a class EF Core uses to map your models to database tables
/// </summary>
/// 
namespace webapi_FreeCodeCamp.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        //Now, we have to create two DbSet properties. 
        //These properties are sets (collections of unique objects) that map models to database tables.

        //se crean las tablas->
        public DbSet<Category> Categorias { get; set; }
        public DbSet<Product> Productos { get; set; }

        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> opciones) : base(opciones) { }

        //
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categorias");
            builder.Entity<Category>().HasKey(p => p.Id);
            //autonumerico el campo iId pk
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            // add foreign Key de productos
            builder.Entity<Category>().HasMany(p => p.Products)
                                      .WithOne(p => p.Category)
                                      .HasForeignKey(p => p.CategoryId);

            //add datos
            builder.Entity<Category>().HasData(
                new Category { Id = 100, Name = "Frutas y Vegetales" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Lácteos" },
                new Category { Id = 102, Name = "Carnes" },
                new Category { Id = 103, Name = "Pescados" },
                new Category { Id = 105, Name = "Cereales" },
                new Category { Id = 106, Name = "Panadería" },
                new Category { Id = 107, Name = "Postres" },
                new Category { Id = 108, Name = "Bebidas" }
                );

            builder.Entity<Product>().ToTable("Productos");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.CantidadPorPaquete).IsRequired();
            builder.Entity<Product>().Property(p => p.CantidadPorPaquete).IsRequired();

        }
    }
}
