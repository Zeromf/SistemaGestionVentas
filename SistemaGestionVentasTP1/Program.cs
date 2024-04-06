using SistemaGestionVentas.Contexto;
using SistemaGestionVentas.Service;
using SistemaGestionVentasTP1.Model;
using SistemaGestionVentasTP1.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestionVentasTP1
{
    class Program
    {
        private static IProductService _productService = new ProductService();
        private static ISaleService _saleService = new SaleService();
        private static ICategoryService _categoriaService = new CategoryService();
        private static Sale sale = new Sale();
        //Traigo la lista de productos
        private static IList<Product> productList = _productService.GetAllProducts();
        //Traigo la lista de Categorias
        private static IList<Category> categoryList = _categoriaService.GetAllCategories();

        static void Main(string[] args)
        {
            ContextDB context = new ContextDB();

            //creates db if not exists 
            context.Database.EnsureCreated();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Listar productos");
                Console.WriteLine("2. Realizar una venta");
                Console.WriteLine("3. Salir");

                Console.Write("Opción: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListarProductos();
                        break;
                    case "2":
                        RealizarVenta();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }


        }

        public static void ListarProductos()
        {
            Console.WriteLine("Productos disponibles:");
            for (int i = 0; i < productList.Count; i++)
            {
                Product product = productList[i];
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
                    Console.WriteLine($"Descuento: {product.Discount}");
                    Console.WriteLine($"Categoría: {category?.Name}");
                    Console.WriteLine("***********************************************************************************************************************");
                }
                else
                {
                    Console.WriteLine("Product has no category assigned.");
                }
            }
        }

        public static void RealizarVenta()
        {
            List<Product> productosSeleccionados = new List<Product>();

            while (true)
            {
                MostrarMenuProductos();

                string input = Console.ReadLine();

                if (EsSalir(input))
                {
                    break;
                }

                if (EsCancelar(input, productosSeleccionados))
                {
                    CancelarUltimaSeleccion(productosSeleccionados);
                    continue;
                }

                if (int.TryParse(input, out int selectedIndex) && EsIndiceValido(selectedIndex, productList.Count))
                {
                    SeleccionarProductoPorIndice(selectedIndex, productosSeleccionados);
                }
                else
                {
                    SeleccionarProductoPorNombre(input, productosSeleccionados);
                }
            }

            MostrarResumenVenta(productosSeleccionados);

            RegistrarVenta(productosSeleccionados);
        }

        private static void MostrarMenuProductos()
        {
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Seleccione el número del producto que desea comprar, o escriba 'fin' para terminar.");
            Console.WriteLine("También puede buscar productos por nombre escribiendo el nombre del producto:");
            Console.WriteLine("Si desea cancelar la selección del último producto, escriba 'cancelar'.");
            Console.WriteLine("***********************************************************************************************************************");
            Console.Write("Opción o nombre del producto: ");
        }

        private static bool EsSalir(string input)
        {
            return input.ToLower() == "fin";
        }

        private static bool EsCancelar(string input, List<Product> productosSeleccionados)
        {
            return input.ToLower() == "cancelar" && productosSeleccionados.Any();
        }

        private static void CancelarUltimaSeleccion(List<Product> productosSeleccionados)
        {
            var lastSelectedProduct = productosSeleccionados.Last();
            productosSeleccionados.Remove(lastSelectedProduct);
            Console.WriteLine($"Se ha cancelado la selección del producto: {lastSelectedProduct.Name}");
        }

        private static bool EsIndiceValido(int selectedIndex, int maxIndex)
        {
            return selectedIndex >= 1 && selectedIndex <= maxIndex;
        }

        private static void SeleccionarProductoPorIndice(int selectedIndex, List<Product> productosSeleccionados)
        {
            var selectedProduct = productList[selectedIndex - 1];
            productosSeleccionados.Add(selectedProduct);
            Console.WriteLine($"Ha seleccionado el producto: {selectedProduct.Name}");
        }

        private static void SeleccionarProductoPorNombre(string input, List<Product> productosSeleccionados)
        {
            // Filtrar productos por nombre
            var filteredProducts = productList.Where(p => p.Name.ToLower().Contains(input.ToLower())).ToList();

            if (filteredProducts.Any())
            {
                MostrarProductosFiltrados(filteredProducts);

                SeleccionarProductoFiltrado(filteredProducts, productosSeleccionados);
            }
            else
            {
                Console.WriteLine("No se encontraron productos con ese nombre.");
            }
        }

        private static void MostrarProductosFiltrados(List<Product> filteredProducts)
        {
            Console.WriteLine("Productos encontrados:");
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {filteredProducts[i].Name} - {filteredProducts[i].Price:C} - Descuento: {filteredProducts[i].Discount}%");
            }
        }

        private static void SeleccionarProductoFiltrado(List<Product> filteredProducts, List<Product> productosSeleccionados)
        {
            Console.Write("Seleccione el número del producto que desea comprar: ");
            if (int.TryParse(Console.ReadLine(), out int selectedByNameIndex) && EsIndiceValido(selectedByNameIndex, filteredProducts.Count))
            {
                var selectedProduct = filteredProducts[selectedByNameIndex - 1];
                productosSeleccionados.Add(selectedProduct);
                Console.WriteLine($"Ha seleccionado el producto: {selectedProduct.Name}");
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, seleccione un número válido.");
            }
        }

        private static void MostrarResumenVenta(List<Product> productosSeleccionados)
        {
            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine($"Ha seleccionado {productosSeleccionados.Count} producto(s) para la venta.");
            Console.WriteLine("***********************************************************************************************************************");
        }

        private static void RegistrarVenta(List<Product> productosSeleccionados)
        {
            _saleService.RegisterSale(productList, sale, productosSeleccionados);
            Console.WriteLine("La venta ha sido registrada correctamente.");

        }

    }
}