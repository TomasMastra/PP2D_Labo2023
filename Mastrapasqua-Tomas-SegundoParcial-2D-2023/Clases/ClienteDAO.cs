using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public static class ClienteDAO
    {

        public static List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            // Establecer la cadena de conexión
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear el comando SQL para obtener los datos de la tabla "VENDEDOR"
                    string query = "SELECT * FROM CLIENTE;";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y obtener los datos en un SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();

                    // Leer los datos y agregarlos a la lista de Vendedores
                    while (reader.Read())
                    {

                        // if (usuario.Id == usuarioId)
                        {
                            Cliente cliente = new Cliente();

                            // Usuario
                            cliente.Id = Convert.ToInt32(reader["ID"]);
                            cliente.Nombre = reader["NOMBRE"].ToString();
                            cliente.Edad = Convert.ToInt32(reader["EDAD"]);
                            cliente.Mail = reader["MAIL"].ToString();
                            cliente.Password = reader["PASSWORD"].ToString();
                            cliente.Rol = Convert.ToInt32(reader["ROL"]);
                            // Cliente
                            cliente.Dinero = Convert.ToInt32(reader["DINERO"]);
                            cliente.TotalGastado = Convert.ToInt32(reader["TOTAL_GASTADO"]);
                            cliente.ListaCompras = ListaComprasDAO.ObtenerCarroUnCliente(cliente);
                            


                            listaClientes.Add(cliente);
                        }
                    }

                    // Cerrar el SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al obtener el cliente: " + ex.Message);
                }
            }

            return listaClientes;
        }


    }
}
