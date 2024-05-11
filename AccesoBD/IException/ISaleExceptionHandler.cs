using System;

namespace Aplicacion.IException
{
    public interface ISaleExceptionHandler
    {

        public bool HandleSaleException(Exception ex);

        public bool HandleProductException(Exception ex);

    }
}
