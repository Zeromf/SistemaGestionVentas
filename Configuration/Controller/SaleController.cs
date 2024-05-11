using Application.Interface.IPrinter;
using Application.Interface.IService;


namespace Infraestructure.Controller
{
    public class SaleController
    {
        private readonly ISaleService _saleService;
        private readonly ISaleConsole _saleConsole;
        private readonly IProductPrinter _productConsole;

        private readonly IProductService _productService;

        public SaleController(ISaleService saleService, ISaleConsole saleConsole, IProductService productService, IProductPrinter productConsole)
        {
            _saleService = saleService;
            _saleConsole = saleConsole;
            _productConsole = productConsole;
            _productService = productService;
        }

        public void CrearVenta()
        {
            var productIdsAndQuantities = GetProductSelection();

            if (productIdsAndQuantities.Count == 0)
            {
                _saleConsole.SaleNotProduct();
                return;
            }

            var sale = _saleService.CalculateSale(productIdsAndQuantities);
            _saleConsole.SaleDetail(sale);

            bool saleRegistration = _saleConsole.ConfirmSaleRegistration();

            if (saleRegistration)
            {
                bool generateSale = _saleService.GenerateSale(productIdsAndQuantities);
                _saleConsole.SalesConfirm(generateSale);
            }
            else {
               return; 
            }
 
        }


        private List<(Guid productId, int quantity)> GetProductSelection()
        {
            var productIdQuantities = new List<(Guid productId, int quantity)>();

            while (true)
            {

                string productIdInput = _productConsole.EnterProductId();

                if (_productConsole.ShouldExit(productIdInput))
                {
                    _productConsole.ConsoleClear();
                    break;
                }

                if (Guid.TryParse(productIdInput.Trim(), out Guid productId))
                {
                    var product = _productService.GetProductById(productId);

                    if (product != null)
                    {
                        _productConsole.ProductSelectionConfirmation(product,productId,productIdQuantities);
                    }
                }
                else
                {
                    _productConsole.ProductInvalid();
                }
            }
            return productIdQuantities;
        }
    }
}