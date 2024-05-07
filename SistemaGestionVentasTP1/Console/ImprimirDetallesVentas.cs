using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu_Opcion
{
    public class ImprimirDetallesVentas
    {

        public static void ImprimirDetalles(List<(Product product, int quantity)> products)
        {
            Console.WriteLine("¿Desea ver el detalle de los productos? (Si/No)");
            string response = Console.ReadLine();

            if (response.ToLower() == "si")
            {
                // Mostrar detalle de los productos
                int contador = 1;
                foreach (var (product, quantity) in products)
                {
                    Console.WriteLine($"Producto{contador}: {product.Name}");
                    Console.WriteLine($"Precio: {product.Price:C}");
                    Console.WriteLine($"Cantidad: {quantity}");
                    Console.WriteLine($"Descuento: ({product.Discount:F2}%)");

                    Console.WriteLine("-----------------------------");

                    contador++;
                }
            }
            else
            {
                Console.WriteLine("-----------------------------");
            }
        }  
        
        public static void ImprimirTotalPay(decimal subtotal, decimal totalDiscount, decimal totalPay)
        {
            Console.WriteLine($"Subtotal: {subtotal:C}");
            Console.WriteLine($"Descuento: {totalDiscount}");
            Console.WriteLine($"Importe Total: {totalPay:C}");
        }




    }
}
