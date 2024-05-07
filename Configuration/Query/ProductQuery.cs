using Application.Interface.IQuery;
using Infraestructura.Persistence.Contexto;
using Microsoft.EntityFrameworkCore;
using SistemaGestionVentasTP1.Model;

namespace Infraestructura.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ContextDB _context;

        public ProductQuery(ContextDB Context)
        {
            _context = Context;
        }

        public List<Product> GetListProducts()
        {
            return _context.Product.Include(x => x.category).ToList();
        }

        public Product GetProductById(Guid id)
        {
            return _context.Product.FirstOrDefault(product => product.ProductId == id);
        }
    }
}