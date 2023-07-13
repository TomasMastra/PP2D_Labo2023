using Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Clases
{
    public static class Tienda
    {
        public static string Direccion { get; set; } = "Mitre 1289";
        public static string Mail { get; set; } = "CarniceriaMastra@gmail.com";
        public static int Telefono { get; set; } = 45239868;

        public static List<Carniceria> carne = new List<Carniceria>();
        public static List<Usuario> usuarios = new List<Usuario>();
        public static List<Vendedor> vendedores = new List<Vendedor>();
        public static List<Cliente> clientes = new List<Cliente>();
        public static List<Factura> facturas = new List<Factura>();

        




        public static List<Carniceria> listaCarne
        {
            get { return carne; }
            set { listaCarne = value; }
        }

        public static List<Factura> Listado
        {
            get { return facturas; }
            set { facturas = value; }
        }


        public static void CargarTienda()
        {

            CargarLista(HarcodearCortes());
            usuarios = harcodearUsuarios();

            clientes.Add(harcodearCliente(usuarios[1]));
            clientes.Add(harcodearCliente(usuarios[2]));

            vendedores.Add(harcodearVendedor(usuarios[0]));
            vendedores.Add(harcodearVendedor(usuarios[3]));





        }

        public static List<Carniceria> HarcodearCortes()
        {
            List<string> corteCarne = new List<string> { "Asado", "Vacio", "Bondiola", "Chorizo", "Pollo", "Huevos x 30", "Chimichurri", "Huevo de pavo x 7", "Bife de chorizo", "Matambre", "Morcilla", "Salchicha", "Pechuga de pollo", "Hígado de ternera" };
            List<int> precios = new List<int> { 3000, 2000, 3000, 1000, 900, 1700, 300, 1700, 2500, 1500, 1200, 800, 1100, 900 };
            List<int> cantidad = new List<int> { 20, 20, 35, 40, 0, 55, 90, 70, 30, 20, 40, 60, 0, 15 };
            List<Tipo> tipo = new List<Tipo> { Tipo.Res, Tipo.Res, Tipo.Cerdo, Tipo.Cerdo, Tipo.Pollo, Tipo.Pollo, Tipo.Condimento, Tipo.Pavo, Tipo.Res, Tipo.Pollo, Tipo.Cerdo, Tipo.Cerdo, Tipo.Pollo, Tipo.Res };

            List<Carniceria> cortes = new List<Carniceria>();
            for (int i = 0; i < corteCarne.Count; i++)
            {
                Carniceria carne = new Carniceria(i, corteCarne[i], precios[i], cantidad[i], tipo[i]);
                cortes.Add(carne);
            }

            return cortes;
        }



        public static Vendedor harcodearVendedor(Usuario usuario)
        {

            Vendedor vendedor = new Vendedor(usuario, 200, 90000);

            return vendedor;
        }

        public static Cliente harcodearCliente(Usuario usuario)
        {

            List<ListaCompras> listaCompras = new List<ListaCompras>();
            List<Clases.Factura> facturas = new List<Clases.Factura>();

            ListaCompras listaProductos = new ListaCompras();

            Cliente cliente = new Cliente(usuario, 20000, 2, listaCompras);


            return cliente;
        }
        public static List<Usuario> harcodearUsuarios()
        {
            Usuario usuario1 = new Usuario(1, 20, "Tomas Mastrapasqua", "tomas@gmail.com", "12345", 1);
            Usuario usuario2 = new Usuario(2, 34, "Mariano Martinez", "marianom@gmail.com", "12345", 0);
            Usuario usuario3 = new Usuario(3, 89, "Osvaldo Houston", "osvaldo@outlook.com", "12345", 0);
            Usuario usuario4 = new Usuario(3, 89, "Matias Perez", "matias@outlook.com", "1234567890", 1);


            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios.Add(usuario1);
            listaUsuarios.Add(usuario2);
            listaUsuarios.Add(usuario3);
            listaUsuarios.Add(usuario4);

            return listaUsuarios;
        }

        public static void CargarLista(List<Carniceria> cortes)
        {
            if (cortes != null)
            {
                carne = cortes;
            }
        }

       

       

        public static void CargarFacturas(List<Factura> listaFacturas)
        {
            if (listaFacturas != null)
            {
                facturas = listaFacturas;
            }
        }
        public static bool AgregarCarne(Carniceria corte)
        {
            if (corte != null)
            {
                carne.Add(corte);
                return true;
            }
            return false;
        }

        public static bool AgregarFactura(Factura factura)
        {
            if (factura != null)
            {
                facturas.Add(factura);
                return true;
            }

            return false;
        }


        public static void EliminarCarne(Carniceria corte)
        {
            carne.Remove(corte);
        }

        public static List<Carniceria> ObtenerCarne()
        {
            return carne;
        }

        public static List<Factura> ObtenerFacturas()
        {
            return facturas;
        }

        public static List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public static List<Cliente> ObtenerClientes()
        {
            return clientes;
        }

        public static List<Vendedor> ObtenerVendedores()
        {
            return vendedores;
        }



        public static string Comprar(Cliente cliente, bool esRecargo)
        {
            float totalCompra = 0;
            StringBuilder sb = new StringBuilder();
            List<ListaCompras> auxListaCompras = new List<ListaCompras>(cliente.ListaCompras);
            List<ListaCompras> itemsEliminar = new List<ListaCompras>();

            foreach (ListaCompras carro in auxListaCompras)
            {
                Carniceria carne = BuscarCarne(carro.IdProducto);

                if (carne != null && carro.IdProducto == carne.IdCarne)
                {
                    if (carro.CantidadComprada <= carne.CantidadCarne)
                    {
                        totalCompra += (carro.CantidadComprada * carne.PreciosCarne);
                        carne.CantidadCarne -= carro.CantidadComprada;
                    }
                    else
                    {
                        sb.Append($"{carro.CantidadComprada}KG {carne.CortesCarne}\n");
                        itemsEliminar.Add(carro);
                    }
                }
            }

            foreach (ListaCompras item in itemsEliminar)
            {
                auxListaCompras.Remove(item);
            }

            totalCompra = CalcularTotal(totalCompra, esRecargo);
            CrearFactura(cliente, totalCompra, esRecargo);
            return sb.ToString();
        }




        public static void CrearFactura(Cliente cliente, float totalCompra, bool esRecargo)
        {


            if (cliente.ListaCompras.Count > 0 && totalCompra > 0)
            {
                Factura factura = new Factura(ObtenerUltimoIdFactura() + 1, totalCompra, cliente.Nombre);
                AgregarFactura(factura);

                string archivo = $"{factura.Numero}.txt";




            }
            cliente.VaciarCarro();
        }


        public static float CalcularTotal(float totalCompra, bool esRecargo)
        {


            if (esRecargo)
            {
                return Convert.ToSingle(totalCompra + (totalCompra * 0.05));

            }

            return totalCompra;
        }
        public static Carniceria BuscarCarne(int id)
        {

            foreach (Carniceria corte in carne)
            {
                if (id == corte.IdCarne)
                {
                    return (Carniceria)corte;
                    break;
                }

            }
            return null;
        }


        public static int ObtenerId()
        {

            int id;

            Carniceria ultimoCorte = carne.LastOrDefault();
            id = ultimoCorte.IdCarne;

            return id;
        }

        public static int ObtenerUltimoIdFactura()
        {

            int id;

            Factura ultimaFactura = facturas.LastOrDefault();

            if (ultimaFactura != null)
            {
                id = ultimaFactura.Numero;
            }
            else
            {
                id = 0;
            }

            return id;
        }



        public static int ObtenerUltimoIdCarro()
        {
            int id = 0;

            foreach (Cliente c in clientes)
            {
                foreach (ListaCompras compra in c.ListaCompras)
                {
                    if (compra.IdCarro > id)
                    {
                        id = compra.IdCarro;
                        Console.WriteLine(id);
                    }
                }
            }

            return id;
        }


        public static Carniceria ObtenerCorteCarne(int id)
        {
            Carniceria corteCarne = new Carniceria();


            foreach (Carniceria corte in carne)
            {
                if (id == corte.IdCarne)
                {
                    corteCarne = corte;
                }
            }

            return corteCarne;
        }


        public static void EliminarProductoCarroCliente(int idProducto)
        {
            foreach (Cliente cliente in clientes)
            {
                foreach (ListaCompras lista in cliente.ListaCompras)
                {
                    if (lista.IdProducto == idProducto)
                    {
                        cliente.ListaCompras.Remove(lista);
                        break; 
                    }
                }
            }
        }

    }
}
