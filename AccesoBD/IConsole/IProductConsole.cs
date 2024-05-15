using SistemaGestionVentasTP1.Model;
using System;
using System.Collections.Generic;

namespace Application.Interface.IPrinter
{
    public interface IProductConsole
    {
        public void ListProductDetail(List<Product> products);
        public void PrintProduct(Product product);

        public void ProductSelectionConfirmation(Product product, Guid productId, List<(Guid productId, int quantity)> productIdQuantities);

        public void ProductInvalid();

        public string EnterProductId();

        public void ConsoleClear();

        public bool ShouldExit(string input);
    }
}
