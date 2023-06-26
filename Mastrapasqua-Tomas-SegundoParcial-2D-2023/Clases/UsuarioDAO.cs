using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public static class UsuarioDAO
    {
        private static string connectionString;



        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            // Establecer la cadena de conexión
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear el comando SQL para obtener los datos de la tabla "USUARIO"
                    string query = "SELECT * FROM USUARIO;";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y obtener los datos en un SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();

                    // Leer los datos y agregarlos a la lista de usuarios
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID_USUARIO"]);
                        string nombre = reader["NOMBRE"].ToString();
                        int edad = Convert.ToInt32(reader["EDAD"]);
                        string mail = reader["MAIL"].ToString();
                        string password = reader["PASSWORD"].ToString();
                        DateTime creacionCuenta = Convert.ToDateTime(reader["CREACION_CUENTA"]);
                        int rol = Convert.ToInt32(reader["ROL"]);

                        Usuario usuario = new Usuario(id, edad,nombre, mail, password, rol);
                        Tienda.AgregarUsuario(usuario);
                        usuarios.Add(usuario);
                    }

                    // Cerrar el SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al obtener la lista de usuarios: " + ex.Message);
                }
            }

            return usuarios;
        }

        public static Usuario ObtenerUsuario(string mailIngresado, string passwordIngresada)
        {
            Usuario usuario = null;

            // Establecer la cadena de conexión
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear el comando SQL para obtener los datos de la tabla "CARNE"
                    string query = "SELECT * FROM CARNE;";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y obtener los datos en un SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();

                    // Leer los datos y agregarlos a la lista de Carne
                    while (reader.Read())
                    {
                        
                            
                            string mail = reader["MAIL"].ToString();
                            string password = reader["PASSWORD"].ToString();
                            

                        if (mail == mailIngresado && password == passwordIngresada)
                        {

                            int id = Convert.ToInt32(reader["ID"]);
                            string nombre = reader["NOMBRE"].ToString();
                            int edad = Convert.ToInt32(reader["EDAD"]);
                            DateTime creacionCuenta = Convert.ToDateTime(reader["CREACION_CUENTA"]);
                            int rol = Convert.ToInt32(reader["ROL"]);

                            usuario = new Usuario(id, edad, nombre, mail, password, rol);

                            break;
                            
                        }
                    }

                    // Cerrar el SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al obtener la lista de usuarios: " + ex.Message);
                }
            }

            return usuario;
        }
    }
}
