using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestionVentasTP1.Model;

namespace SistemaGestionVentas.Entity
{
    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(c => c.CategoryId);

            entityBuilder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            entityBuilder.HasMany(c => c.Product).WithOne(p => p.Category);

        }
    }
}
