using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectoIntegrador.Models;
using proyectoIntegrador.Config;
using MySql.Data.MySqlClient;

namespace proyectoIntegrador.Controllers
{

    internal class position_controller
    {

        private readonly connection cn = new connection();

        // Insertar un nuevo cargo
        public string Insert(position_model position)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "INSERT INTO cargo (NombreCargo, Salario, IdDepartamento, isDeleted) VALUES (@NombreCargo, @Salario, @IdDepartamento, @IsDeleted)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreCargo", position.NombreCargo);
                    command.Parameters.AddWithValue("@Salario", position.Salario);
                    command.Parameters.AddWithValue("@IdDepartamento", position.IdDepartamento);
                    command.Parameters.AddWithValue("@IsDeleted", position.IsDeleted);
                    return ExecuteCommand(command, connection);
                }
            }
        }

        // Obtener todos los cargos activos
        public List<position_model> GetAll()
        {
            var positionList = new List<position_model>();
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT IdCargo, NombreCargo, Salario, IdDepartamento FROM cargo WHERE isDeleted = 0";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            positionList.Add(new position_model
                            {
                                IdCargo = reader.GetInt32("IdCargo"),
                                NombreCargo = reader.GetString("NombreCargo"),
                                Salario = reader.GetDecimal("Salario"),
                                IdDepartamento = reader.GetInt32("IdDepartamento")
                            });
                        }
                    }
                }
            }
            return positionList;
        }

        // Obtener un cargo por ID
        public position_model GetById(int id)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM cargo WHERE IdCargo = @IdCargo AND isDeleted = 0";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCargo", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new position_model
                            {
                                IdCargo = reader.GetInt32("IdCargo"),
                                NombreCargo = reader.GetString("NombreCargo"),
                                Salario = reader.GetDecimal("Salario"),
                                IdDepartamento = reader.GetInt32("IdDepartamento"),
                                IsDeleted = reader.GetBoolean("isDeleted")
                            };
                        }
                        return null;
                    }
                }
            }
        }

        // Actualizar un cargo
        public string Update(position_model position)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "UPDATE cargo SET NombreCargo = @NombreCargo, Salario = @Salario, IdDepartamento = @IdDepartamento WHERE IdCargo = @IdCargo";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCargo", position.IdCargo);
                    command.Parameters.AddWithValue("@NombreCargo", position.NombreCargo);
                    command.Parameters.AddWithValue("@Salario", position.Salario);
                    command.Parameters.AddWithValue("@IdDepartamento", position.IdDepartamento);
                    return ExecuteCommand(command, connection);

                }
            }
        }

        // Eliminar un cargo (soft delete)
        public bool Delete(int id)
        {
            using (var connection = cn.GetConnection())
            {
                string query = "UPDATE cargo SET isDeleted = 1 WHERE IdCargo = @IdCargo";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCargo", id);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        // Buscar cargos por nombre
        public List<position_model> SearchByName(string name)
        {
            var positionList = new List<position_model>();
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT * FROM cargo WHERE NombreCargo LIKE @Name AND isDeleted = 0";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", "%" + name + "%");
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            positionList.Add(new position_model
                            {
                                IdCargo = reader.GetInt32("IdCargo"),
                                NombreCargo = reader.GetString("NombreCargo"),
                                Salario = reader.GetDecimal("Salario"),
                                IdDepartamento = reader.GetInt32("IdDepartamento"),
                                IsDeleted = reader.GetBoolean("isDeleted")
                            });
                        }
                    }
                }
            }
            return positionList;
        }

        // Ejecutar el comando SQL (INSERT, UPDATE, DELETE)
        private string ExecuteCommand(MySqlCommand command, MySqlConnection connection)
        {
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        // Obtener cargos por departamento
        public List<position_model> GetByDepartment(int departmentId)
        {
            var positionList = new List<position_model>();
            using (var connection = cn.GetConnection())
            {
                string query = "SELECT IdCargo, NombreCargo, Salario, IdDepartamento FROM cargo WHERE IdDepartamento = @IdDepartamento AND isDeleted = 0";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdDepartamento", departmentId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            positionList.Add(new position_model
                            {
                                IdCargo = reader.GetInt32("IdCargo"),
                                NombreCargo = reader.GetString("NombreCargo"),
                                Salario = reader.GetDecimal("Salario"),
                                IdDepartamento = reader.GetInt32("IdDepartamento")
                            });
                        }
                    }
                }
            }
            return positionList;
        }

    }
}
