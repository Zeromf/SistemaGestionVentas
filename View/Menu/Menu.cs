using Infraestructure.Controller;


namespace Presentation.Menu
{
    public class Menu
    {
        private readonly ProductController _productController;
        private readonly SaleController _saleController;

        public Menu(ProductController productController, SaleController saleController)
        {
            _productController = productController;
            _saleController = saleController;
        }
        public void ShowMenu()
        {
            string option;
            while (true)
            {
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║        MENÚ PRINCIPAL           ║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.WriteLine("║ 1. Listar productos             ║");
                Console.WriteLine("║ 2. Realizar una venta           ║");
                Console.WriteLine("║ 3. Salir                        ║");
                Console.WriteLine("╚════════════════════════════════╝");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        _productController.ListarProductos();
                        break;
                    case "2":
                        _saleController.CrearVenta();
                        break;
                    case "3":
                        Console.WriteLine("Gracias por utilizar nuestro sistema. ¡Hasta luego!");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }

            }
        }
    }
}
