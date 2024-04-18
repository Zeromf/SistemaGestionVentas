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
    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(c => c.CategoryId);

            entityBuilder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            entityBuilder.HasMany(c => c.Product).WithOne(p=>p.Category);

        }
    }    }
