using Aplicacion.IException;
using Application.Interface.ICommand;
using Application.Interface.IPrinter;
using Application.Interface.IService;
using SistemaGestionVentas.Const;
using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;

namespace Application.Service
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductService _product;
        private readonly ISaleConsole _salePrinter;
        private readonly ISaleExceptionHandler _saleExceptionHandler;

        public SaleService(ISaleRepository saleRepository, IProductService product, ISaleConsole printer, ISaleExceptionHandler saleExceptionHandler)
        {
            _saleRepository = saleRepository;
            _product = product;
            _salePrinter = printer;
            _saleExceptionHandler = saleExceptionHandler;
        }
        public bool GenerateSale(List<(Guid productId, int quantity)> productIdsAndQuantities)
        {
            try
            {
                var sale = CalculateSale(productIdsAndQuantities);

                _saleRepository.AddSale(sale);
                _salePrinter.SalePrint(sale);
                return true;
            }
            catch (Exception ex)
            {
                return _saleExceptionHandler.HandleException(ex);
            }
        }
        public Sale CalculateSale(List<(Guid productId, int quantity)> productIdsAndQuantities)
        {
            var sale = new Sale
            {
                Date = DateTime.Now,
                SaleProduct = new List<SaleProduct>()
            };

            decimal subtotal = 0;
            decimal totalDiscount = 0;

            foreach (var (productId, quantity) in productIdsAndQuantities)
            {
                var product = _product.GetProductById(productId);
                if (product != null)
                {
                    decimal discountedPrice = product.Price - (product.Price * (product.Discount / 100.0m));
                    subtotal += product.Price * quantity;
                    totalDiscount += Math.Round((product.Price * quantity) - (discountedPrice * quantity), 2);

                    sale.SaleProduct.Add(new SaleProduct
                    {
                        Product = product.ProductId,
                        Quantity = quantity,
                        Price = product.Price,
                        Discount = product.Discount
                    });
                }
            }

            sale.Subtotal = subtotal;
            sale.TotalDiscount = totalDiscount;
            sale.Taxes = Constantes.Taxes;
            sale.TotalPay = Math.Round(((subtotal - totalDiscount) * sale.Taxes), 2);

            return sale;
        }
    }
}

