using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentasTP1.Service
{
    public interface ISaleService
    {
        void RegisterSale(IList<Product> ProductL,Sale sale, List<Product> productosSeleccionados);


    }
}
