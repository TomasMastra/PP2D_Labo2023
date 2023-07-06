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

        public delegate void DelegadoStock(InfoCarneEventArgs infoCarne);
        public static event DelegadoStock StockEnCero;




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
            try
            {
                CargarLista(CarniceriaDAO.ObtenerListaCarne());

                vendedores = VendedorDAO.ObtenerVendedores();
                usuarios.AddRange(vendedores);

                clientes = ClienteDAO.ObtenerClientes();
                usuarios.AddRange(clientes);

                CargarFacturas(Archivos<List<Factura>>.CargarDesdeArchivoXml("Facturas.Xml"));
               
    }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la tienda: " + ex.Message);
            }


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

            facturas.Add(factura);


            return true;
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

        public static List<Usuario>  ObtenerUsuarios()
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

            for (int i = auxListaCompras.Count - 1; i >= 0; i--)
            {
                ListaCompras carro = auxListaCompras[i];
                Carniceria carne = BuscarCarne(carro.IdProducto);

                if (carro.IdProducto == carne.IdCarne)
                {
                    if (carne.CantidadCarne >= carro.CantidadComprada)
                    {
                        totalCompra += (carro.CantidadComprada * carne.PreciosCarne);
                        carne.CantidadCarne -= carro.CantidadComprada;
                        CarniceriaDAO.ModificarCarne(carne);
                        //carro.modificar(carro.CantidadComprada, carne.PreciosCarne);
                    }
                    else
                    {
                        sb.Append($"{carro.CantidadComprada}KG {carne.CortesCarne}\n");
                        auxListaCompras.Remove(carro);
                    }
                }
            }

            totalCompra = CalcularTotal(totalCompra, esRecargo);
            CrearFactura(cliente, totalCompra, esRecargo);
            return sb.ToString();
        }

       


        public static void CrearFactura(Cliente cliente, float totalCompra, bool esRecargo)
        {
            

            if (cliente.ListaCompras.Count > 0)
            {
                Factura factura = new Factura(ObtenerUltimoIdFactura() + 1, totalCompra, cliente.Nombre, (DateTime.Now).ToString());
                AgregarFactura(factura);
                string facturaArchivo = factura.crearFactura(cliente.ListaCompras, factura.Archivo, cliente);

                //string currentDirectory = Environment.CurrentDirectory;
                string archivo = $"{factura.Numero}.txt";
                
                Archivos<String>.GuardarEnArchivoTxt(archivo, facturaArchivo);
                Archivos<List<Factura>>.GuardarEnArchivoXml("Facturas.Xml", Tienda.ObtenerFacturas());


            }
          //  ListaComprasDAO.VaciarCarro(cliente.Id);
            cliente.VaciarCarro();
         //   cliente.ListaCompras.Clear();
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

            foreach(Carniceria corte in carne)
            {
                if(id == corte.IdCarne)
                {
                    return (Carniceria)corte;
                    break;
                }
                
            }
            return null;
        }


        public static int  ObtenerId()
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
            id = ultimaFactura.Numero;

            return id;
        }



        public static int ObtenerUltimoIdCarro()
        {
            int id = 0;

            foreach(Cliente c in clientes)
            {
                foreach (ListaCompras compra in c.ListaCompras)
                {
                    if(compra.IdCarro > id)
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


            foreach(Carniceria corte in carne)
            {
                if(id == corte.IdCarne)
                {
                    corteCarne = corte;
                }
            }

            return corteCarne;
        }


        public static void AgregarStock()
        {
            foreach (Carniceria carne in carne)
            {
                if (carne.CantidadCarne == 0)
                {
                    InfoCarneEventArgs infoCarne = new InfoCarneEventArgs(carne);

                    if (StockEnCero is not null)
                    {
                        try
                        {
                            carne.CantidadCarne += 50;
                            CarniceriaDAO.ModificarCarne(carne);
                            StockEnCero.Invoke(infoCarne);// Invoca el evento y se ejecutan los metodos suscritos

                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Hubo un error al cargar stock: {ex}");
                        }
                    }
                }
            }
        }

    }
}
