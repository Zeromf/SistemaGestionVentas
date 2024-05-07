using Application.Interface.IPrinter;
using Application.Interface.IService;


namespace Infraestructure.Controller
{
    public class ProductController
    {
        private readonly IProductService _productService;
        private readonly IProductPrinter _productPrinter;

        public ProductController(IProductService productService, IProductPrinter productPrinter)
        {
            _productService = productService;
            _productPrinter = productPrinter;
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
                Console.WriteLine("\nERROR: Ocurrió un error al listar. Detalles: " + ex.Message);
            }
        }
    }
}
