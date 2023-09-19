using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain;

namespace OnlineShop.Persistence
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products")
                .HasData(SeedDataFactory.Products);

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(110)
                .IsRequired();

            builder.Property(x => x.Description)
            .HasMaxLength(500)
            .IsRequired(false);

            //TODO: разобраться как добавить ограничение на неотрицательные значения
            builder.Property(x => x.Cost)
            .IsRequired()
            .HasPrecision(15, 2);

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Products)
                .UsingEntity(j => j
                .ToTable("ProductCategory")
                .HasData(new[]
                {
                   new { ProductsId = 1, CategoriesId = 1 },
                   new { ProductsId = 1, CategoriesId = 2 },
                   new { ProductsId = 2, CategoriesId = 1 },
                   new { ProductsId = 2, CategoriesId = 3 },
                   new { ProductsId = 3, CategoriesId = 1 },
                   new { ProductsId = 3, CategoriesId = 2 },
                   new { ProductsId = 3, CategoriesId = 3 },
                }));
        }
    }
}
