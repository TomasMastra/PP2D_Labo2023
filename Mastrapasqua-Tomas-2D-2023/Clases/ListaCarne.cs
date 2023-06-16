using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public static class ListaCarne
    {
       private static List<Carniceria> listaCarne = new List<Carniceria>();

        

        public static List<Carniceria> Listado
        {
            get { return listaCarne; }
            set { listaCarne = value; }
        }

        public static void PedirDatos()//NO SE USA FORM
        {
            Console.WriteLine($"Ingrese nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine($"edad: ");
            int edad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Ingrese mail: ");
            string mail = (Console.ReadLine());

            Console.WriteLine($"Ingrese password: ");
            string password = (Console.ReadLine());


          /*  Usuario usuarioAgregar = new Usuario(12, edad, nombre, mail, password, 1);
            Vendedor vendedorAgregar = new Vendedor(usuarioAgregar, carne, 12, 121, facturas);

            listaCarne.Add(vendedorAgregar);*/
        }

        public static void Agregar(Carniceria corte)
        {
            listaCarne.Add(corte);
        }

        public static void Eliminar(Carniceria corte)
        {
            listaCarne.Remove(corte);
        }

        public static List<Carniceria> Obtener()
        {
            return listaCarne;
        }

        public static void MostrarVendedores()//NO SE USA FORM
        {
            foreach (Carniceria v in listaCarne)
            {
                Console.WriteLine(v.CortesCarne.ToString());
            }
        }

        


        /// <summary>
        /// Modifica la cantidad de carne de todos los cortes comprados por un cliente dependiendo la cantidad comprada
        /// </summary>
        /// <param name="clienteCompra"></param>
        /// <returns></returns>
        public static string RestarCantidadCompra(Cliente clienteCompra)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("No se puduo comprar: ");
            foreach(Carniceria carne in listaCarne)
            {
                for(int i = 0; i < clienteCompra.ListaCompras.Count; i++)
                {
                    if(carne.CortesCarne == clienteCompra.ListaCompras[i].Producto)
                    {
                        if (carne.CantidadCarne >= clienteCompra.ListaCompras[i].CantidadComprada)
                        {
                            carne.CantidadCarne -= clienteCompra.ListaCompras[i].CantidadComprada;
                            clienteCompra.ListaCompras[i].Comprado = true;
                        }
                        else
                        {
                            sb.Append($"{clienteCompra.ListaCompras[i].CantidadComprada}KG {clienteCompra.ListaCompras[i].Producto}\n");
                        }
                    }
                }
            }

            return sb.ToString();
        }


        public static string Comprar(Cliente cliente)
        {
            float total = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("No se puduo comprar: ");

            foreach (Carniceria carne in ListaCarne.Obtener())
            {
                for (int i = 0; i < cliente.ListaCompras.Count; i++)
                {
                    if (cliente.ListaCompras[i].Producto == carne.CortesCarne)
                    {
                        if (carne.CantidadCarne >= cliente.ListaCompras[i].CantidadComprada)
                        {
                            total = total + cliente.ListaCompras[i].PrecioTotal;

                            carne.CantidadCarne -= cliente.ListaCompras[i].CantidadComprada;
                        }
                        else
                        {
                            sb.Append($"{cliente.ListaCompras[i].CantidadComprada}KG {cliente.ListaCompras[i].Producto}\n");
                        }

                    }


                }
            }
            cliente.ListaCompras.Clear();

            if (total > 0)
            {
                Factura factura = new Factura(1, total, cliente.Nombre);

                ListaFacturas.Agregar(factura);
            }
            return sb.ToString();
        }
    }
}
