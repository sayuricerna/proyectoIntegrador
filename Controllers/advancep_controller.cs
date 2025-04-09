using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Config;
using proyectoIntegrador.Models;

namespace proyectoIntegrador.Controllers
{
    class advancep_controller
    {
        private readonly connection _connection = new connection();

        // Método para crear un anticipo utilizando el procedimiento almacenado "CrearAnticipo"
        public string CrearAnticipo(int idEmpleado, decimal monto, string motivo)
        {
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("CrearAnticipo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_idEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@p_monto", monto);
                        cmd.Parameters.AddWithValue("@p_motivo", motivo);

                        cmd.ExecuteNonQuery();
                    }
                }
                return "Anticipo creado correctamente.";
            }
            catch (MySqlException ex)
            {
                // Si se genera un SIGNAL en el SP se lanzará una excepción MySqlException.
                return "Error al crear anticipo: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error inesperado: " + ex.Message;
            }
        }

        // Opcional: Método para obtener los anticipos de un empleado (por ejemplo, para mostrar en un grid)
        public List<advancep_model> GetAnticiposByEmpleado(int idEmpleado)
        {
            var list = new List<advancep_model>();
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM anticipo WHERE idEmpleado = @idEmpleado AND isDeleted = FALSE";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new advancep_model
                                {
                                    IdAnticipo = reader.GetInt32("idAnticipo"),
                                    IdEmpleado = reader.GetInt32("idEmpleado"),
                                    Fecha = reader.GetDateTime("fecha"),
                                    Monto = reader.GetDecimal("monto"),
                                    Motivo = reader.GetString("motivo"),
                                    IsDeleted = reader.GetBoolean("isDeleted")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener anticipos: " + ex.Message);
            }
            return list;
        }
    }
}
