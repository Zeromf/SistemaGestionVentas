using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionVentasTP1.Model;

namespace SistemaGestionVentas.Entity
{
    class SaleProductConfig : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> entityBuilder)
        {
            entityBuilder.HasKey(vp => vp.ShoppingCardId);
            entityBuilder.Property(vp => vp.Quantity).IsRequired();
            entityBuilder.Property(vp => vp.Price).IsRequired();
            entityBuilder.Property(vp => vp.Discount).IsRequired();
            entityBuilder.HasOne(vp => vp.SaleName).WithMany(v => v.SaleProduct);

            entityBuilder.HasOne<Sale>(sp => sp.SaleName)
            .WithMany(s => s.SaleProduct)
            .HasForeignKey(sp => sp.Sale);

            entityBuilder.HasOne<Product>(sp => sp.ProductName)
                .WithMany(p => p.product)
                .HasForeignKey(sp => sp.Product);
        }
    }
}
