using Microsoft.Extensions.DependencyInjection;
using SistemaGestionVentas.Contexto;
using View.Menu;
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
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<MenuPrincipal>()
                .AddScoped<MenuListarProducto>()
                .AddScoped<MenuRegistrarVenta>()
                .AddScoped<IContextDB, ContextDB>()
                .AddScoped<ISaleService, SaleService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<ICategoryService, CategoryService>()
                .BuildServiceProvider();

            MenuPrincipal menuPrincipal = serviceProvider.GetRequiredService<MenuPrincipal>();
            menuPrincipal.ImprimirMenu();
        }
    }
}