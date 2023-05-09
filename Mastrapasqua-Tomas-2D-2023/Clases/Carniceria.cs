//using Cortes;

using System.Data.Common;

namespace Clases
{

    public class Carniceria
    {
        /* private List<string> cortesCarne;
         public List<int> preciosCarne;
         private string ubicacion;
         private List<int> cantidadCarne;
         private List<Tipo> tipoCarne;*/

        string corteCarne;
        int precioCarne;
        int cantidadDisponible;
        Tipo tipoCarne;

        public Carniceria()
        {
            
        }
        public Carniceria(string corte, int precio, int cantidad, Tipo tipo)
        {
            this.corteCarne = corte;
            this.precioCarne = precio;
            this.cantidadDisponible = cantidad;
            this.tipoCarne = tipo;

        }

        public string CortesCarne
        {
            get { return corteCarne; }
            set { corteCarne = value; }
        }

        
        public int PreciosCarne
        {
            get { return precioCarne; }
            set { precioCarne = value; }
        }

        public int CantidadCarne
        {
            get { return cantidadDisponible; }
            set { cantidadDisponible = value; }
        }

        

        public Tipo TipoCarne
        {
            get { return tipoCarne; }
            set { tipoCarne = value; }
        }
       

      /*  public static bool operator ==(Carniceria carne1, Carniceria carne2)
        {
            if (ReferenceEquals(carne1, carne2))
            {
                return true;
            }
            else {
                return false;
            }


                //return (carne1.CortesCarne == carne2.CortesCarne);
        }

        public static bool operator !=(Carniceria carne1, Carniceria carne2)
        {


            return !(carne1.CortesCarne == carne2.CortesCarne);
        }*/



    }
}
