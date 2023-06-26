using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Clases
{
    public static class CarniceriaDAO
    {

        private static string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";

        // OBTENER LISTA

        public static List<Carniceria> ObtenerListaCarne()
        {
            List<Carniceria> listaCarne = new List<Carniceria>();

            // Establecer la cadena de conexión
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";//usar connectionstring de arriba

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
                        int id = Convert.ToInt32(reader["ID_CARNE"]);
                        string corte = reader["CORTE"].ToString();
                        int precio = Convert.ToInt32(reader["PRECIO"]);
                        int cantidad = Convert.ToInt32(reader["CANTIDAD_DISPONIBLE"]);
                        string tipoCarneTexto = reader["TIPO"].ToString();

                        Tipo tipoCarne = Tipo.Res;

                        Carniceria carne = new Carniceria(id, corte, precio, cantidad, tipoCarne);
                        listaCarne.Add(carne);
                        Tienda.AgregarCarne(carne);
                    }

                    // Cerrar el SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al obtener la lista de carne: " + ex.Message);
                }
            }

            return listaCarne;
        }


        public static Carniceria ObtenerCarne(int idCarne)
        {
            Carniceria carne = null;
            // Establecer la cadena de conexión
            string connectionString = @"Data Source=DESKTOP-Q9JTH4D\Tomas Mastra;Database=CARNICERIA;Trusted_Connection=True;";

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
                        int id = Convert.ToInt32(reader["ID_CARNE"]);
                        string corte = reader["CORTE"].ToString();
                        int precio = Convert.ToInt32(reader["PRECIO"]);
                        int cantidad = Convert.ToInt32(reader["CANTIDAD_DISPONIBLE"]);
                        Tipo tipoCarne = (Tipo)Convert.ToInt32(reader["TIPO"]);

                        if (id == idCarne)
                        {
                            carne = new Carniceria(id, corte, precio, cantidad, tipoCarne);
                            
                        }
                    }

                    // Cerrar el SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al obtener la lista de carne: " + ex.Message);
                }
            }

            return carne;
        }




        // AGREGAR
        public static void AgregarCarne(Carniceria carne)
        {
            string query = "INSERT INTO CARNE (ID_CARNE, CORTE, PRECIO, CANTIDAD_DISPONIBLE, TIPO) VALUES (@Id, @Corte, @Precio, @Cantidad, @Tipo)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", carne.IdCarne);
                command.Parameters.AddWithValue("@Corte", carne.CortesCarne);
                command.Parameters.AddWithValue("@Precio", carne.PreciosCarne);
                command.Parameters.AddWithValue("@Cantidad", carne.CantidadCarne);
                command.Parameters.AddWithValue("@Tipo", carne.TipoCarne);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        //ELIMINAR
        public static void EliminarCarne(int id)
        {
            string query = "DELETE FROM CARNE WHERE ID_CARNE = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        //MODIFICAR

        public static void ModificarCarne(Carniceria carne)
        {
            // Actualiza el corte de un id especifico
            string query = "UPDATE CARNE SET CORTE = @Corte, PRECIO = @Precio, CANTIDAD_DISPONIBLE = @Cantidad, TIPO = @Tipo WHERE ID_CARNE = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", carne.IdCarne);
                command.Parameters.AddWithValue("@Corte", carne.CortesCarne);
                command.Parameters.AddWithValue("@Precio", carne.PreciosCarne);
                command.Parameters.AddWithValue("@Cantidad", carne.CantidadCarne);
                command.Parameters.AddWithValue("@Tipo", carne.TipoCarne);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Le pasamos por parametro una lista con los cortes modificados o agregados
        /// Validamos mediante el id si existe para poder modificar y en el caso contraro lo agrega a la base de datos
        /// </summary>
        /// <param name="carne"></param>
        public static void GuardarCambios(List<Carniceria> carne)
        {
            foreach (Carniceria car in Tienda.ObtenerCarne())
            {
                Console.WriteLine(car.Estado);
            }

           
                try {
                    

                    foreach (Carniceria c in carne)
                    {
                    if (c.Estado > 0 && c.Estado < 4)
                    {
                        if (c.Estado == 2)//bien
                        {
                            Console.WriteLine($"Se eliminó {c.CortesCarne}");
                            CarniceriaDAO.EliminarCarne(c.IdCarne);
                        }
                        else if (c.Estado == 3)//bien
                        {
                             Console.WriteLine($"Se modificó {c.CortesCarne}");
                             CarniceriaDAO.ModificarCarne(c);
                            
                        }
                        else //mal
                        {
                            Console.WriteLine($"Se agregó {c.CortesCarne}");
                            CarniceriaDAO.AgregarCarne(c);
                        }
                    }



                }
                }
                catch(Exception ex) 
                {

                }
            
        }


        
    }
}
