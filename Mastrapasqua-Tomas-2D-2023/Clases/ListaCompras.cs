using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaCompras
    {
        string producto;
        int precioTotal;
        int cantidadComprada;
        public ListaCompras(string producto, int precioTotal, int cantidadCompra) 
        { 
            this.producto = producto;
            this.precioTotal = precioTotal;
            this.cantidadComprada = cantidadCompra;
        }

        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public int PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }

        public int CantidadComprada
        {
            get { return cantidadComprada; }
            set { cantidadComprada = value; }
        }

        /*public int CalcularTotal(int precio, int cantidad)
        {
            PrecioTotal = precio*cantidad;

            return PrecioTotal;
        }*/

        


    }
}
