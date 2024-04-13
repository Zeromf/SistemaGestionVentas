using SistemaGestionVentas.Contexto;
using SistemaGestionVentasTP1.Model;
using SistemaGestionVentasTP1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _contextoDB.Products.Add(Product);

            _contextoDB.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _contextoDB.Products.Select(x => x).ToList();

        }

    }
}
