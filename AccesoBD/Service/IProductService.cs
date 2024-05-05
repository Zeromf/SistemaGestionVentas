using SistemaGestionVentasTP1.Model;
using System.Collections.Generic;

namespace SistemaGestionVentasTP1.Service
{
    public interface IProductService
    {
        void AddProduct(Product Product);
        List<Product> GetAllProducts();

    }
}
