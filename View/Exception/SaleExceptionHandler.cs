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
        public bool HandleException(System.Exception ex)
        {
            Console.WriteLine("Error al crear la venta: " + ex.Message);
            return false;
        }
    }
}
