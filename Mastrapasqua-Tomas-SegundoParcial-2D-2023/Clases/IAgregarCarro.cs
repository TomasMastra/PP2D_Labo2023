using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    internal interface IAgregarCarro
    {

        bool AgregarCarro(ListaCompras producto);

        void VaciarCarro();
        

    }
}
