using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clases
{
    /// <summary>
    /// Clase de factura, guarda las facturas de compra de los clientes para luego mostrarlas
    /// </summary>
    public class Factura
    {
        public int Numero { get; set; }
        public float Total { get; set; }
        public string Mail { get; set; }

        /// <summary>
        /// Constructor de Factura
        /// </summary>

        public Factura()
        {
        }

        public Factura(int numero, float total, string mailCompra) : this()
        {
            Numero = numero;
            Total = total;
            Mail = mailCompra;
        }

      

        




    }
}
