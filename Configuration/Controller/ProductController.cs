using Aplicacion.IException;
using Application.Interface.IPrinter;
using Application.Interface.IService;


namespace Infraestructure.Controller
{
    public class ProductController
    {
        private readonly IProductService _productService;
        private readonly IProductPrinter _productPrinter;
        private readonly ISaleExceptionHandler _saleExceptionHandler;

        public ProductController(IProductService productService, IProductPrinter productPrinter, ISaleExceptionHandler saleExceptionHandler)
        {
            _productService = productService;
            _productPrinter = productPrinter;
            _saleExceptionHandler = saleExceptionHandler;
        }

        public void ListarProductos()
        {
            try
            {
                var products = _productService.ListProducts();
                if (products != null)
                {
                    _productPrinter.ListProductDetail(products);
                }
            }
            catch (Exception ex)
            {
                _saleExceptionHandler.HandleProductException(ex);
            }
        }
    }
}
