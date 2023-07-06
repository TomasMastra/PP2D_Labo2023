using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp
{
    public static class StringExtension
    {
        public static string NohayProductos(this string mensaje)
        {
            return "No hay productos en el carro";
        }

        public static string NoSeleccionoCliente(this string mensaje)
        {
            return "No selecciono un cliente";
        }

        public static string CompraExitosa(this string mensaje)
        {
            return "La compra se realizo con exito";
        }

        public static string ObtenerHora(this DateTime fecha)
        {
            fecha = DateTime.Now;
            string fechaStr = fecha.ToString("HH:mm:ss");
            return fechaStr;
        }
    }
}
