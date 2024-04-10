using SistemaGestionVentas.Contexto;
using SistemaGestionVentas.Service;
using SistemaGestionVentasTP1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentas.Menu
{
    class MenuPrincipal
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoriaService;
        private readonly ISaleService _saleService;
        private readonly IContextDB _contextDB;
        public MenuPrincipal(IProductService productService, ICategoryService categoryService, IContextDB contextDB, ISaleService saleService)
        {
            _productService = productService;
            _categoriaService = categoryService;
            _contextDB =contextDB;
            _saleService = saleService;
        }

        public void ImprimirMenu() {
            MenuListarProducto menuListarProducto = new MenuListarProducto(_productService, _categoriaService);
            MenuRegistrarVenta menuRegistrarVenta = new MenuRegistrarVenta(_contextDB, _productService, _saleService);
            //creates db if not exists 
            ContextDB context = new ContextDB();
            context.Database.EnsureCreated();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("╔════════════════════════════════╗");
                Console.WriteLine("║        MENÚ PRINCIPAL           ║");
                Console.WriteLine("╠════════════════════════════════╣");
                Console.WriteLine("║ 1. Listar productos             ║");
                Console.WriteLine("║ 2. Realizar una venta           ║");
                Console.WriteLine("║ 3. Salir                        ║");
                Console.WriteLine("╚════════════════════════════════╝");

                Console.Write("Ingrese su opción: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        menuListarProducto.ListarProductos();
                        break;
                    case "2":
                        menuRegistrarVenta.RealizarVenta();
                        break;
                    case "3":
                        Console.WriteLine("Gracias por utilizar nuestro sistema. ¡Hasta luego!");
                        exit = true;
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
