using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ExcepcionServidor : Exception
    {

        public ExcepcionServidor(string mensaje, List<Exception> e) : base(mensaje)
        {

        }
    }
}
