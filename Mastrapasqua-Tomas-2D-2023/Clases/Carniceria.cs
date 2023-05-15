//using Cortes;

using System.Data.Common;

namespace Clases
{

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

        public void modificar(string corte, Tipo tipo, int cantidad, int precio)
        {
            CortesCarne = corte;
            TipoCarne = tipo;
            CantidadCarne = cantidad;
            PreciosCarne = precio;

        }

        

        public int restarCantidad(int cantidadComprada)
        {
            CantidadCarne = CantidadCarne - cantidadComprada;

            return CantidadCarne;
        }
       
        

      



    }
}
