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
        private static readonly string port = "3306";
        private static readonly string database = "proyectointegrador";
        private static readonly string uid = "admin_servitec";
        private static readonly string pwd = "admin234";

        private string connectionString = $"Server={server};Port={port};database={database};uid={uid};pwd={pwd}";

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
    }
}
