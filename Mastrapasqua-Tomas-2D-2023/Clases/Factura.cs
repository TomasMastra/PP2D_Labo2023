using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    /// <summary>
    /// Clase de factura, guarda las facturas de compra de los clientes
    /// </summary>
    public class Factura
    {
        int numero;
        float total;
        string mailCompra;

        /// <summary>
        /// Constructor de Factura
        /// </summary>
        public Factura(int numero, float total, string mailCompra) 
        {
            this.numero = numero;
            this.total = total;
            this.mailCompra = mailCompra;
        
        }

        /// <summary>
        /// Propiedad Numero con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        /// <summary>
        /// Propiedad Total con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        /// <summary>
        /// Propiedad Mail con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public string Mail
        {
            get { return mailCompra; }
            set { mailCompra = value; }
        }

        
    }
}
