using Microsoft.Extensions.DependencyInjection;
using SistemaGestionVentas.Contexto;
using SistemaGestionVentas.Service;
using SistemaGestionVentasTP1.Service;
using View.Menu;

namespace SistemaGestionVentasTP1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ISaleCalculatorService, SaleCalculatorService>()
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