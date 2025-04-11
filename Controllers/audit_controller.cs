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
    internal class audit_controller
    {
        private readonly connection _cn = new connection();

        public List<audit_model> GetAll()
        {
            var auditList = new List<audit_model>();
            using (var connection = _cn.GetConnection())
            {
                string query = "SELECT idAuditoria, tipoAccion, fechaHora, idUsuario, descripcion FROM auditoria ";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            auditList.Add(new audit_model
                            {
                                IdAuditoria = reader.GetInt32("idAuditoria"),
                                TipoAccion = reader.GetString("tipoAccion"),
                                FechaHora = reader.GetDateTime("fechaHora"),
                                IdUsuario = reader.GetInt32("idUsuario"),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString("Descripcion")
                            });
                        }
                    }
                }
            }
            return auditList;
        }

        public audit_model GetById(int id)
        {
            audit_model audit = null;
            using (var connection = _cn.GetConnection())
            {
                string query = "SELECT IdAuditoria, TipoAccion, FechaHora, IdUsuario, Descripcion FROM auditoria WHERE IdAuditoria = @IdAuditoria AND isDeleted = 0";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdAuditoria", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            audit = new audit_model
                            {
                                IdAuditoria = reader.GetInt32("IdAuditoria"),
                                TipoAccion = reader.GetString("TipoAccion"),
                                FechaHora = reader.GetDateTime("FechaHora"),
                                IdUsuario = reader.GetInt32("IdUsuario"),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString("Descripcion")
                            };
                        }
                    }
                }
            }
            return audit;
        }

        public List<audit_model> SearchByAction(string action)
        {
            var auditList = new List<audit_model>();
            using (var connection = _cn.GetConnection())
            {
                string query = "SELECT IdAuditoria, TipoAccion, FechaHora, IdUsuario, Descripcion FROM auditoria WHERE Accion LIKE @Accion";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Accion", "%" + action + "%");
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            auditList.Add(new audit_model
                            {
                                IdAuditoria = reader.GetInt32("IdAuditoria"),
                                TipoAccion = reader.GetString("TipoAccion"),
                                FechaHora = reader.GetDateTime("FechaHora"),
                                IdUsuario = reader.GetInt32("IdUsuario"),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader.GetString("Descripcion")
                            });
                        }
                    }
                }
            }
            return auditList;
        }
    }
}
