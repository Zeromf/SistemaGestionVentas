using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;

namespace Application.Interface.IService
{
    public interface IProductService
    {
        public List<Product> ListProducts();
        public Product GetProductById(Guid id);
    }
}
