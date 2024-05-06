using SistemaGestionVentas.Contexto;
using SistemaGestionVentas.Service;
using SistemaGestionVentasTP1.Model;
using SistemaGestionVentasTP1.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace View.Menu
{
    public class MenuRegistrarVenta
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private static IList<Product> productList;
        private static IList<Category> categorieList;
        private readonly IContextDB _contextDB;
        private static Sale sale = new Sale();
        private readonly ICategoryService _categoryService;

        public MenuRegistrarVenta(IContextDB contextDB, IProductService productService, ISaleService saleService, ICategoryService categoryService)
        {
            _contextDB = contextDB;
            _productService = productService;
            _saleService = saleService;
            _categoryService = categoryService;
        }

        //Calcula la venta
        public void CalcularVenta()
        {
            productList = _productService.GetAllProducts();
            if (!productList.Any())
            {
                Console.WriteLine("No hay productos disponibles.");
                return;
            }

            categorieList = _categoryService.GetAllCategories();
            if (!categorieList.Any())
            {
                Console.WriteLine("No hay categorías disponibles.");
                return;
            }

            Console.WriteLine("Categorías disponibles:");
            for (int i = 0; i < categorieList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categorieList[i].Name}");
            }

            Console.WriteLine("Seleccione el número de la categoría para ver los productos, o escriba 'fin' para volver al menú principal.");
            Console.Write("Opción: ");

            string inputCategory = Console.ReadLine();

            if (inputCategory.ToLower() == "fin")
            {
                return;
            }

            if (int.TryParse(inputCategory, out int selectedCategoryIndex) && EsIndiceValido(selectedCategoryIndex, categorieList.Count))
            {
                Console.Clear();
                var selectedCategory = categorieList[selectedCategoryIndex - 1];
                var productsInCategory = productList.Where(p => p.Category == selectedCategory.CategoryId).ToList();

                Console.WriteLine($"Productos en la categoría '{selectedCategory.Name}':");
                MostrarProductosFiltrados(productsInCategory);

                SeleccionProductos(productsInCategory);
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, seleccione un número válido.");
            }
        }

        private void SeleccionProductos(List<Product> productsInCategory)
        {
            List<(Product product, int quantity)> productosSeleccionados = new List<(Product product, int quantity)>();

            while (true)
            {
                Console.WriteLine("Seleccione el número del producto o 'fin' para comprar. '0' para volver, 'cancel' para eliminar último producto.");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número de producto o nombre válido.");
                    continue;
                }

                if (input.ToLower() == "fin")
                {
                    Console.Clear();
                    break;
                }

                if (input == "0")
                {
                    Console.Clear();
                    CalcularVenta();
                    return;
                }

                if (input.ToLower() == "cancel" && productosSeleccionados.Any())
                {
                    productosSeleccionados.RemoveAt(productosSeleccionados.Count - 1);
                    Console.WriteLine($"Se ha cancelado la selección del último producto.");
                    continue;
                }

                if (int.TryParse(input, out int selectedIndex) && EsIndiceValido(selectedIndex, productsInCategory.Count))
                {
                    var selectedProduct = productsInCategory[selectedIndex - 1];
                    int quantity = PedirCantidad(selectedProduct);
                    if (quantity > 0)
                    {
                        productosSeleccionados.Add((selectedProduct, quantity));
                        Console.WriteLine($"Ha seleccionado {quantity} unidad(es) del producto: {selectedProduct.Name}");
                    }
                }
                else
                {
                    SeleccionarProductoPorNombre(input, productsInCategory, productosSeleccionados);
                }
            }

            Console.WriteLine($"Ha seleccionado {productosSeleccionados.Count} producto(s) para la venta.");
            RegistrarVenta(productosSeleccionados);
        }
        private static int PedirCantidad(Product product)
        {
            int quantity = 0;
            while (true)
            {
                Console.Write($"Ingrese la cantidad de {product.Name} que desea agregar a la venta: ");
                if (int.TryParse(Console.ReadLine(), out quantity))
                {
                    if (quantity <= 0)
                    {
                        Console.WriteLine("La cantidad debe ser un número entero positivo.");
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero positivo.");
                }
            }
            return quantity;
        }
        private static bool EsIndiceValido(int selectedIndex, int maxIndex)
        {
            return selectedIndex >= 1 && selectedIndex <= maxIndex;
        }

        private static void SeleccionarProductoPorNombre(string input, List<Product> productList, List<(Product product, int quantity)> productosSeleccionados)
        {
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

        private static void SeleccionarProductoFiltrado(List<Product> filteredProducts, List<(Product product, int quantity)> productosSeleccionados)
        {
            Console.Write("Seleccione el número del producto que desea comprar: ");
            if (int.TryParse(Console.ReadLine(), out int selectedByNameIndex) && EsIndiceValido(selectedByNameIndex, filteredProducts.Count))
            {
                var selectedProduct = filteredProducts[selectedByNameIndex - 1];
                int quantity = PedirCantidad(selectedProduct);
                if (quantity > 0)
                {
                    productosSeleccionados.Add((selectedProduct, quantity));
                    Console.WriteLine($"Ha seleccionado {quantity} unidad(es) del producto: {selectedProduct.Name}");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, seleccione un número válido.");
            }
        }

        private void RegistrarVenta(List<(Product product, int quantity)> productosSeleccionados)
        {
            try
            {
                _saleService.RegisterSale(productList, sale, productosSeleccionados);
                Console.WriteLine("La venta ha sido registrada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al intentar registrar la venta: " + ex.Message);
            }
        }
    }
}