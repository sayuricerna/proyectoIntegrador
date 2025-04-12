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
                        // Auditoría: Registro de la acción de crear un anticipo
                        AuditHelper.RegistrarAuditoria(
                            conn,
                            Session.IdUsuario, // Usuario que crea el anticipo
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
                // Si se genera un SIGNAL en el SP se lanzará una excepción MySqlException.
                return "Error al crear anticipo: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error inesperado: " + ex.Message;
            }
        }

        
    }
}
