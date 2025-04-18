﻿using System;
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
                string query = "SELECT * FROM vista_auditorias ";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            auditList.Add(new audit_model
                            {
                                // idAuditoria tablaAfectada tipoAccion descripcion fechaHora usuarioResponsable rolUsuario
                                IdAuditoria = reader.GetInt32("idAuditoria"),
                                TablaAfectada = reader.GetString("tablaAfectada"),
                                TipoAccion = reader.GetString("tipoAccion"),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString("descripcion"),
                                FechaHora = reader.GetDateTime("fechaHora"),
                                UsuarioResponsable = reader.GetString("usuarioResponsable"),
                                RolUsuario = reader.GetString("rolUsuario")
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
                string query = "SELECT * FROM vista_auditorias  WHERE IdAuditoria = @IdAuditoria";
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
                                IdAuditoria = reader.GetInt32("idAuditoria"),
                                TablaAfectada = reader.GetString("tablaAfectada"),
                                TipoAccion = reader.GetString("tipoAccion"),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString("descripcion"),
                                FechaHora = reader.GetDateTime("fechaHora"),
                                UsuarioResponsable = reader.GetString("usuarioResponsable"),
                                RolUsuario = reader.GetString("rolUsuario")
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
                string query = "SELECT * FROM vista_auditorias WHERE tipoAccion LIKE @Accion";
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
                                IdAuditoria = reader.GetInt32("idAuditoria"),
                                TablaAfectada = reader.GetString("tablaAfectada"),
                                TipoAccion = reader.GetString("tipoAccion"),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString("descripcion"),
                                FechaHora = reader.GetDateTime("fechaHora"),
                                UsuarioResponsable = reader.GetString("usuarioResponsable"),
                                RolUsuario = reader.GetString("rolUsuario")
                            });
                        }
                    }
                }
            }
            return auditList;
        }
    }
}
