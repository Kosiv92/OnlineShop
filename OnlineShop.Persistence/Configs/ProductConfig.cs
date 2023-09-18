using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain;

namespace OnlineShop.Persistence
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

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
                .UsingEntity("ProductCategory");
        }
    }
}
