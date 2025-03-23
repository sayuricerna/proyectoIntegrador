using System;
using System.Collections.Generic;
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
                // First, insert a new justification record into the justificacion table
                int justificationId = InsertJustification(reason, detail);

                // Then, update the attendance records to mark them as justified
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE asistencia SET justificado = TRUE, idJustificacion = @idJustificacion WHERE idEmpleado = @idEmpleado AND fecha BETWEEN @startDate AND @endDate AND justificado = FALSE";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                        cmd.Parameters.AddWithValue("@idEmpleado", employeeId);
                        cmd.Parameters.AddWithValue("@idJustificacion", justificationId);

                        cmd.ExecuteNonQuery();
                    }
                }
                return "Justification applied successfully!";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
