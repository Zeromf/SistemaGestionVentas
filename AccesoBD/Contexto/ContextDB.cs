using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaGestionVentas.Contexto;
using SistemaGestionVentas.Entity;
using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentas.Contexto
{
    public class ContextDB : DbContext, IContextDB

    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleProduct> SaleProduct { get; set; }

        public ContextDB()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verifica si ya se configuraron las opciones del DbContext
            if (!optionsBuilder.IsConfigured)
            {
                // Configurar las opciones del DbContext utilizando una cadena de conexión
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SistemaVentas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new SaleProductConfig());

            modelBuilder.ApplyConfiguration(new CategoryConfigurationDefault());
            modelBuilder.ApplyConfiguration(new ProductsConfigurationDefault());

        }

        public bool EnsuredCreated()
        {
            return this.Database.EnsureCreated();
        }
    }

}
