using SistemaGestionVentas.Const;
using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using View.Menu_Opcion;

namespace SistemaGestionVentas.Service
{

    public class SaleCalculatorService : ISaleCalculatorService
    {
        public (decimal subtotal, decimal totalDiscount, decimal totalPay)
            //Calcula el detalle de la venta
            CalculateSaleDetails(List<(Product product, int quantity)> products)
        {
            Console.Clear();

            ImprimirDetallesVentas.ImprimirDetalles(products);
          
            
            decimal subtotal = 0;
            decimal totalDiscount = 0;
            decimal totalPay = 0;

            foreach (var (product, quantity) in products)
            {
                if (product != null)
                {
                    decimal discountedPrice = product.Price - (product.Price * (product.Discount / 100.0m));
                    subtotal += product.Price * quantity;
                    totalDiscount += Math.Round((product.Price * quantity) - (discountedPrice * quantity), 2);
                }
                totalPay = Math.Round(((subtotal - totalDiscount) * Constantes.Taxes), 2);

            }
                // Mostrar importe total, subtotal y descuento
                ImprimirDetallesVentas.ImprimirTotalPay(subtotal, totalDiscount,totalPay);

            return (subtotal, totalDiscount, totalPay);
        }

    }
}