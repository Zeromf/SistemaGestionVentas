using SistemaGestionVentas.Contexto;
using SistemaGestionVentas.Service;
using SistemaGestionVentasTP1.Model;
using SistemaGestionVentasTP1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Menu
{
    public class MenuRegistrarVenta
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private static IList<Product> productList;
        private readonly IContextDB _contextDB;
        private static Sale sale = new Sale();

        public MenuRegistrarVenta(IContextDB contextDB, IProductService productService, ISaleService saleService) {
            _contextDB = contextDB;
            _productService = productService;
            _saleService = saleService;
        }

        public void RealizarVenta()
        {
            productList = _productService.GetAllProducts();
            List<Product> productosSeleccionados = new List<Product>();

            while (true)
            {
                Console.WriteLine("***********************************************************************************************************************");
                Console.WriteLine("Seleccione el número del producto que desea comprar, o escriba 'fin' para terminar.");
                Console.WriteLine("También puede buscar productos por nombre escribiendo el nombre del producto:");
                Console.WriteLine("Si desea cancelar la selección del último producto, escriba 'cancelar'.");
                Console.WriteLine("***********************************************************************************************************************");
                Console.Write("Opción o nombre del producto: ");

                string input = Console.ReadLine();

                if (input.ToLower() == "fin")
                {
                    break;
                }
                //Cancela el producto
                if (input.ToLower() == "cancelar" && productosSeleccionados.Any())
                {
                    var lastSelectedProduct = productosSeleccionados.Last();
                    productosSeleccionados.Remove(lastSelectedProduct);
                    Console.WriteLine($"Se ha cancelado la selección del producto: {lastSelectedProduct.Name}");
                    continue;
                }
                if (int.TryParse(input, out int selectedIndex) && EsIndiceValido(selectedIndex, productList.Count))
                {
                    var selectedProduct = productList[selectedIndex - 1];
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
