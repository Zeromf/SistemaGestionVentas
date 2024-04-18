using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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