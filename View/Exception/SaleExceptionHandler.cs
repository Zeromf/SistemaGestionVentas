using Aplicacion.IException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Exception
{
    public class SaleExceptionHandler : ISaleExceptionHandler
    {
        public bool HandleSaleException(System.Exception ex)
        {
            Console.WriteLine("Error al crear la venta: " + ex.Message);
            return false;
        }

        public bool HandleProductException(System.Exception ex)
        {
            Console.WriteLine("\nERROR: Ocurrió un error al listar. Detalles: " + ex.Message);
            return false;
        }

    }
}
