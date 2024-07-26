﻿using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.SeedData
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Kalem 1", Price = 100, Stock = 20, CreatedDate = DateTime.Now },
                new Product { Id = 2, CategoryId = 1, Name = "Kalem 2", Price = 200, Stock = 30, CreatedDate = DateTime.Now },
                new Product { Id = 3, CategoryId = 2, Name = "Kitap 1", Price = 500, Stock = 40, CreatedDate = DateTime.Now }
                );
        }
    }
}
