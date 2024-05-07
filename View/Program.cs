using Application.Interface.ICommand;
using Application.Interface.IPrinter;
using Application.Interface.IQuery;
using Application.Interface.IService;
using Application.Service;
using Infraestructura.Persistence.Contexto;
using Infraestructura.Query;
using Infraestructure.Command;
using Infraestructure.Controller;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Menu;
using Presentation.Printers;


class Program
{
    static void Main()
    {
        var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<ContextDB>();
                services.AddTransient<IProductQuery, ProductQuery>();
                services.AddTransient<IProductService, ProductService>();
                services.AddTransient<ISaleService, SaleService>();
                services.AddTransient<ISaleRepository, SaleRepository>();
                services.AddScoped<ISalePrinter, SaleConsole>();
                services.AddScoped<IProductPrinter, ProductConsole>();
                services.AddScoped<ProductController>();
                services.AddScoped<SaleController>();
                services.AddScoped<Menu>();
            });

        var app = builder.Build();
        var menu = app.Services.GetRequiredService<Menu>();
        menu.ShowMenu();
        app.Run();
    }
}
