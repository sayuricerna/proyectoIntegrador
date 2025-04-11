using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace proyectoIntegrador.Helpers
{
    class AuditHelper
    {
        public static void RegistrarAuditoria(MySqlConnection connection, int idUsuario, string accion, string tabla, string descripcion)
        {
            string query = "INSERT INTO auditoria (idUsuario, tipoAccion, tablaAfectada, descripcion) VALUES (@idUsuario, @accion, @tabla, @descripcion)";

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                command.Parameters.AddWithValue("@accion", accion);
                command.Parameters.AddWithValue("@tabla", tabla);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.ExecuteNonQuery();
            }
        }

    }
}
