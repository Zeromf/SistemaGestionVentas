using SistemaGestionVentas.Const;
using SistemaGestionVentas.Contexto;
using SistemaGestionVentas.Service;
using SistemaGestionVentasTP1.Model;
using SistemaGestionVentasTP1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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

        public void CalcularVenta()
        {
            productList = _productService.GetAllProducts();
            if (!productList.Any())
            {
                Console.WriteLine("No hay productos disponibles para la venta.");
                return;
            }

            categorieList = _categoryService.GetAllCategories();
            if (!categorieList.Any())
            {
                Console.WriteLine("No hay categorias disponibles para la venta.");
                return;
            }

            Console.WriteLine("Categorías disponibles:");
            for (int i = 0; i < categorieList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categorieList[i].Name}");
            }

            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine("Seleccione el número de la categoría para ver los productos, o escriba 'fin' para volver al menu principal.");
            Console.WriteLine("***********************************************************************************************************************");
            Console.Write("Opción: ");

            string inputCategory = Console.ReadLine();

            if (inputCategory.ToLower() == "fin")
            {
                return;
            }

            if (int.TryParse(inputCategory, out int selectedCategoryIndex) && EsIndiceValido(selectedCategoryIndex, categorieList.Count))
            {
                var selectedCategory = categorieList[selectedCategoryIndex - 1];
                var productsInCategory = productList.Where(p => p.CategoryId == selectedCategory.CategoryId).ToList();

                Console.WriteLine($"Productos en la categoría '{selectedCategory.Name}':");
                MostrarProductosFiltrados(productsInCategory);

                RealizarVenta(productsInCategory);
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, seleccione un número válido.");
            }
        }

        private void RealizarVenta(List<Product> productsInCategory)
        {
            List<Product> productosSeleccionados = new List<Product>();

            while (true)
            {
                Console.WriteLine("***********************************************************************************************************************");
                Console.WriteLine("Seleccione el número del producto o 'fin' para comprar. " +
                    "Busque por nombre o '0' para volver, 'cancel' para eliminar último producto.");
                Console.WriteLine("***********************************************************************************************************************");
                Console.Write("Opción o nombre del producto: ");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número de producto o nombre válido.");
                    continue;
                }

                if (input.ToLower() == "fin")
                {
                    break;
                }

                if (input == "0")
                {
                    Console.Clear();
                    CalcularVenta();
                    return;
                }

                //Cancela el producto
                if (input.ToLower() == "cancel" && productosSeleccionados.Any())
                {
                    var lastSelectedProduct = productosSeleccionados.Last();
                    productosSeleccionados.Remove(lastSelectedProduct);
                    Console.WriteLine($"Se ha cancelado la selección del producto: {lastSelectedProduct.Name}");
                    continue;
                }

                if (int.TryParse(input, out int selectedIndex) && EsIndiceValido(selectedIndex, productsInCategory.Count))
                {
                    var selectedProduct = productsInCategory[selectedIndex - 1];
                    productosSeleccionados.Add(selectedProduct);
                    Console.WriteLine($"Ha seleccionado el producto: {selectedProduct.Name}");
                }
                else
                {
                    SeleccionarProductoPorNombre(input, productosSeleccionados);
                }
            }

            Console.WriteLine("***********************************************************************************************************************");
            Console.WriteLine($"Ha seleccionado {productosSeleccionados.Count} producto(s) para la venta.");
            Console.WriteLine("***********************************************************************************************************************");
            RegistrarVenta(productosSeleccionados);
        }

        private static bool EsIndiceValido(int selectedIndex, int maxIndex)
        {
            return selectedIndex >= 1 && selectedIndex <= maxIndex;
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

        private void RegistrarVenta(List<Product> productosSeleccionados)
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
