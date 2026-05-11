using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicStore
{
    // ============================================================
    // EJERCICIO 3 - Base de Datos MySQL
    // ============================================================
    // Clase que gestiona la conexión y operaciones contra la BBDD
    // 'musicstore' en MySQL.
    //
    // Tabla esperada (script del enunciado):
    //   CREATE TABLE album (
    //       id INT AUTO_INCREMENT PRIMARY KEY,
    //       titulo VARCHAR(100),
    //       artista VARCHAR(100),
    //       anyo INT,
    //       disponible BOOLEAN
    //   );
    // ============================================================
    public class GestorBD
    {
        private MySqlConnection conexion;

        // ----------------------------------------------------------
        // Apartado 3.1 - Conexión (constructor)
        // ----------------------------------------------------------
        public GestorBD()
        {
            // Construimos la cadena de conexión con el builder
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "musicstore";

            // Creamos el objeto de conexión a partir de la cadena
            conexion = new MySqlConnection(builder.ConnectionString);
        }

        // ----------------------------------------------------------
        // Apartado 3.2 - Insertar un Album en la BBDD
        // ----------------------------------------------------------
        public void Insertar(Album p)
        {
            try
            {
                conexion.Open();

                string sql = "INSERT INTO album (titulo, artista, anyo, disponible) " +
                             "VALUES (@titulo, @artista, @anyo, @disponible)";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);

                // Parámetros con AddWithValue (evita inyección SQL)
                cmd.Parameters.AddWithValue("@titulo", p.getTitulo());
                cmd.Parameters.AddWithValue("@artista", p.getArtista());
                cmd.Parameters.AddWithValue("@anyo", p.getAnyo());
                cmd.Parameters.AddWithValue("@disponible", p.isDisponible());

                cmd.ExecuteNonQuery();

                Console.WriteLine("Album insertado: " + p.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        // ----------------------------------------------------------
        // Apartado 3.3 - Leer todos los albumes de la BBDD
        // ----------------------------------------------------------
        public List<Album> ObtenerTodos()
        {
            List<Album> lista = new List<Album>();

            try
            {
                conexion.Open();

                string sql = "SELECT * FROM album";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string titulo = dr.GetString("titulo");
                    string artista = dr.GetString("artista");
                    int anyo = dr.GetInt32("anyo");
                    bool disponible = dr.GetBoolean("disponible");

                    Album a = new Album(titulo, artista, anyo, disponible);
                    lista.Add(a);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }
    }
}
