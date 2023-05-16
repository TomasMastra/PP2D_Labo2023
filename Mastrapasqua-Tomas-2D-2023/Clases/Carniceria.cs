//using Cortes;

using System.Data.Common;

namespace Clases
{

    /// <summary>
    /// Representa la carniceria con sus cortes de carne
    /// </summary>
    public class Carniceria
    {
        

        string corteCarne;
        int precioCarne;
        int cantidadDisponible;
        Tipo tipoCarne;


        /// <summary>
        /// Esta clase representa una carniceria con sus cortes de carne y otros elementos
        /// </summary>
        public Carniceria()
        {
            this.corteCarne = string.Empty;
            this.precioCarne = 0;
            this.cantidadDisponible = 0;
        }

        /// <summary>
        /// Crea una nueva instancia de la clase Carniceria con valores iniciales
        /// </summary>
        /// <param name="corte">El nombre del corte de carne</param>
        /// <param name="precio">El precio del corte de carne</param>
        /// <param name="cantidad">La cantidad disponible del corte de carne</param>
        /// <param name="tipo">El tipo de carne</param>
        public Carniceria(string corte, int precio, int cantidad, Tipo tipo) :this()
        {
            this.corteCarne = corte;
            this.precioCarne = precio;
            this.cantidadDisponible = cantidad;
            this.tipoCarne = tipo;

        }

        

        /// <summary>
        /// Propiedad CortesCarne con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public string CortesCarne
        {
            get { return corteCarne; }
            set { corteCarne = value; }
        }

        /// <summary>
        /// Propiedad PreciosCarne con getter y setter que permite devolver o asignarle un valor 
        /// </summary>
        public int PreciosCarne
        {
            get { return precioCarne; }
            set { precioCarne = value; }
        }

        /// <summary>
        /// Propiedad CantidadCarne con getter y setter que permite devolver o asignarle un valor int
        /// </summary>
        public int CantidadCarne
        {
            get { return cantidadDisponible; }
            set { cantidadDisponible = value; }
        }


        /// <summary>
        /// Propiedad TipoCarne con getter y setter que permite devolver o asignarle un valor
        /// </summary>
        public Tipo TipoCarne
        {
            get { return tipoCarne; }
            set { tipoCarne = value; }
        }

        /// <summary>
        /// Modifica los valores del corte de carne
        /// </summary>
        /// <param name="corte">El nuevo nombre del corte de carne</param>
        /// <param name="tipo">El nuevo tipo de carne</param>
        /// <param name="cantidad">La nueva cantidad disponible del corte de carne</param>
        /// <param name="precio">El nuevo precio del corte de carne</param>
        public void modificar(string corte, Tipo tipo, int cantidad, int precio)
        {
            CortesCarne = corte;
            TipoCarne = tipo;
            CantidadCarne = cantidad;
            PreciosCarne = precio;

        }



        /// <summary>
        /// Resta la cantidad comprada de carne a la cantidad disponible (Establece el stock de carne después de que un cliente haya comprado)
        /// </summary>
        /// <param name="cantidadComprada">La cantidad de carne comprada</param>
        /// <returns>La cantidad actualizada de carne disponible</returns>
        public int restarCantidad(int cantidadComprada)
        {
            CantidadCarne = CantidadCarne - cantidadComprada;

            return CantidadCarne;
        }
       
        

      



    }
}
