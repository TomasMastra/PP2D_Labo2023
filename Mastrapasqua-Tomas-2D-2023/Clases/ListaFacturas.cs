using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public static class ListaFacturas
    {


        static List<Factura> listaFacturas = new List<Factura>();

       

        public static List<Factura> Listado
        {
            get { return listaFacturas; }
            set { listaFacturas = value; }
        }

      

        public static bool Agregar(Factura factura)
        {

            listaFacturas.Add(factura);
            return true;
        }

        public static List<Factura> Obtener()
        {
            return listaFacturas;
        }


    }
}
