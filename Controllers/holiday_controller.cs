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
    internal class holiday_controller
    {
        private readonly connection _connection = new connection();

        public List<holiday_model> getAll()
        {
            var lista = new List<holiday_model>();
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM feriados ORDER BY fechaFeriado ASC";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new holiday_model
                        {
                            IdFeriado = reader.GetInt32("idFeriado"),
                            NombreFeriado = reader.GetString("nombreFeriado"),
                            FechaFeriado = reader.GetDateTime("fechaFeriado")
                        });
                    }
                }
            }
            return lista;
        }

        public void addHoliday(string nombre, DateTime fecha)
        {
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO feriados (nombreFeriado, fechaFeriado) VALUES (@nombre, @fecha)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void updateHoliday(int id, string nuevoNombre, DateTime nuevaFecha)
        {
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE feriados SET nombreFeriado = @nombre, fechaFeriado = @fecha WHERE idFeriado = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@fecha", nuevaFecha);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deleteHoliday(int id)
        {
            using (var conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM feriados WHERE idFeriado = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
