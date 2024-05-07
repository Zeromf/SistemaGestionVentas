using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;

namespace Application.Interface.IQuery
{
    public interface IProductQuery
    {
        public List<Product> GetListProducts();
        public Product GetProductById(Guid id);
    }
}
