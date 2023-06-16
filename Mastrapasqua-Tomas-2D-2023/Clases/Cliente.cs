using System.Data.Common;
using System.Text;

namespace Clases
{
    public class Cliente : Usuario
    {

        float dinero;
        float totalGastado;
        List<ListaCompras> listado;
        //List<Factura> facturas;


        public Cliente(Usuario usuario) :base(usuario)
        {
            this.dinero = 0;
            this.totalGastado = 0;
            listado = new List<ListaCompras>();
        }

        /// <summary>
        /// Constructor de Cliente con sus argumentos correspondientes y que llama al constructor :this()
        /// </summary>
        public Cliente(Usuario usuario, float dinero, float totalGastado, List<ListaCompras> listado) : this(usuario)
        {
            this.dinero = dinero;
            this.totalGastado = totalGastado;
            this.listado = listado;
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
        /*public List<Factura> ListaFacturas
        {
            get { return facturas; }
            set { facturas = value; }
        }*/

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
       

        


        /// <summary>
        /// Vacía el carro del cliente luego de haber comprado o cancelado la compra
        /// </summary>
        public void VaciarCarro()
        {
            ListaCompras.Clear();
        }


        public bool AgregarCarro(ListaCompras productoComprado)
        {
            bool existe = false;
           // List<ListaCompras> listaTemporal = new List<ListaCompras>();

            if (ListaCompras.Count > 0)
            {
                
                foreach (ListaCompras listaCompras in ListaCompras)
                {
                    if (listaCompras.Producto == productoComprado.Producto)
                    {
                        listaCompras.Modificar(productoComprado.CantidadComprada, productoComprado.PrecioTotal);
                        existe = true;
                        break;
                    }

                }

                if (!existe)
                {
                    ListaCompras.Add(productoComprado);
                }
            }
            else
            {
                ListaCompras.Add(productoComprado);

            }

            return existe;
        }
    }
}
