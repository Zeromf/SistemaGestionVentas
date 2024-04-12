using SistemaGestionVentas.Const;
using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentas.Service
{

    public class SaleCalculatorService : ISaleCalculatorService
    {
        public (decimal subtotal, decimal totalDiscount, decimal totalPay) CalculateSaleDetails(IList<Product> products)
        {

            // Calcular subtotal, descuento total y total de la venta basado en productos seleccionados
            decimal subtotal = CalculateSubtotal(products);
            decimal totalDiscount = CalculateTotalDiscount(products);
            decimal taxes = Constantes.Taxes;
            decimal totalPay = (subtotal - totalDiscount) * taxes;

            return (subtotal, totalDiscount, totalPay);
        }

        private decimal CalculateSubtotal(IList<Product> products)
        {
            return products.Sum(p => p.Price);
        }

        private decimal CalculateTotalDiscount(IList<Product> products)
        {
            return products.Sum(p => p.Discount);
        }
    }
}
