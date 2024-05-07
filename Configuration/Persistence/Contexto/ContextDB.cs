using Microsoft.EntityFrameworkCore;
using SistemaGestionVentas.Entity;
using SistemaGestionVentasTP1.Model;

namespace Infraestructura.Persistence.Contexto
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
            //Configuro las relaciones entre las tablas de category, product , saleproduct y sale
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new SaleProductConfig());

            //Cargo 10 categorias y 10 productos por defecto en la base de datos
            modelBuilder.ApplyConfiguration(new CategoryConfigurationDefault());
            modelBuilder.ApplyConfiguration(new ProductsConfigurationDefault());

        }

        //Creo la base de datos si no existe
        public bool EnsuredCreated()
        {
            return Database.EnsureCreated();
        }
    }

}
