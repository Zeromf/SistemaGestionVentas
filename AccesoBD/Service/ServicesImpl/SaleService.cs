using SistemaGestionVentas.Const;
using SistemaGestionVentas.Contexto;
using SistemaGestionVentasTP1.Model;
using SistemaGestionVentasTP1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionVentas.Service
{
    public class SaleService : ISaleService
    {
        private readonly IContextDB _contextoDB;
        private readonly ISaleCalculatorService _saleCalculatorService;

        public SaleService(ISaleCalculatorService saleCalculatorService, IContextDB contextoDB)
        {
            _saleCalculatorService = saleCalculatorService;
            _contextoDB = contextoDB;

        }

        public void RegisterSale(IList<Product> Products, Sale sale, List<Product> productosSeleccionados)
        {
            // Utilizamos el servicio de cálculo de venta para obtener los detalles de la venta
            var saleDetails = _saleCalculatorService.CalculateSaleDetails(productosSeleccionados);


            //Calcular venta
            var newSale = new Sale
            {
                TotalPay = saleDetails.totalPay,
                Subtotal = saleDetails.subtotal,
                TotalDiscount = saleDetails.totalDiscount,
                Taxes = Constantes.Taxes,
                Date = DateTime.Now,
            };

            newSale.SaleProducts = new List<SaleProduct>();

            foreach (var product in productosSeleccionados)
            {
                var saleProduct = new SaleProduct
                {
                    ProductId = product.ProductId,
                    Quantity = 1, // cantidad producto
                    Price = product.Price,
                    Discount = product.Discount
                };

                newSale.SaleProducts.Add(saleProduct);
            }

            _contextoDB.Sales.Add(newSale);
            _contextoDB.SaveChanges();



        }
    }
}
