using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

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

        /*
         * 
         * static Hospital()
        {
            try
            {
                pacientes = new List<Paciente>();
                cirujanos = new List<Cirujano>();
                cirugias = new List<Cirugia>();
                estadistica = new Estadistica();

                string ruta = SerializacionAJason.GenerarRuta("Pacientes.json");
                pacientes = SerializacionAJason.DeserealizarDesdeJson<List<Paciente>>(ruta);
                ruta = SerializacionAJason.GenerarRuta("Cirujanos.json");
                cirujanos = SerializacionAJason.DeserealizarDesdeJson<List<Cirujano>>(ruta);
                ruta = SerializacionAJason.GenerarRuta("Cirugias.json");
                cirugias = SerializacionAJason.DeserealizarDesdeJson<List<Cirugia>>(ruta);
                Hospital.ActualizarEstadistica(cirugias);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar Hospital", ex);
            }
        }*/
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

                // Obtener vendedores
                vendedores = VendedorDAO.ObtenerVendedores();
                usuarios.AddRange(vendedores);

                // Obtener clientes
                clientes = ClienteDAO.ObtenerClientes();
                usuarios.AddRange(clientes);

                CargarFacturas(Archivos<List<Factura>>.CargarDesdeArchivoXml("Facturas.Xml"));
                // Cargar facturas desde archivo JSON
              //  facturas = Archivos<List<Factura>>.CargarDesdeArchivoJson("Facturas.Json");


                //facturas = new List<Factura>();

    }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al cargar la tienda: " + ex.Message);
                // Puedes realizar acciones adicionales, como registrar el error en un archivo de registro o notificar al administrador del sistema.
            }


        }


         public static void Inicializar()
        {
            // llamar a todos los metodos que cargan la lista

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
                foreach (Carniceria producto in carne)
                {
                    if (producto == corte)
                    {
                        return false;
                    }
                }
                carne.Add(corte);
               // SerializarCprte();
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

        public static void MostrarCortes()
        {
            foreach (Carniceria c in carne)
            {
                Console.WriteLine(c.CortesCarne.ToString());
            }
        }

        public static void AgregarUsuario(Usuario usuario)
        {

            usuarios.Add(usuario);
        }
        public static void AgregarVendedor(Vendedor vendedor)
        {
            vendedores.Add(vendedor);
        }

        public static void AgregarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }



      






        /// <summary>
        /// Modifica la cantidad de carne de todos los cortes comprados por un cliente dependiendo la cantidad comprada
        /// </summary>
        /// <param name="clienteCompra"></param>
        /// <returns></returns>
        public static string RestarCantidadCompra(Cliente clienteCompra)//refactorizar
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("No se puduo comprar: ");
            foreach (Carniceria c in carne)
            {
                for (int i = 0; i < clienteCompra.ListaCompras.Count; i++)
                {
                    if (c.IdCarne == clienteCompra.ListaCompras[i].IdProducto)
                    {
                        if (c.CantidadCarne >= clienteCompra.ListaCompras[i].CantidadComprada)
                        {
                            c.CantidadCarne -= clienteCompra.ListaCompras[i].CantidadComprada;
                            clienteCompra.ListaCompras[i].Comprado = true;
                        }
                        else
                        {
                            sb.Append($"{clienteCompra.ListaCompras[i].CantidadComprada}KG {c.CortesCarne}\n");
                        }
                    }
                }
            }

            return sb.ToString();
        }


        public static string Comprar(Cliente cliente) // Compra todo el carro
        {
            float totalCompra = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("No se pudo comprar: ");

            foreach (Carniceria carne in Tienda.ObtenerCarne())
            {
                foreach(ListaCompras carro in cliente.ListaCompras)
                {
                    if (carro.IdProducto == carne.IdCarne)// Compara si es el mismo producto
                    {
                        if (carne.CantidadCarne >= carro.CantidadComprada)// Compara si hay stock para vender
                        {
                            totalCompra += (carro.CantidadComprada * carne.PreciosCarne);

                            carne.CantidadCarne -= carro.CantidadComprada;
                        }
                        else
                        {
                            sb.Append($"{carro.CantidadComprada}KG {carne.CortesCarne}\n"); // Caso de que no se pudo comprar se agrega al stringbuilder que muestra todo lo que no se pudo comprar
                            cliente.ListaCompras.Remove(carro);
                        }

                    }


                }
            }

            CrearFactura(cliente, totalCompra);
            return sb.ToString();
        }

        public static void CrearFactura(Cliente cliente, float totalCompra)
        {
            

            if (cliente.ListaCompras.Count > 0)
            {
                Factura factura = new Factura(1, totalCompra, cliente.Nombre, (DateTime.Now).ToString());
                AgregarFactura(factura);
                string facturaArchivo = factura.crearFactura(cliente.ListaCompras, factura.Archivo);
                string path = $"ruta/{factura.Archivo}.txt";

                Archivos<String>.GuardarEnArchivoTxt(path, facturaArchivo);
            }
            cliente.ListaCompras.Clear();
            ListaComprasDAO.VaciarCarro(cliente.Id);
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


        public static bool GuardarFacturasArchivo()
        {
            bool ret = false;
            if (facturas.Count > 0)
            {
                foreach (Factura factura in facturas)
                {

                }
                ret = true;
            }
            return false;
        }

        public static void EliminarCarneId(Carniceria corte)
        {
            EliminarCarne(corte);
            CarniceriaDAO.EliminarCarne(corte.IdCarne);

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

    }
}
