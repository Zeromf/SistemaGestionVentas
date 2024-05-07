using Microsoft.EntityFrameworkCore;
using SistemaGestionVentasTP1.Model;

namespace SistemaGestionVentas.Contexto
{
    public interface IContextDB
    {
        DbSet<Category> Category { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Sale> Sale { get; set; }
        DbSet<SaleProduct> SaleProduct { get; set; }
        int SaveChanges();

        bool EnsuredCreated();
    }
}