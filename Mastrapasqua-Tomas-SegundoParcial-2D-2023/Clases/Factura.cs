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
        public string Archivo { get; set; }

        /// <summary>
        /// Constructor de Factura
        /// </summary>
        [JsonConstructor]

        public Factura()
        {
        }
        public Factura(int numero, float total, string mailCompra, string archivo) :this()
        {
            Numero = numero;
            Total = total;
            Mail = mailCompra;
            Archivo = archivo;
        }

        /// <summary>
        /// Propiedad Numero con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        

        public string crearFactura(List<ListaCompras> carro, string archivo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("FACTURA");
            sb.AppendLine("-------");
            sb.AppendLine($"Nombre del comprador: {Mail}");
            sb.AppendLine($"Total: {Total}");
            sb.AppendLine($"Dirección: {Tienda.Direccion}");
            sb.AppendLine($"Telefono: {Tienda.Telefono}");

            sb.AppendLine("Detalles de los productos:");

            foreach (ListaCompras producto in carro)
            {
                Carniceria CorteCarne = Tienda.BuscarCarne(producto.IdProducto);
                if (CorteCarne != null)
                {
                    int subtotal = producto.CantidadComprada * CorteCarne.PreciosCarne;
                    sb.AppendLine("------------------------");
                    sb.AppendLine($"Producto: {CorteCarne.CortesCarne}");
                    sb.AppendLine($"Cantidad: {CorteCarne.CantidadCarne}");
                    sb.AppendLine($"Precio unitario: {CorteCarne.PreciosCarne}");
                    sb.AppendLine($"Subtotal: {subtotal}");
                    sb.AppendLine("------------------------");
                }
                
            }

            sb.AppendLine($"Total a pagar: {Total}");



            return sb.ToString();
        }

        



    }
}
