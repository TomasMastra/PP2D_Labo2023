using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public static class ListaComprasDAO
    {
        /// <summary>
        /// Obtiene y retorna el carro de un cliente pasado por parametro
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static List<ListaCompras> ObtenerCarroUnCliente(Cliente cliente)
        {
            List<ListaCompras> carro = new List<ListaCompras>();
            // Establecer la cadena de conexión
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    string query = "SELECT * FROM CARRO WHERE ID_CLIENTE = @clienteId;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@clienteId", cliente.Id);

                    // Ejecutar el comando y obtener los datos en un SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();

                    // Leer los datos y agregarlos a la lista de Carne
                    while (reader.Read())
                    {
                        int idCliente = Convert.ToInt32(reader["ID_CLIENTE"]); // id del cliente que agrego ese producto a su carro

                        // Compara si el producto le pertenece a ese cliente
                        if (cliente != null && cliente.Id == idCliente)
                        {
                            int idCarro = Convert.ToInt32(reader["ID_CARRO"]); // id del elemento (corrección realizada)
                            int idProducto = Convert.ToInt32(reader["ID_PRODUCTO"]); // id del corte de carne
                            int cantidad = Convert.ToInt32(reader["CANTIDAD"]); // cantidad comprada


                            carro.Add(new ListaCompras(idCarro, idCliente, idProducto, cantidad));

                        }
                    }

                    // Cerrar el SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine($"Error al obtener el carro de {cliente.Nombre}: " + ex.Message);
                }
                finally
                {
                    // Asegurarse de cerrar el SqlDataReader en caso de excepción
                   /* if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }*/
                }
            }

            return carro;
        }


        /// <summary>
        /// Vacia el carro de un cliente que acaba de comprar
        /// </summary>
        /// <param name="id"></param>
        public static void VaciarCarro(int id)
        {
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

            string query = "DELETE FROM CARRO WHERE ID_CLIENTE = @Id";

            List < Cliente > clientes = Tienda.ObtenerClientes();
            foreach (Cliente c in clientes)
            {
                foreach (ListaCompras carro in c.ListaCompras)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        public static void AgregarCarro(ListaCompras carro)
        {
            Console.WriteLine($"{carro.IdCarro} - {carro.IdCliente} - {carro.IdProducto} - {carro.CantidadComprada}");
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

            string query = "INSERT INTO CARRO (ID_CARRO, ID_CLIENTE, ID_PRODUCTO, CANTIDAD) VALUES (@Id_Carro, @Id_Cliente, @Id_Producto, @Cantidad)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id_Carro", carro.IdCarro);
                command.Parameters.AddWithValue("@Id_Cliente", carro.IdCliente);
                command.Parameters.AddWithValue("@Id_Producto", carro.IdProducto);
                command.Parameters.AddWithValue("@Cantidad", carro.CantidadComprada);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        //ELIMINAR
        public static void EliminarProducto(int id)
        {
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

            string query = "DELETE FROM CARRO WHERE ID_PRODUCTO = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        //MODIFICAR

        public static void ModificarProducto(int cantidad, int idCarro)
        {
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

            // Actualiza el corte de un id especifico
            string query = "UPDATE CARRO SET CANTIDAD = @Cantidad WHERE ID_CARRO = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.Parameters.AddWithValue("@Id", idCarro); // Agrega el parámetro @Id con el valor de idCarro

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static int ObtenerUltimoId()
        {
            int id = 0;
            // Establecer la cadena de conexión
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();
                    /*
                     * 
                     * 
                     * 
                     * 
                    // Crear el comando SQL para obtener los datos de la tabla "VENDEDOR"
                    string query = "SELECT * FROM VENDEDOR;";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y obtener los datos en un SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();

                    // Leer los datos y agregarlos a la lista de Vendedores
                    while (reader.Read())
                    {

                       // if (usuario.Id == usuarioId)
                        {
                            Vendedor vendedor = new Vendedor();

                            // Usuario
                            vendedor.Id = Convert.ToInt32(reader["ID"]);*/
                    string query = "SELECT * FROM CARRO;";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y obtener los datos en un SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();

                    // Leer los datos y agregarlos a la lista de Carne
                    while (reader.Read())
                    {
                        int idCarro = Convert.ToInt32(reader["ID_CARRO"]); // id del cliente que agrego ese producto a su carro

                        // Compara si el producto le pertenece a ese cliente
                        if (idCarro > id)
                        {
                            id = idCarro;
                        }
                    }

                    // Cerrar el SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine($"Error al obtener el id  {id}: " + ex.Message);
                }
                finally
                {
                    // Asegurarse de cerrar el SqlDataReader en caso de excepción
                    /* if (reader != null && !reader.IsClosed)
                     {
                         reader.Close();
                     }*/
                }
            }

            return id;
        }

    }
}
