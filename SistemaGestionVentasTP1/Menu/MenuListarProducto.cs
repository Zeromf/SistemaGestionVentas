﻿using SistemaGestionVentas.Service;
using SistemaGestionVentasTP1.Model;
using SistemaGestionVentasTP1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentas.Menu
{
    public class MenuListarProducto
    {
        private static IProductService _productService = new ProductService();
        private static ICategoryService _categoriaService = new CategoryService();

        //Traigo la lista de productos
        private static IList<Product> productList = _productService.GetAllProducts();
        //Traigo la lista de Categorias
        private static IList<Category> categoryList = _categoriaService.GetAllCategories();
       
        public static void ListarProductos()
        {
            
             Console.WriteLine("Productos disponibles:");
            for (int i = 0; i < productList.Count; i++)
            {
                //Lista de todos los productos
                Product product = productList[i];
                //Compara la categoria id con la del producto ,si coincido lo trae
                Category category = categoryList.FirstOrDefault(c => c.CategoryId == product.CategoryId);
                // Verificar si se encontró la categoría
                if (category != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("***********************************************************************************************************************");
                    Console.WriteLine($"Producto {i + 1}:");
                    Console.WriteLine($"ProductID: {product.ProductId}");
                    Console.WriteLine($"Nombre: {product.Name}");
                    Console.WriteLine($"Descripción: {product.Descripcion}");
                    Console.WriteLine($"Precio: {product.Price:C}");
                    Console.WriteLine($"Descuento: {product.Discount} %");
                    Console.WriteLine($"Categoría: {category?.Name}");
                    Console.WriteLine("***********************************************************************************************************************");
                }
                else
                {
                    Console.WriteLine("Product has no category assigned.");
                }
            }
        }
    }
}
