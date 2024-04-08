using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            entityBuilder.HasOne(vp => vp.Sale).WithMany(v => v.SaleProducts);
        }
    }
}
