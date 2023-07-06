using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Clases
{
    public static class CarniceriaDAO
    {

        private static string connectionString = @"Data Source=DESKTOP-Q9JTH4D;Database=CARNICERIA;Trusted_Connection=True;";
        private static SqlConnection connection;

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

                        if (!Enum.TryParse(tipoCarneTexto, out  Tipo tipoCarne))
                        {
                            tipoCarne = Tipo.Otro;
                        }
                        
                        Carniceria carne = new Carniceria(id, corte, precio, cantidad, tipoCarne);
                        listaCarne.Add(carne);
                        //Tienda.AgregarCarne(carne);
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
                        string tipoCarneTexto = reader["TIPO"].ToString();

                        if (!Enum.TryParse(tipoCarneTexto, out Tipo tipoCarne))
                        {
                            tipoCarne = Tipo.Otro;
                        }



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

            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", carne.IdCarne);
                    command.Parameters.AddWithValue("@Corte", carne.CortesCarne);
                    command.Parameters.AddWithValue("@Precio", carne.PreciosCarne);
                    command.Parameters.AddWithValue("@Cantidad", carne.CantidadCarne);
                    command.Parameters.AddWithValue("@Tipo", carne.TipoCarne.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException ||
                    ex is InvalidOperationException ||
                    ex is SqlNullValueException)
                {
                    innerExceptions.Add(ex);
                }

                if (innerExceptions.Count > 0)
                {
                    throw new ExcepcionServidor("Hubo un error con la base de datos", innerExceptions);
                }
            }
            finally
            {
                connection.Close();


            }
        }


        //ELIMINAR
        public static void EliminarCarne(int id)
        {
            string query = "DELETE FROM CARNE WHERE ID_CARNE = @Id";

            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException ||
                    ex is InvalidOperationException ||
                    ex is SqlNullValueException)
                {
                    innerExceptions.Add(ex);
                }

                if (innerExceptions.Count > 0)
                {
                    throw new ExcepcionServidor("Hubo un error con la base de datos", innerExceptions);
                }
            }
            finally
            {
                connection.Close();
            }
        }


        //MODIFICAR

        public static void ModificarCarne(Carniceria carne)
        {
            try
            {
                // Actualiza el corte de un id especifico
                string query = "UPDATE CARNE SET CORTE = @Corte, PRECIO = @Precio, CANTIDAD_DISPONIBLE = @Cantidad, TIPO = @Tipo WHERE ID_CARNE = @Id";

                using (connection = new SqlConnection(connectionString))
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
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is SqlException ||
                    ex is InvalidOperationException ||
                    ex is SqlNullValueException)
                {
                    innerExceptions.Add(ex);
                }

                if (innerExceptions.Count > 0)
                {
                    throw new ExcepcionServidor("Hubo un error con la base de datos", innerExceptions);
                }
            }
            finally
            {
                connection.Close();


            }
        }


       

        
    }
}
