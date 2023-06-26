using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaCompras
    {
        int idCarro;
        int idCliente;
        int idProducto;
        int cantidadComprada;
        bool comprado;
        int precioTotal;//borrar

        public ListaCompras()
        {
            
        }
        /// <summary>
        /// Constructor ListaCompras que guarda todos los datos guardados en el carrito, una vez que el vendedor le acepte la venta
        /// los elementos del carrito se eliminaran
        /// </summary>
        public ListaCompras(int idCarro, int idCliente, int idProducto, int cantidadCompra) :this()
        { 
            this.idCarro = idCarro;
            this.idCliente = idCliente;
            this.idProducto = idProducto;
            this.cantidadComprada = cantidadCompra;
            this.comprado = false;
        }

        /// <summary>
        /// Propiedad Producto con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int IdCarro
        {
            get { return idCarro; }
            set { idCarro = value; }
        }

        /// <summary>
        /// Propiedad PrecioTotal con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        /// <summary>
        /// Propiedad CantidadComprada con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public int CantidadComprada
        {
            get { return cantidadComprada; }
            set { cantidadComprada = value; }
        }

        public bool Comprado
        {
            get { return comprado; }
            set { comprado = value; }
        }

        public int PrecioTotal
        {
            get { return precioTotal; }
            set { precioTotal = value; }
        }


        public void Modificar(int cantidad, int precio)
        {
            CantidadComprada += cantidad;
            PrecioTotal += precio;

        }

    }
}
