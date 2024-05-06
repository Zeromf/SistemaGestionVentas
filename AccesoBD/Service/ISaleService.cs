using SistemaGestionVentasTP1.Model;
using System.Collections.Generic;

namespace SistemaGestionVentasTP1.Service
{
    public interface ISaleService
    {
        void RegisterSale(IList<Product> ProductL, Sale sale, List<(Product product, int quantity)> productosSeleccionados);


    }
}
