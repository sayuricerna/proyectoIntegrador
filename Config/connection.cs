using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace proyectoIntegrador.Config
{
    internal class connection
    {
        private static readonly string server = "localhost";
        private static readonly string database = "proyectointegrador";
        private static readonly string username = "root";
        private static readonly string password = "woofer";

        //private string connectionString = $"Server={server};database={database};uid={username};pwd={password}";
        //private string connectionString = $"Server={server};Port=3306;Database={database};uid={username};pwd={password};SslMode=Required;ConnectionTimeout=30;";
        private string connectionString = "Server=localhost;Port=3306;database=proyectointegrador;uid=root";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
                return false;
            }
        }
        /*
        public void ExecuteQuery()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    // Your database operations here
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("La conexión está abierta.");
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Handle MySQL-specific exceptions
                Console.WriteLine("MySQL Error: " + mysqlEx.Message);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine("General Error: " + ex.Message);
            }
        }*/
    }
}
