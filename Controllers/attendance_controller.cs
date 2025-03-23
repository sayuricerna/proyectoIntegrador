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
    internal class attendance_controller
    {
        private readonly connection _connection = new connection();


        // Obtener todas las asistencias
        public List<attendance_model> GetAll()
        {
            var list = new List<attendance_model>();
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM asistencia WHERE isDeleted = FALSE";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new attendance_model
                            {
                                IdAsistencia = reader.GetInt32("idAsistencia"),
                                IdEmpleado = reader.GetInt32("idEmpleado"),
                                Fecha = reader.GetDateTime("fecha"),
                                HoraEntrada = reader.IsDBNull(reader.GetOrdinal("horaEntrada")) ? (TimeSpan?)null : reader.GetTimeSpan("horaEntrada"),
                                HoraSalida = reader.IsDBNull(reader.GetOrdinal("horaSalida")) ? (TimeSpan?)null : reader.GetTimeSpan("horaSalida"),
                                HorasTrabajadas = reader.IsDBNull(reader.GetOrdinal("horasTrabajadas")) ? (decimal?)null : reader.GetDecimal("horasTrabajadas"),
                                Justificado = reader.GetBoolean("justificado"),
                                IdJustificacion = reader.IsDBNull(reader.GetOrdinal("idJustificacion")) ? (int?)null : reader.GetInt32("idJustificacion"),
                                IsDeleted = reader.GetBoolean("isDeleted")
                            });
                        }
                    }
                }
            }
            return list;
        }

        // Obtener una asistencia por ID
        public attendance_model GetById(int id)
        {
            attendance_model attendance = null;
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM asistencia WHERE idAsistencia = @id AND isDeleted = FALSE";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            attendance = new attendance_model
                            {
                                IdAsistencia = reader.GetInt32("idAsistencia"),
                                IdEmpleado = reader.GetInt32("idEmpleado"),
                                Fecha = reader.GetDateTime("fecha"),
                                HoraEntrada = reader.IsDBNull(reader.GetOrdinal("horaEntrada")) ? (TimeSpan?)null : reader.GetTimeSpan("horaEntrada"),
                                HoraSalida = reader.IsDBNull(reader.GetOrdinal("horaSalida")) ? (TimeSpan?)null : reader.GetTimeSpan("horaSalida"),
                                HorasTrabajadas = reader.IsDBNull(reader.GetOrdinal("horasTrabajadas")) ? (decimal?)null : reader.GetDecimal("horasTrabajadas"),
                                Justificado = reader.GetBoolean("justificado"),
                                IdJustificacion = reader.IsDBNull(reader.GetOrdinal("idJustificacion")) ? (int?)null : reader.GetInt32("idJustificacion"),
                                IsDeleted = reader.GetBoolean("isDeleted")
                            };
                        }
                    }
                }
            }
            return attendance;
        }

        // Insertar una nueva asistencia
        public string Insert(attendance_model attendance)
        {
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO asistencia (idEmpleado, fecha, horaEntrada, horaSalida, horasTrabajadas, justificado, idJustificacion, isDeleted) " +
                                   "VALUES (@idEmpleado, @fecha, @horaEntrada, @horaSalida, @horasTrabajadas, @justificado, @idJustificacion, @isDeleted)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idEmpleado", attendance.IdEmpleado);
                        cmd.Parameters.AddWithValue("@fecha", attendance.Fecha);
                        cmd.Parameters.AddWithValue("@horaEntrada", (object)attendance.HoraEntrada ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@horaSalida", (object)attendance.HoraSalida ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@horasTrabajadas", (object)attendance.HorasTrabajadas ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@justificado", attendance.Justificado);
                        cmd.Parameters.AddWithValue("@idJustificacion", (object)attendance.IdJustificacion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@isDeleted", attendance.IsDeleted);

                        cmd.ExecuteNonQuery();
                    }
                }
                return "ok";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // Actualizar una asistencia existente
        public string Update(attendance_model attendance)
        {
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE asistencia SET idEmpleado = @idEmpleado, fecha = @fecha, horaEntrada = @horaEntrada, " +
                                   "horaSalida = @horaSalida, horasTrabajadas = @horasTrabajadas, justificado = @justificado, " +
                                   "idJustificacion = @idJustificacion, isDeleted = @isDeleted WHERE idAsistencia = @idAsistencia";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idAsistencia", attendance.IdAsistencia);
                        cmd.Parameters.AddWithValue("@idEmpleado", attendance.IdEmpleado);
                        cmd.Parameters.AddWithValue("@fecha", attendance.Fecha);
                        cmd.Parameters.AddWithValue("@horaEntrada", (object)attendance.HoraEntrada ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@horaSalida", (object)attendance.HoraSalida ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@horasTrabajadas", (object)attendance.HorasTrabajadas ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@justificado", attendance.Justificado);
                        cmd.Parameters.AddWithValue("@idJustificacion", (object)attendance.IdJustificacion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@isDeleted", attendance.IsDeleted);

                        cmd.ExecuteNonQuery();
                    }
                }
                return "ok";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        // Eliminar una asistencia (marcar como eliminada)
        public string Delete(int id)
        {
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE asistencia SET isDeleted = TRUE WHERE idAsistencia = @idAsistencia";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idAsistencia", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "ok";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public List<attendance_model> GetAllByDate(DateTime startDate, DateTime endDate)
        {
            var list = new List<attendance_model>();
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM asistencia WHERE fecha BETWEEN @startDate AND @endDate AND isDeleted = FALSE";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new attendance_model
                            {
                                IdAsistencia = reader.GetInt32("idAsistencia"),
                                IdEmpleado = reader.GetInt32("idEmpleado"),
                                Fecha = reader.GetDateTime("fecha"),
                                HoraEntrada = reader.IsDBNull(reader.GetOrdinal("horaEntrada")) ? (TimeSpan?)null : reader.GetTimeSpan("horaEntrada"),
                                HoraSalida = reader.IsDBNull(reader.GetOrdinal("horaSalida")) ? (TimeSpan?)null : reader.GetTimeSpan("horaSalida"),
                                HorasTrabajadas = reader.IsDBNull(reader.GetOrdinal("horasTrabajadas")) ? (decimal?)null : reader.GetDecimal("horasTrabajadas"),
                                Justificado = reader.GetBoolean("justificado"),
                                IdJustificacion = reader.IsDBNull(reader.GetOrdinal("idJustificacion")) ? (int?)null : reader.GetInt32("idJustificacion"),
                                IsDeleted = reader.GetBoolean("isDeleted")
                            });
                        }
                    }
                }
            }
            return list;
        }



        // Insert a justification entry into the justificacion table

    }
}
