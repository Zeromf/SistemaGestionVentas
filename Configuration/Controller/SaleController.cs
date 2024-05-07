using Application.Interface.IPrinter;
using Application.Interface.IService;


namespace Infraestructure.Controller
{
    public class SaleController
    {
        private readonly ISaleService _saleService;
        private readonly ISaleConsole _saleConsole;
        private readonly IProductService _productService;

        public SaleController(ISaleService saleService, ISaleConsole saleConsole, IProductService productService)
        {
            _saleService = saleService;
            _saleConsole = saleConsole;
            _productService = productService;
        }

        public void CrearVenta()
        {
            var productIdsAndQuantities = GetProductSelection();

            if (productIdsAndQuantities.Count == 0)
            {
                Console.WriteLine("La venta no contiene ningún producto.");
                Console.WriteLine("\nVolviendo al menú...");
                return;
            }

            var sale = _saleService.CalculateSale(productIdsAndQuantities);
            _saleConsole.SaleDetail(sale);

            if (ConfirmSaleRegistration())
            {
                if (_saleService.GenerateSale(productIdsAndQuantities))
                {
                    Console.WriteLine("\nVenta registrada e impresa exitosamente.\n");
                }
                else
                {
                    Console.WriteLine("Error al registrar o imprimir la venta. Consulte el log de errores para más detalles.");
                }
            }
            else
            {
                Console.WriteLine("Venta cancelada.");
            }
        }

        private bool ConfirmSaleRegistration()
        {
            Console.Write("\n¿Desea registrar y luego imprimir la venta? (S/N): ");
            string confirmation = Console.ReadLine().ToUpper();

            return confirmation == "S";
        }

        private List<(Guid productId, int quantity)> GetProductSelection()
        {
            var productIdQuantities = new List<(Guid productId, int quantity)>();

            while (true)
            {
                Console.Write("\nIngrese el ID del producto (N para terminar): ");
                string productIdInput = Console.ReadLine();

                if (productIdInput.ToUpper() == "N")
                {
                    Console.Clear();
                    break;
                }

                if (Guid.TryParse(productIdInput.Trim(), out Guid productId))
                {
                    var product = _productService.GetProductById(productId);

                    if (product != null)
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
                    else
                    {
                        Console.WriteLine("ID de producto no válido.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de producto no válido.");
                }
            }
            return productIdQuantities;
        }
    }
}