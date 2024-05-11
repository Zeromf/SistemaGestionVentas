﻿using Application.Interface.IPrinter;
using SistemaGestionVentasTP1.Model;


namespace Presentation.Printers
{
    public class ProductConsole : IProductPrinter
    {
        public void ListProductDetail(List<Product> products)
        {
            Console.WriteLine("\n=====================================");
            Console.WriteLine("          Lista de Productos         ");
            Console.WriteLine("=====================================\n");
            try
            {
                if (products.Count > 0)
                {
                    foreach (var product in products)
                    {
                        PrintProduct(product);
                    }
                }
                else
                {
                    Console.WriteLine("\nActualmente no hay productos en lista.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar los productos: {ex.Message}");
            }

        }
        public void PrintProduct(Product product)
        {
            try
            {
                Console.WriteLine($"ID: {product.ProductId}");
                Console.WriteLine($"Nombre: {product.Name}");
                Console.WriteLine($"Descripción: {product.Description}");
                Console.WriteLine($"Precio: {product.Price}");
                Console.WriteLine($"Categoría: {product.category.Name}");
                Console.WriteLine($"Descuento: {product.Discount} %");
                Console.WriteLine("\n--------------------------------------------------------------\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al imprimir el producto: {ex.Message}");
            }
        }
    }
}
