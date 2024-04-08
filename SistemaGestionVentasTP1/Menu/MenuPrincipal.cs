using SistemaGestionVentas.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentas.Menu
{
    class MenuPrincipal
    {

        public void ImprimirMenu() {
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
                        MenuListarProducto.ListarProductos();
                        break;
                    case "2":
                        MenuRegistrarVenta.RealizarVenta();
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

    }
}
