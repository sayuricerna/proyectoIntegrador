using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Config;
using proyectoIntegrador.Helpers;
using proyectoIntegrador.Models;

namespace proyectoIntegrador.Controllers
{
    internal class justification_controller
    {
        private readonly connection _connection = new connection();
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

                    using (var cmd = new MySqlCommand("JustificarAsistencia", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_idEmpleado", employeeId);
                        cmd.Parameters.AddWithValue("@p_fechaInicio", startDate.Date);
                        cmd.Parameters.AddWithValue("@p_fechaFin", endDate.Date);
                        cmd.Parameters.AddWithValue("@p_motivo", reason);
                        cmd.Parameters.AddWithValue("@p_detalle", detail);
                        var resultParam = new MySqlParameter("@resultado", MySqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(resultParam);

                        cmd.ExecuteNonQuery();
                        string resultMessage = resultParam.Value?.ToString() ?? "Proceso completado sin mensaje.";

                        // Verifica si el proceso fue exitoso
                        if (resultMessage == "Proceso completado sin mensaje." || !string.IsNullOrEmpty(resultMessage))
                        {
                            // Aquí agregamos la auditoría
                            AuditHelper.RegistrarAuditoria(
                                conn,
                                Session.IdUsuario, // Asumiendo que hay un Session.IdUsuario
                                "UPDATE",
                                "asistencia", // Aquí indicamos que estamos actualizando la asistencia
                                $"Se justificó la asistencia del empleado con ID: {employeeId} para las fechas del {startDate.ToShortDateString()} al {endDate.ToShortDateString()}. Motivo: {reason}, Detalles: {detail}"
                            );
                        }

                        return resultMessage;
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
