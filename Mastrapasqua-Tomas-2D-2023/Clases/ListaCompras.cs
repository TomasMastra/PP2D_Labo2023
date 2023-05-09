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

        /// <summary>
        /// Constructor ListaCompras que guarda todos los datos guardados en el carrito, una vez que el vendedor le acepte la venta
        /// los elementos del carrito se eliminaran
        /// </summary>
        public ListaCompras(string producto, int precioTotal, int cantidadCompra) 
        { 
            this.producto = producto;
            this.precioTotal = precioTotal;
            this.cantidadComprada = cantidadCompra;
        }

        /// <summary>
        /// Propiedad Producto con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        /// <summary>
        /// Propiedad PrecioTotal con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }

        /// <summary>
        /// Propiedad CantidadComprada con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int CantidadComprada
        {
            get { return cantidadComprada; }
            set { cantidadComprada = value; }
        }

        


       
        


    }
}
