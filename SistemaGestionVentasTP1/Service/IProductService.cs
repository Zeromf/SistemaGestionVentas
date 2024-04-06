using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentasTP1.Service
{
    interface IProductService
    {
        void AddProduct(Product Product);
        List<Product> GetAllProducts();

    }
}
