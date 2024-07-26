using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //var p = new Product() { ProductFeature = new ProductFeature() { } };
            //product feature yi aşağıda geçmeseydik productfeature özelliklerini mutlaka product a ekle demek için böyle bişey yazabilirdin.
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //bütün configuration dosyalarını bulup kullanır.

            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)"); // 18 kesinlik ve 2 ölçek belirleyerek sütun tipini açıkça tanımlar.

            modelBuilder.Entity<ProductFeature>().HasData( // seed data yı ilgili bölümden eklemek istemezsen diye appdbcontext ten ekleme örneği.
                new ProductFeature() { Id = 1, Color = "Kırmızı", Height = 100, Width = 200, ProductId = 1 },
                new ProductFeature() { Id = 2, Color = "Mavi", Height = 300, Width = 500, ProductId = 2 }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
