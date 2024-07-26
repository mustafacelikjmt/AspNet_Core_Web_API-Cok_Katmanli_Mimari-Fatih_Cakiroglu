using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category> //burası örnek bi configuration dosyası. yapmak istersen bakıp öğren diye.
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories");
            builder.HasMany(x => x.Products).WithOne(x => x.Category);
        }
    }
}
