using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentas.Service
{
    interface ISaleCalculatorService
    {
        (decimal subtotal, decimal totalDiscount, decimal totalPay) CalculateSaleDetails(IList<Product> products);

    }
}
