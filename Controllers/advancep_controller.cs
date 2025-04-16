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
    class advancep_controller
    {
        private readonly connection _connection = new connection();

        public List<advancep_model> getAll()
        {
            var lista = new List<advancep_model>();
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM vista_anticipos";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new advancep_model
                        {
                            IdAnticipo = reader.GetInt32("idAnticipo"),
                            NombreEmpleado = reader.GetString("nombreEmpleado"),
                            Fecha = reader.GetDateTime("fecha"),
                            Monto = reader.GetDecimal("monto"),
                            Motivo = reader.GetString("motivo")
                        });
                    }
                }
            }
            return lista;
        }
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
                        AuditHelper.RegistrarAuditoria(
                            conn,
                            Session.IdUsuario,
                            "INSERT",
                            "anticipo",
                            $"Se creó un anticipo de {monto} para el empleado con ID: {idEmpleado}. Motivo: {motivo}"
                        );
                    }
                }
                return "Anticipo creado correctamente.";
            }
            catch (MySqlException ex)
            {
                return "Error al crear anticipo: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error inesperado: " + ex.Message;
            }
        }

        public string deleteAdvance(int idAnticipo)
        {
            try
            {
                using (var conn = _connection.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand("EliminarAnticipo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_idAnticipo", idAnticipo);

                        cmd.ExecuteNonQuery();

                        // Auditori
                        AuditHelper.RegistrarAuditoria(
                            conn,
                            Session.IdUsuario, 
                            "UPDATE",
                            "anticipo",
                            $"Se eliminó (marcó como eliminado) el anticipo con ID: {idAnticipo}."
                        );
                    }
                }
                return "Anticipo eliminado correctamente.";
            }
            catch (MySqlException ex)
            {
               
                return "Error al eliminar anticipo: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error inesperado: " + ex.Message;
            }
        }


    }
}
