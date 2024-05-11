using Application.Interface.IPrinter;
using SistemaGestionVentasTP1.Model;
using System.Reflection.Metadata.Ecma335;


namespace Presentation.Printers
{
    public class SaleConsole : ISaleConsole
    {
        public void SalePrint(Sale sale)
        {
            try
            {
                Console.WriteLine("\n----- Imprimiendo Venta -----\n");
                Console.WriteLine($"Fecha de la venta: {sale.Date}");
                
                Console.WriteLine("Productos:");
                foreach (var saleProduct in sale.SaleProduct)
                {
                    Console.WriteLine($"- {saleProduct.Quantity} unidades de {saleProduct.ProductName.Name} a ${saleProduct.Price} cada una (descuento: {saleProduct.Discount}%)");
                }

                SaleDetail(sale);

                Console.WriteLine("\n----- Fin Impresión -----\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al imprimir la venta: {ex.Message}");
            }
        }

        public void SaleDetail(Sale sale)
        {
            try
            {
                Console.WriteLine("\n= Resumen de la Venta =\n");
                Console.WriteLine($"Subtotal: $ {sale.Subtotal}");
                Console.WriteLine($"Descuento total: $ {sale.TotalDiscount}");
                Console.WriteLine($"Impuestos IVA {(sale.Taxes - 1) * 100}%");
                Console.WriteLine($"Total a pagar: $ {sale.TotalPay}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error al imprimir el detalle de la venta: {ex.Message}");
            }
        }


        public bool ConfirmSaleRegistration()
        {
            bool saleRegistrarion = false;
            Console.Write("\n¿Desea registrar y luego imprimir la venta? (S/N): ");
            string confirmation = Console.ReadLine().ToUpper();

            if (confirmation.Equals("S"))
            {
                saleRegistrarion = true;
                return saleRegistrarion;
            }
            else {
                Console.WriteLine("Venta cancelada.");
                return saleRegistrarion;
            }
        }

        public void SalesConfirm(bool generateSales) {
            if (generateSales) {
                Console.WriteLine("\nVenta registrada e impresa exitosamente.\n");
            }
            else
            {
                Console.WriteLine("Error al registrar o imprimir la venta. Consulte el log de errores para más detalles.");
            }

        }

        public void SaleNotProduct() {
            Console.WriteLine("La venta no contiene ningún producto.");
            Console.WriteLine("\nVolviendo al menú...");
        }
     

    }
}
