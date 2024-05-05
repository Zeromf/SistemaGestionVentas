using SistemaGestionVentasTP1.Model;
using System.Collections.Generic;

namespace SistemaGestionVentas.Service
{
    public interface ISaleCalculatorService
    {
        (decimal subtotal, decimal totalDiscount, decimal totalPay) CalculateSaleDetails(IList<Product> products);

    }
}
