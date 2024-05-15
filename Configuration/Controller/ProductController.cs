using Aplicacion.IException;
using Application.Interface.IPrinter;
using Application.Interface.IService;


namespace Infraestructure.Controller
{
    public class ProductController
    {
        private readonly IProductService _productService;
        private readonly IProductConsole _productConsole;
        private readonly ISaleExceptionHandler _saleExceptionHandler;

        public ProductController(IProductService productService, IProductConsole productPrinter, ISaleExceptionHandler saleExceptionHandler)
        {
            _productService = productService;
            _productConsole = productPrinter;
            _saleExceptionHandler = saleExceptionHandler;
        }

        public void ListarProductos()
        {
            try
            {
                var products = _productService.ListProducts();
                if (products != null)
                {
                    _productConsole.ListProductDetail(products);
                }
            }
            catch (Exception ex)
            {
                _saleExceptionHandler.HandleProductException(ex);
            }
        }
    }
}
