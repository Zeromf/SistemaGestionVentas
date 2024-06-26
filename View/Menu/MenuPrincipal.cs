﻿using SistemaGestionVentas.Contexto;
using SistemaGestionVentas.Service;
using SistemaGestionVentasTP1.Service;
using System;

namespace View.Menu
{
    class MenuPrincipal
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoriaService;
        private readonly ISaleService _saleService;
        private readonly IContextDB _contextDB;

        public MenuPrincipal(IProductService productService, ICategoryService categoryService, IContextDB contextDB, ISaleService saleService, ISaleCalculatorService saleCalculatorService)
        {
            _productService = productService;
            _categoriaService = categoryService;
            _contextDB = contextDB;
            _saleService = saleService;
        }

        public void ImprimirMenu()
        {

            _contextDB.EnsuredCreated();

            MenuListarProducto menuListarProducto = new MenuListarProducto(_productService, _categoriaService);
            MenuRegistrarVenta menuRegistrarVenta = new MenuRegistrarVenta(_contextDB, _productService, _saleService, _categoriaService);
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
                        Console.Clear();
                        menuRegistrarVenta.CalcularVenta();
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
