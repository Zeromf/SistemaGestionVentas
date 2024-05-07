using SistemaGestionVentas.Contexto;
using SistemaGestionVentasTP1.Model;
using SistemaGestionVentasTP1.Service;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestionVentas.Service
{
    public class ProductService : IProductService
    {
        private readonly IContextDB _contextoDB;

        public ProductService()
        {
        }
        public ProductService(IContextDB contextoDB)
        {
            _contextoDB = contextoDB;
        }


        public void AddProduct(Product Product)
        {
            _contextoDB.Product.Add(Product);

            _contextoDB.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _contextoDB.Product.Select(x => x).ToList();

        }

    }
}
