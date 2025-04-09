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
    internal class justification_controller
    {
        private readonly connection _connection = new connection();

        private int InsertJustification(string reason, string detail)
        {
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO justificacion (motivo, detalle, isDeleted) VALUES (@motivo, @detalle, FALSE)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@motivo", reason);
                    cmd.Parameters.AddWithValue("@detalle", detail);

                    cmd.ExecuteNonQuery();

                    // Get the last inserted Justification ID
                    cmd.CommandText = "SELECT LAST_INSERT_ID()";
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Get all justifications (can be used to view justification details)
        public List<justification_model> GetAllJustifications()
        {
            var list = new List<justification_model>();
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM justificacion WHERE isDeleted = FALSE";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new justification_model
                            {
                                IdJustificacion = reader.GetInt32("idJustificacion"),
                                Motivo = reader.GetString("motivo"),
                                Detalle = reader.GetString("detalle"),
                                IsDeleted = reader.GetBoolean("isDeleted")
                            });
                        }
                    }
                }
            }
            return list;
        }
        // Insert a new justification and update attendance as justified
        public string JustifyAttendance(DateTime startDate, DateTime endDate, int employeeId, string reason, string detail)
        {
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();

                    // Ejecutar el procedimiento almacenado
                    using (var cmd = new MySqlCommand("JustificarAsistencia", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros de entrada
                        cmd.Parameters.AddWithValue("@p_idEmpleado", employeeId);
                        cmd.Parameters.AddWithValue("@p_fechaInicio", startDate.Date);
                        cmd.Parameters.AddWithValue("@p_fechaFin", endDate.Date);
                        cmd.Parameters.AddWithValue("@p_motivo", reason);
                        cmd.Parameters.AddWithValue("@p_detalle", detail);

                        // Parámetro de salida para el mensaje
                        var resultParam = new MySqlParameter("@resultado", MySqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(resultParam);

                        cmd.ExecuteNonQuery();

                        // Obtener mensaje de salida
                        return resultParam.Value?.ToString() ?? "Proceso completado sin mensaje.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
