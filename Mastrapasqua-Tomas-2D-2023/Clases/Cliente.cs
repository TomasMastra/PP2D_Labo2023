using System.Text;

namespace Clases
{
    public class Cliente : Usuario
    {

        float dinero;
        float totalGastado;
        List<ListaCompras> listado;
        List<Factura> facturas;

        public Cliente(Usuario usuario) :base(usuario)
        {
            this.dinero = 0;
            this.totalGastado = 0;
            listado = new List<ListaCompras>();
            facturas = new List<Factura>();
        }

        public Cliente(Usuario usuario, float dinero, float totalGastado, List<ListaCompras> listado, List<Factura>facturas) : this(usuario)
        {
            this.dinero = dinero;
            this.totalGastado = totalGastado;
            this.listado = listado;
            this.facturas = facturas;
        }

        public float Dinero
        {
            get { return dinero; }
            set { dinero = value; }
        }

        public float TotalGastado
        {
            get { return totalGastado; }
            set { totalGastado = value; }
        }

        public List<ListaCompras> ListaCompras
        {
            get { return listado; }
            set { listado = value; }
        }

        public List<Factura> ListaFacturas
        {
            get { return facturas; }
            set { facturas = value; }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.Append($"Dinero: {dinero} \n");
            sb.Append($"Total gastado: {totalGastado} \n");


            return sb.ToString();
        }

    }
}
