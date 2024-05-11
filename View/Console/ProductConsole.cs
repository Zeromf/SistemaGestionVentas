using Application.Interface.IPrinter;
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

        public void ProductSelectionConfirmation(Product product, Guid productId, List<(Guid productId, int quantity)> productIdQuantities)
        {
            Console.Write($"\nProducto seleccionado: {product.Name}, Precio: {product.Price} Descuento: {product.Discount}% \nIngrese la cantidad: ");

            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
            {
                Console.WriteLine($"\nProducto agregado: {product.Name} ({quantity} unidades)\n");
                productIdQuantities.Add((productId, quantity));
            }
            else
            {
                Console.WriteLine("La cantidad debe ser un número entero positivo.");
            }
        }

        public void ProductInvalid()
        {
            Console.WriteLine("El producto seleccionado no es válido.");
        }

        public string EnterProductId()
        {
            Console.WriteLine("\nIngrese el ID del producto (N para terminar): ");
            return Console.ReadLine();

        }

        public void ConsoleClear()
        {
            Console.Clear();
        }

        public bool ShouldExit(string input)
        {
            return input.ToUpper() == "N";
        }

    }
}
