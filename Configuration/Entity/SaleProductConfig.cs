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
            entityBuilder.HasOne(vp => vp.sale).WithMany(v => v.SaleProduct);
        }
    }
}
