using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public static class VendedorDAO
    {

        /// <summary>
        /// Retorna la lista de vendedores obtenida de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Vendedor> ObtenerVendedores()
        {
            List<Vendedor> listaVendedores = new List<Vendedor>();
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
                            vendedor.Id = Convert.ToInt32(reader["ID"]);
                            vendedor.Nombre = reader["NOMBRE"].ToString();
                            vendedor.Edad = Convert.ToInt32(reader["EDAD"]);
                            vendedor.Mail = reader["MAIL"].ToString();
                            vendedor.Password = reader["PASSWORD"].ToString();
                            vendedor.Rol = Convert.ToInt32(reader["ROL"]);

                            // Vendedor
                            vendedor.Sueldo = Convert.ToInt32(reader["SUELDO"]);
                            vendedor.HorasTrabajadas = Convert.ToInt32(reader["HORAS_TRABAJADAS"]);
                            listaVendedores.Add(vendedor);
                        }
                    }

                    // Cerrar el SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al obtener el vendedor: " + ex.Message);
                }
            }

            return listaVendedores;
        }


    }
}
