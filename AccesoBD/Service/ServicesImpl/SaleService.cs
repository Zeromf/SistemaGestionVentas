using SistemaGestionVentas.Const;
using SistemaGestionVentas.Contexto;
using SistemaGestionVentasTP1.Model;
using SistemaGestionVentasTP1.Service;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void RegisterSale(IList<Product> Products, Sale sale, List<(Product product, int quantity)> productosSeleccionados)
        {
            // Utilizamos el servicio de cálculo de venta para obtener los detalles de la venta
            var saleDetails = _saleCalculatorService.CalculateSaleDetails(productosSeleccionados);

            // Calcular venta
            var newSale = new Sale
            {
                TotalPay = saleDetails.totalPay,
                Subtotal = saleDetails.subtotal,
                TotalDiscount = saleDetails.totalDiscount,
                Taxes = Constantes.Taxes,
                Date = DateTime.Now,
            };

            newSale.SaleProduct = new List<SaleProduct>();

            foreach (var selectedProduct in productosSeleccionados)
            {
                var product = Products.FirstOrDefault(p => p.ProductId == selectedProduct.product.ProductId);

                if (product != null)
                {
                    var existingProduct = newSale.SaleProduct.FirstOrDefault(sp => sp.ProductId == product.ProductId);

                    if (existingProduct != null)
                    {
                        existingProduct.Quantity += selectedProduct.quantity;
                    }
                    else
                    {
                        var saleProduct = new SaleProduct
                        {
                            ProductId = product.ProductId,
                            Quantity = selectedProduct.quantity,
                            Price = product.Price,
                            Discount = product.Discount
                        };

                        newSale.SaleProduct.Add(saleProduct);
                    }
                }
            }

            _contextoDB.Sale.Add(newSale);
            _contextoDB.SaveChanges();
        }
    }
}

