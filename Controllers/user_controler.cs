using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using proyectoIntegrador.Config;
using proyectoIntegrador.Models;

namespace proyectoIntegrador.Controllers
{
    internal class user_controler
    {
        private readonly connection cn = new connection(); // Usa tu clase de conexión

        public List<user_model> GetAll()
        {
            List<user_model> usuarios = new List<user_model>();

            using (MySqlConnection conn = cn.GetConnection()) // Suponiendo que GetConnection() devuelve una conexión MySQL
            {
                string query = "SELECT * FROM Usuario WHERE IsDeleted = 0";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        usuarios.Add(new user_model
                        {
                            IdUsuario = reader.GetInt32("IdUsuario"),
                            NombreUsuario = reader.GetString("NombreUsuario"),
                            Contrasenia = reader.GetString("Contrasenia"),
                            RolUsuario = reader.GetString("RolUsuario"),
                            Estado = reader.GetBoolean("Estado"),
                            IsDeleted = reader.GetBoolean("IsDeleted"),
                            IdEmpleado = reader.GetInt32("IdEmpleado")
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener usuarios: " + ex.Message);
                }
            }
            return usuarios;
        }

        public user_model GetById(int id)
        {
            user_model usuario = null;

            using (MySqlConnection conn = cn.GetConnection())
            {
                string query = "SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario AND IsDeleted = 0";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUsuario", id);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        usuario = new user_model
                        {
                            IdUsuario = reader.GetInt32("IdUsuario"),
                            NombreUsuario = reader.GetString("NombreUsuario"),
                            Contrasenia = reader.GetString("Contrasenia"),
                            RolUsuario = reader.GetString("RolUsuario"),
                            Estado = reader.GetBoolean("Estado"),
                            IsDeleted = reader.GetBoolean("IsDeleted"),
                            IdEmpleado = reader.GetInt32("IdEmpleado")
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener usuario por ID: " + ex.Message);
                }
            }
            return usuario;
        }
        public List<user_model> SearchByName(string nombre)
        {
            List<user_model> usuarios = new List<user_model>();

            using (MySqlConnection conn = cn.GetConnection())
            {
                string query = "SELECT * FROM Usuario WHERE NombreUsuario LIKE @Nombre AND IsDeleted = 0";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        usuarios.Add(new user_model
                        {
                            IdUsuario = reader.GetInt32("IdUsuario"),
                            NombreUsuario = reader.GetString("NombreUsuario"),
                            Contrasenia = reader.GetString("Contrasenia"),
                            RolUsuario = reader.GetString("RolUsuario"),
                            Estado = reader.GetBoolean("Estado"),
                            IsDeleted = reader.GetBoolean("IsDeleted"),
                            IdEmpleado = reader.GetInt32("IdEmpleado")
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al buscar usuario por nombre: " + ex.Message);
                }
            }
            return usuarios;
        }

        public string Insert(user_model usuario)
        {
            using (MySqlConnection conn = cn.GetConnection())
            {
                string query = "INSERT INTO Usuario (NombreUsuario, Contrasenia, RolUsuario, Estado, IsDeleted, IdEmpleado) " +
                               "VALUES (@NombreUsuario, @Contrasenia, @RolUsuario, @Estado, 0, @IdEmpleado)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                cmd.Parameters.AddWithValue("@RolUsuario", usuario.RolUsuario);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@IdEmpleado", usuario.IdEmpleado);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return "ok";
                }
                catch (Exception ex)
                {
                    return "Error al insertar usuario: " + ex.Message;
                }
            }
        }

        public string Update(user_model usuario)
        {
            using (MySqlConnection conn = cn.GetConnection())
            {
                string query = "UPDATE Usuario SET NombreUsuario = @NombreUsuario, Contrasenia = @Contrasenia, " +
                               "RolUsuario = @RolUsuario, Estado = @Estado, IdEmpleado = @IdEmpleado WHERE IdUsuario = @IdUsuario";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                cmd.Parameters.AddWithValue("@RolUsuario", usuario.RolUsuario);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@IdEmpleado", usuario.IdEmpleado);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return "ok";
                }
                catch (Exception ex)
                {
                    return "Error al actualizar usuario: " + ex.Message;
                }
            }
        }

        public bool Delete(int id)
        {
            using (MySqlConnection conn = cn.GetConnection())
            {
                string query = "UPDATE Usuario SET IsDeleted = 1 WHERE IdUsuario = @IdUsuario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUsuario", id);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar usuario: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
