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
        public (decimal subtotal, decimal totalDiscount, decimal totalPay)
            //Calcula el detalle de la venta
            CalculateSaleDetails(IList<Product> products)
        {
            Console.Clear();
            Console.WriteLine("¿Desea ver el detalle de los productos? (Si/No)");
            string response = Console.ReadLine();

            if (response.ToLower() == "si")
            {
                // Mostrar detalle de los productos
                int contador = 1; 
                foreach (var product in products)
                {
                    Console.WriteLine($"Producto{contador}: {product.Name}");
                    Console.WriteLine($"Precio: {product.Price:C}");
                    Console.WriteLine($"Descuento: ({product.Discount:F2}%)");

                    Console.WriteLine("-----------------------------");

                    contador++;
                }
            }
            else
            {
                Console.WriteLine("-----------------------------");
            }

            // Calcular subtotal, descuento total y total de la venta basado en productos seleccionados
            decimal subtotal = CalculateSubtotal(products);
            decimal totalDiscount = CalculateTotalDiscount(products);
            decimal taxes = Constantes.Taxes;
            decimal totalPay = (subtotal - totalDiscount) * taxes;

            // Mostrar importe total, subtotal y descuento
            Console.WriteLine($"Subtotal: {subtotal:C}");
            Console.WriteLine($"Descuento:({totalDiscount:F2}%)");
            Console.WriteLine($"Importe Total: {totalPay:C}");

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
