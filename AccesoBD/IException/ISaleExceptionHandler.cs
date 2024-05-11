using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.IException
{
    public interface ISaleExceptionHandler
    {

        public bool HandleException(Exception ex);

    }
}
