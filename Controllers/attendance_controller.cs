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
    internal class attendance_controller
    {
        private readonly connection _connection = new connection();

        public List<attendance_model> GetAllView()
        {
            var list = new List<attendance_model>();
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM vista_asistencias";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new attendance_model
                            {
                                //IdAsistencia = reader.GetInt32("idAsistencia"),
                                //IdEmpleado = reader.GetInt32("idEmpleado"),
                                NombreEmpleado = reader.GetString("nombreEmpleado"),
                                Fecha = reader.GetDateTime("fecha"),
                                HoraEntrada = reader.IsDBNull(reader.GetOrdinal("horaEntrada")) ? (TimeSpan?)null : reader.GetTimeSpan("horaEntrada"),
                                HoraSalida = reader.IsDBNull(reader.GetOrdinal("horaSalida")) ? (TimeSpan?)null : reader.GetTimeSpan("horaSalida"),
                                HorasTrabajadasTiempo = reader.IsDBNull(reader.GetOrdinal("horasTrabajadasTiempo")) ? (TimeSpan?)null : reader.GetTimeSpan("horasTrabajadasTiempo"),
                                HorasSuplementariasTiempo = reader.IsDBNull(reader.GetOrdinal("horasSuplementariasTiempo")) ? (TimeSpan?)null : reader.GetTimeSpan("horasSuplementariasTiempo"),
                                HorasExtrasTiempo = reader.IsDBNull(reader.GetOrdinal("horasExtrasTiempo")) ? (TimeSpan?)null : reader.GetTimeSpan("horasExtrasTiempo"),
                                HorasNOTrabajadasTiempo = reader.IsDBNull(reader.GetOrdinal("horasNOTrabajadasTiempo")) ? (TimeSpan?)null : reader.GetTimeSpan("horasNOTrabajadasTiempo"),
                                JustificadoStr = reader.GetString("Justificado"),
                                MotivoJustificacion = reader.IsDBNull(reader.GetOrdinal("MotivoJustificacion")) ? null : reader.GetString("MotivoJustificacion"),
                                DetalleJustificacion = reader.IsDBNull(reader.GetOrdinal("DetalleJustificacion")) ? null : reader.GetString("DetalleJustificacion")
                            });
                        }
                    }
                }
            }
            return list;
        }
        // Obtener todas las asistencias
        public List<attendance_model> SearchView(string employeeName)
        {
            var list = new List<attendance_model>();
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM vista_asistencias WHERE LOWER(nombreEmpleado) LIKE @employeeName";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeName", "%" + employeeName + "%");
                    //cmd.Parameters.AddWithValue("@employeeName", "%sayu%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new attendance_model
                            {
                                //IdAsistencia = reader.GetInt32("idAsistencia"),
                                //IdEmpleado = reader.GetInt32("idEmpleado"),
                                NombreEmpleado = reader.GetString("nombreEmpleado"),
                                Fecha = reader.GetDateTime("fecha"),
                                HoraEntrada = reader.IsDBNull(reader.GetOrdinal("horaEntrada")) ? (TimeSpan?)null : reader.GetTimeSpan("horaEntrada"),
                                HoraSalida = reader.IsDBNull(reader.GetOrdinal("horaSalida")) ? (TimeSpan?)null : reader.GetTimeSpan("horaSalida"),
                                HorasTrabajadasTiempo = reader.IsDBNull(reader.GetOrdinal("horasTrabajadasTiempo")) ? (TimeSpan?)null : reader.GetTimeSpan("horasTrabajadasTiempo"),
                                HorasSuplementariasTiempo = reader.IsDBNull(reader.GetOrdinal("horasSuplementariasTiempo")) ? (TimeSpan?)null : reader.GetTimeSpan("horasSuplementariasTiempo"),
                                HorasExtrasTiempo = reader.IsDBNull(reader.GetOrdinal("horasExtrasTiempo")) ? (TimeSpan?)null : reader.GetTimeSpan("horasExtrasTiempo"),
                                HorasNOTrabajadasTiempo = reader.IsDBNull(reader.GetOrdinal("horasNOTrabajadasTiempo")) ? (TimeSpan?)null : reader.GetTimeSpan("horasNOTrabajadasTiempo"),
                                JustificadoStr = reader.GetString("Justificado"),
                                MotivoJustificacion = reader.IsDBNull(reader.GetOrdinal("MotivoJustificacion")) ? null : reader.GetString("MotivoJustificacion"),
                                DetalleJustificacion = reader.IsDBNull(reader.GetOrdinal("DetalleJustificacion")) ? null : reader.GetString("DetalleJustificacion")
                            });
                        }
                    }
                }
            }
            return list;
        }
        public string InsertAttendance(int fingerprintId)
        {
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    string query = "CALL registrarAsistenciaPorHuella(@huella_id);";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@huella_id", fingerprintId);
                        cmd.ExecuteNonQuery();
                        // Auditoría: Registro de la acción de registrar asistencia
                        AuditHelper.RegistrarAuditoria(
                            conn,
                            Session.IdUsuario, // Usuario que realiza la acción
                            "INSERT", // Tipo de operación
                            "asistencia", // Nombre de la entidad relacionada
                            $"Se registró asistencia huella: {fingerprintId}."
                        );
                        return "Asistencia registrada con éxito.";
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
