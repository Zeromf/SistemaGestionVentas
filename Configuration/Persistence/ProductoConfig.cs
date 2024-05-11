using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionVentasTP1.Model;

namespace SistemaGestionVentas.Entity
{
    public class ProductoConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ProductId);

            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).HasMaxLength(int.MaxValue);
            entityBuilder.Property(x => x.Price);
            entityBuilder.Property(x => x.Discount);
            entityBuilder.Property(x => x.ImageUrl).HasMaxLength(int.MaxValue);
            entityBuilder.Property(x => x.Category).IsRequired();
            entityBuilder.HasOne(x => x.category)
                 .WithMany(p => p.Product)
                 .HasForeignKey(x => x.Category);
        }


    }
}
