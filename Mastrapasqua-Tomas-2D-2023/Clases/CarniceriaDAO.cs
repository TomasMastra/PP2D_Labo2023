using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Clases
{
    public class CarniceriaDAO
    {

     /*   private string connectionString;

        public CarniceriaDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // OBTENER LISTA

        public static List<Carne> ObtenerListaCarne()
        {
            List<Carne> listaCarne = new List<Carne>();

            // Establecer la cadena de conexión
            string connectionString = "tu_cadena_de_conexion";

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
                        int id = Convert.ToInt32(reader["ID"]);
                        string nombre = reader["NOMBRE"].ToString();
                        float precio = Convert.ToSingle(reader["PRECIO"]);
                        string producto = reader["PRODUCTO"].ToString();
                        int cantidad = Convert.ToInt32(reader["CANTIDAD"]);

                        Carniceria carne = new Carniceria(nombre, precio, producto, cantidad);
                       // listaCarne.Add(carne);
                        ListaCarne.Agregar(carne);
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





        // AGREGAR
        public void AgregarCarne(int id, string nombre, double precio, string producto, int cantidad)//o pasar por paremetro la carne 
        {
            string query = "INSERT INTO Carne (Id, Nombre, Precio, Producto, Cantidad) VALUES (@Id, @Nombre, @Precio, @Producto, @Cantidad)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Precio", precio);
                command.Parameters.AddWithValue("@Producto", producto);
                command.Parameters.AddWithValue("@Cantidad", cantidad);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //ELIMINAR
        public void EliminarCarne(int id)
        {
            string query = "DELETE FROM Carne WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        //MODIFICAR

        public void ModificarCarne(Carniceria carne)
        {
            string query = "UPDATE Carne SET Nombre = @Nombre, Precio = @Precio, Producto = @Producto, Cantidad = @Cantidad WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Nombre", carne.CortesCarne);
                command.Parameters.AddWithValue("@Precio", nuevoPrecio);
                command.Parameters.AddWithValue("@Producto", nuevoProducto);
                command.Parameters.AddWithValue("@Cantidad", nuevaCantidad);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Le pasamos por parametro una lista con los cortes modificados o agregados
        /// Validamos mediante el id si existe para poder modificar y en el caso contraro lo agrega a la base de datos
        /// </summary>
        /// <param name="carne"></param>
        public void GuardarCambios(List<Carniceria> carne)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (Carniceria c in carne)
                {
                    // Verificar si el corte de carne ya existe en la base de datos
                    string selectQuery = "SELECT COUNT(*) FROM Carne WHERE Id = @Id";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@Id", c.Id);

                    int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                    // Si el corte ya existe
                    if (count > 0)
                    {
                        // El corte de carne ya existe en la base de datos, obtener sus datos
                        string selectDataQuery = "SELECT Nombre, Precio, Producto, Cantidad FROM Carne WHERE Id = @Id";
                        SqlCommand selectDataCommand = new SqlCommand(selectDataQuery, connection);
                        selectDataCommand.Parameters.AddWithValue("@Id", c.Id);

                        using (SqlDataReader reader = selectDataCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombreExistente = reader.GetString(0);
                                double precioExistente = reader.GetDouble(1);
                                string productoExistente = reader.GetString(2);
                                int cantidadExistente = reader.GetInt32(3);

                                // Si no hay cambios, la elimina
                                if (c.Nombre == nombreExistente && c.Precio == precioExistente && c.Producto == productoExistente && c.Cantidad == cantidadExistente)
                                {
                                    EliminarCarne(c.Id);
                                }
                                else
                                {
                                    // Si se modifico algo de ese corte lo modifica en la base de datos
                                    ModificarCarne(c.Id, c.Nombre, c.Precio, c.Producto, c.Cantidad);
                                }
                            }
                        }
                    }
                    else// agregar a la base de datos en caso de que no se encuentre ese corte
                    {
                        AgregarCarne(Carniceria carne);
                    }
                }
            }
        }


        */
    }
}
