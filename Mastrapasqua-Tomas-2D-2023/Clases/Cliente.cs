using System.Data.Common;
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

        /// <summary>
        /// Constructor de Cliente con sus argumentos correspondientes y que llama al constructor :this()
        /// </summary>
        public Cliente(Usuario usuario, float dinero, float totalGastado, List<ListaCompras> listado, List<Factura>facturas) : this(usuario)
        {
            this.dinero = dinero;
            this.totalGastado = totalGastado;
            this.listado = listado;
            this.facturas = facturas;
        }
        /// <summary>
        /// Propiedad Dinero con getter y setter que permite devolver o asignarle un valor de un float
        /// </summary>
        public float Dinero
        {
            get { return dinero; }
            set { dinero = value; }
        }

        /// <summary>
        /// Propiedad TotalGastado con getter y setter que permite devolver o asignarle un valor de un int
        /// </summary>
        public float TotalGastado
        {
            get { return totalGastado; }
            set { totalGastado = value; }
        }

        /// <summary>
        /// Propiedad ListaCompras con getter y setter que permite devolver o asignarle un valor de una List
        /// </summary>
        public List<ListaCompras> ListaCompras
        {
            get { return listado; }
            set { listado = value; }
        }

        /// <summary>
        /// Propiedad Factura con getter y setter que permite devolver o asignarle un valor List
        /// </summary>
        public List<Factura> ListaFacturas
        {
            get { return facturas; }
            set { facturas = value; }
        }

        /// <summary>
        /// Muestra datos de un cliente mediante un stringbuilder y el uso de sobrecarga. Retorno el stringBuilder que tiene todos los datos del cliente
        /// </summary>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.Append($"Dinero: {dinero} \n");
            sb.Append($"Total gastado: {totalGastado} \n");


            return sb.ToString();
        }

        /// <summary>
        /// Mediante el cliente pasado por parametro se calcula el total de dinero que gasto sumando el costo de los productos de su carro
        /// </summary>
        public float ObtenerPrecioTotal()
        {
            float total = 0;

            for (int i = 0; i < ListaCompras.Count;i++)
            {
                total = total + ListaCompras[i].PrecioTotal;
            }
            return total;
        }

        /// <summary>
        /// Compara 2 clientes por su mail, si son iguales retorna true
        /// </summary>
        public static bool operator ==(Cliente cliente1, Cliente cliente2)
        {

            if (cliente1.Mail.Equals(cliente2.Mail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Compara 2 clientes por su mail y si son diferentes retorna false
        /// </summary>
        public static bool operator!=(Cliente cliente1, Cliente cliente2)
        {

            return !(cliente1 == cliente2);
        }
    }
}
