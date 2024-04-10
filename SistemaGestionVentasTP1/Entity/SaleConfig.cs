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
    class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> entityBuilder)
        {
            entityBuilder.HasKey(v => v.SaleId);
            entityBuilder.Property(v => v.Taxes).IsRequired();
            entityBuilder.Property(v => v.Date).IsRequired();
            entityBuilder.Property(v => v.Subtotal).IsRequired();
            entityBuilder.Property(v => v.TotalDiscount).IsRequired();
            entityBuilder.Property(v => v.TotalPay).IsRequired();
            entityBuilder.HasMany(v => v.SaleProducts).WithOne(vp => vp.Sale);

        }
    }
}
