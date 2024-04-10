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
    public class ProductoConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ProductId);

            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            entityBuilder.Property(x => x.Descripcion).HasMaxLength(200);
            entityBuilder.Property(x => x.Price);
            entityBuilder.Property(x => x.Discount);
            entityBuilder.Property(x => x.ImageUrl).IsRequired();
            entityBuilder.Property(x => x.CategoryId).IsRequired();
            entityBuilder.HasOne(x => x.Category)
                 .WithMany(p => p.Products)
                 .HasForeignKey(x => x.CategoryId);
        }


    }
}
