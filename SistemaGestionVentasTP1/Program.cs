using SistemaGestionVentas.Contexto;
using SistemaGestionVentas.Menu;
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
        private static MenuPrincipal menuPrincipal = new MenuPrincipal();
        static void Main(string[] args)
        {
            menuPrincipal.ImprimirMenu();
        }
    }
}