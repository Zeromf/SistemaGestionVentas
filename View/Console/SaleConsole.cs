﻿using Application.Interface.IPrinter;
using SistemaGestionVentasTP1.Model;


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
                    Console.WriteLine($"- {saleProduct.Quantity} unidades de {saleProduct.Product.Name} a ${saleProduct.Price} cada una (descuento: {saleProduct.Discount}%)");
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
    }
}
